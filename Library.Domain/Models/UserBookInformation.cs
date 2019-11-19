using System;
using Library.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Models
{
    [Table("UserBookInformations")]
    public class UserBookInformation : BaseEntity
    {
        public virtual Guid BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; }

        public bool OnWishlist { get; set; }
    }
}
