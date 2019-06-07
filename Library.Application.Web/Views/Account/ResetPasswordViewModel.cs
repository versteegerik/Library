using System.ComponentModel.DataAnnotations;
using Library.Application.Web.Properties;

namespace Library.Application.Web.Views.Account
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Account_Email", ResourceType = typeof(WebResources))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Account_Password", ResourceType = typeof(WebResources))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Account_ConfirmPassword", ResourceType = typeof(WebResources))]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Account_Code", ResourceType = typeof(WebResources))]
        public string Code { get; set; }
    }
}
