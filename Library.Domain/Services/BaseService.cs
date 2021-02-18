using Versteey.Infrastructure.Persistence;

namespace Library.Domain.Services
{
    public abstract class BaseService
    {
        protected readonly IPersistence Persistence;

        public BaseService(IPersistence persistence)
        {
            Persistence = persistence;
        }
    }
}
