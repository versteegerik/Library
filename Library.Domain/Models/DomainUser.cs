using Library.Domain.Common;

namespace Library.Domain.Models
{
    public interface DomainUser
    {
        string Id { get; set; }
        string Email { get; set; }
    }
}
