using Library.Domain.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.Domain.Common
{
    public interface IDomainPersistence
    {
        IQueryable<UserBookInformation> UserBookInformations { get; }

        IQueryable<Book> Books { get; }
        void Create(Book book);
        void Update(Book book);
        void Delete(Book book);
        void Create(UserBookInformation userBookInformation);


        IQueryable<DomainUser> DomainUsers { get; }
        void Update(DomainUser domainUser);


        Task SaveChangesAsync();
    }
}
