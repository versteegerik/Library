using Library.Domain.Models;
using System.Linq;

namespace Library.Domain.Common
{
    public interface IDomainPersistence
    {
        IQueryable<Book> Books { get; }
    }
}
