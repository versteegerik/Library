using System.Collections.Generic;
using Versteey.Common.Domain;

namespace Library.Domain.Models
{
    public class Person : BaseEntity
    {
        public virtual IList<Book> WishListBooks { get; set; } = new List<Book>();

        public virtual IList<Book> OwnedBooks { get; set; } = new List<Book>();
    }
}
