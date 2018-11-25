using System.ComponentModel.DataAnnotations;

namespace Library.Application.Web.Views.Account
{
    public class UseRecoveryCodeViewModel
    {
        [Required]
        public string Code { get; set; }

        public string ReturnUrl { get; set; }
    }
}
