using System;

namespace EZ.Framework.Core
{
    public class GenericServiceAsync : IService
    {
        protected readonly IUnitOfWork UnitOfWork;

        public GenericServiceAsync(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));

            UnitOfWork = unitOfWork;
        }
    }
}
