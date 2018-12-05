using Microsoft.AspNetCore.Mvc;
using Library.Domain.Requests;

namespace Library.Application.Web.Views.Books
{
    public class BooksController : Controller
    {
        [HttpGet]
        public ViewResult Create()
        {
            return View(new CreateBookRequest());
        }

        [HttpGet]
        public ViewResult Details()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Delete()
        {
            return View();
        }
    }
}
