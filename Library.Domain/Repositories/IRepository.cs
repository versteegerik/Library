using Library.Domain.Common;
using System;

namespace Library.Domain.Repositories
{
    public abstract class IRepository
    {
        protected ApplicationDbContext DbContext { get; }

        public IRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }


        public T Get<T>(Guid id) where T : BaseEntity => DbContext.Find<T>(id);

        public void Add<T>(T enity) where T : BaseEntity => DbContext.Add(enity);

        public void Update<T>(T enity) where T : BaseEntity => DbContext.Update(enity);

        public void SaveChanges() => DbContext.SaveChanges();
    }
}
