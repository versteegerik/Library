using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Models
{
    public interface IDomainUser
    {
        string Id { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
    }

    [Table("AspNetUsers")]
    public class DomainUser : IDomainUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
