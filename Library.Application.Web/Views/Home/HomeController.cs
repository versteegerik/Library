using System.Diagnostics;
using Library.Application.Web.Models;
using Library.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Application.Web.Views.Home
{
    public class HomeController : Controller
    {
        private readonly BookService _bookService;

        public HomeController(BookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var myBooks = _bookService.GetMyBooks();
            var myWishList = _bookService.GetMyWishList();
            var homeModel = new HomeModel(myBooks, myWishList);
            return View(homeModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
