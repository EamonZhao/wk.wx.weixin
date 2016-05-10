using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using EZ.Framework.EntityFramework;

namespace WK.WX.WeiXin.Controllers
{0
    [Route("api/[controller]")]
    public class AdminController
    {
        protected IDataContext DataContext;

        public AdminController(IDataContext dataContext)
        {
            DataContext = dataContext;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
    }
}
