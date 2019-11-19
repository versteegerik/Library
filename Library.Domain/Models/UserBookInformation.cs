using System;
using Library.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Models
{
    [Table("UserBookInformations")]
    public class UserBookInformation : BaseEntity
    {
        public Guid BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; }

        public bool OnWishlist { get; set; }

        public UserBookInformation() { }

        public UserBookInformation(Book book, bool onWishlist) : this()
        {
            BookId = book.Id;
            OnWishlist = onWishlist;
        }
    }
}
