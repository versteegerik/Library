using Library.Common;
using Library.Infrastructure.Audit.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Infrastructure.Audit.Models
{
    [Table(Constants.Audit + nameof(LoginAttempt))]
    public class LoginAttempt : BaseEntity
    {
        public string Username { get; set; }
        public string UserId { get; set; }
        public string ResultOfLogin { get; set; }

        public LoginAttempt(string username, string userId, string resultOfLogin)
        {
            Username = username;
            UserId = userId;
            ResultOfLogin = resultOfLogin;
        }
    }
}
