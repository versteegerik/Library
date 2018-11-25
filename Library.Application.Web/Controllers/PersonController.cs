using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Library.Application.Web.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Overview()
        {
            return View();
        }
    }
}