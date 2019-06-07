using System.ComponentModel.DataAnnotations;
using Library.Application.Web.Properties;

namespace Library.Application.Web.Views.Account
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Account_UserName", ResourceType = typeof(WebResources))]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Account_Password", ResourceType = typeof(WebResources))]
        public string Password { get; set; }

        [Display(Name = "Account_RememberMe", ResourceType = typeof(WebResources))]
        public bool RememberMe { get; set; }
    }
}
