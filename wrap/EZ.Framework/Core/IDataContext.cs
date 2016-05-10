using System;
using System.Threading.Tasks;

namespace EZ.Framework.Core
{
    public interface IDataContext : IDisposable
    {
        Task SaveChangesAsync();
    }
}
