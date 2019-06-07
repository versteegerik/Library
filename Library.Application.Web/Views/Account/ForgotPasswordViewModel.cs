using System.ComponentModel.DataAnnotations;
using Library.Application.Web.Properties;

namespace Library.Application.Web.Views.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Account_Email", ResourceType = typeof(WebResources))]
        public string Email { get; set; }
    }
}
