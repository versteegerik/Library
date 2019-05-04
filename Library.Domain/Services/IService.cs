using Library.Domain.Repositories;

namespace Library.Domain.Services
{
    public class IService<T> where T : IRepository
    {
        public T Repository { get; }

        public IService(T repository)
        {
            Repository = repository;
        }
    }
}
