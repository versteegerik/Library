using Library.Application.Services;
using Library.Application.Web.Common;
using Library.Application.Web.Models;
using Library.Infrastructure.Security.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Library.Application.Web.Views.Home
{
    public class HomeController : LoggedInController
    {
        private readonly NewsMessageService _newsMessageService;

        public HomeController(NewsMessageService newsMessageService, CurrentUserService cus) : base(cus)
        {
            _newsMessageService = newsMessageService;
        }

        public IActionResult Index()
        {
            var news = _newsMessageService.GetListForOverview();
            var viewModel = new HomeIndexModel(news);
            return View(viewModel);
        }

        public IActionResult About() => View();

        public IActionResult Contact() => View();

        public IActionResult Privacy() => View();

        public IActionResult Settings() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
