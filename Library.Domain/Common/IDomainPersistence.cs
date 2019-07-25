using Library.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Domain.Common
{
    public interface IDomainPersistence
    {
        IQueryable<Book> Books { get; }

        void Create(Book book);
        void Update(Book book);
        void Delete(Book book);
        Task SaveChangesAsync();
    }
}
