using EZ.Framework.EntityFramework;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc.Controllers;
using Microsoft.AspNet.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleInjector;
using SimpleInjector.Integration.AspNet;
using WK.WX.WeiXin.Data;
using WK.WX.WeiXin.Service;

namespace WK.WX.WeiXin
{
    public class Startup
    {
        public static Container container = new Container();

        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            builder.AddEnvironmentVariables();
            Configuration = builder.Build().ReloadOnChanged("appsettings.json");
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            #region SimpleInjector

            services.AddInstance<IControllerActivator>(new SimpleInjectorControllerActivator(container));
            services.AddInstance<IViewComponentInvokerFactory>(new SimpleInjectorViewComponentInvokerFactory(container));

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();
            app.UseStaticFiles();
            app.UseMvc();

            #region SimpleInjector

            container.Options.DefaultScopedLifestyle = new AspNetRequestLifestyle();

            app.UseSimpleInjectorAspNetRequestScoping(container);

            InitializeContainer(app);

            container.RegisterAspNetControllers(app);
            container.RegisterAspNetViewComponents(app);

            container.Verify();

            #endregion
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            container.Register<IDataContext, DataContext>(Lifestyle.Scoped);
            container.Register<IAdminService, AdminService>(Lifestyle.Transient);
            container.Register<IStaffService, StaffService>(Lifestyle.Transient);

            // Cross-wire ASP.NET services (if any). For instance:
            container.CrossWire<ILoggerFactory>(app);
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
