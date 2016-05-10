using System;
using System.Threading.Tasks;

namespace EZ.Framework.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly IDataContext DataContext;

        public UnitOfWork(IDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task CommitAsync()
        {
            await DataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            DataContext.Dispose();
        }
    }
}
