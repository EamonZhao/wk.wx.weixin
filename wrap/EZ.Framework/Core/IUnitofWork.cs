using System;
using System.Threading.Tasks;

namespace EZ.Framework.Core
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
    }
}
