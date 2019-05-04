using System;
using Microsoft.AspNetCore.Mvc;
using Library.Domain.Requests;
using Library.Domain.Services;

namespace Library.Application.Web.Views.Books
{
    public class NewsMessagesController : Controller
    {
        private readonly NewsMessageService _newsMessageService;

        public NewsMessagesController(NewsMessageService newsMessageService)
        {
            _newsMessageService = newsMessageService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var newsMessages = _newsMessageService.GetAll();
            var viewModel = new NewsMessages.ListModel(newsMessages);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewwModel = new CreateNewsMessageRequest();
            return View(viewwModel);
        }
    }
}
