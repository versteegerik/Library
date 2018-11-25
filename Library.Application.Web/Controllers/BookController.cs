using Microsoft.AspNetCore.Mvc;
using Library.Domain.Requests;

namespace Library.Application.Web.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        public ViewResult Create()
        {
            return View(new CreateBookRequest());
        }
    }
}
