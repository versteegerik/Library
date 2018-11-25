using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Library.Application.Web.Views.Account
{
    public class SendCodeViewModel
    {
        public string SelectedProvider = "Email";

        public ICollection<SelectListItem> Providers { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}
