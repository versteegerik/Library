using Library.Domain.Model;
using System;
using System.Collections.Generic;

namespace Library.Domain.Common
{
    public interface IRepository
    {
        IEnumerable<NewsMessage> NewsMessages { get; set; }

        T Get<T>(Guid id) where T : BaseEntity;

        void Add<T>(T enity) where T : BaseEntity;
        void Update<T>(T enity) where T : BaseEntity;

        void SaveChanges();
    }
}
