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

        [HttpPost]
        public IActionResult Create(CreateNewsMessageRequest viewwModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewwModel);
            }

            _newsMessageService.CreateNewsMessage(viewwModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var newsMessage = _newsMessageService.GetById(id);
            var viewwModel = new EditNewsMessageRequest(newsMessage);
            return View(viewwModel);
        }

        [HttpPost]
        public IActionResult Edit(EditNewsMessageRequest viewwModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewwModel);
            }

            _newsMessageService.EditNewsMessage(viewwModel);

            return RedirectToAction("Index");
        }
    }
}
