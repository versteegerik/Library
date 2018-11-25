using System.ComponentModel.DataAnnotations;

namespace Library.Application.Web.Views.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
