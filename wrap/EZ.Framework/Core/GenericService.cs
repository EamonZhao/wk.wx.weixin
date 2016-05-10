using System;

namespace EZ.Framework.Core
{
    public class GenericService : IService
    {
        protected readonly IUnitOfWork UnitOfWork;

        public GenericService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));

            UnitOfWork = unitOfWork;
        }
    }
}
