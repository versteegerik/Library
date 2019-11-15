using Library.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Models
{
    [Table("DomainUsers")]
    public class DomainUser : BaseEntity
    {
        public virtual IList<UserBookInformation> UserBookInformations { get; set; }
    }
}
