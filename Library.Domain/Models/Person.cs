using System.Collections.Generic;
using Versteey.Common.Domain;

namespace Library.Domain.Models
{
    public class Person : BaseEntity
    {
        public virtual List<Book> WishListBooks { get; set; } = new List<Book>();

        public virtual List<Book> OwnedBooks { get; set; } = new List<Book>();
    }
}
