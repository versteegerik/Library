using Library.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Models
{
    [Table("UserBookInformations")]
    public class UserBookInformation : BaseEntity
    {
        public virtual Book Book { get; set; }
        public virtual DomainUser DomainUser { get; set; }
        public bool OnWishlist { get; set; }
    }
}
