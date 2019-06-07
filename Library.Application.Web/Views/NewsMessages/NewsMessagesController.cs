using System;
using System.Threading.Tasks;
using Library.Application.Web.Common;
using Microsoft.AspNetCore.Mvc;
using Library.Domain.Requests;
using Library.Domain.Services;

namespace Library.Application.Web.Views.NewsMessages
{
    public class NewsMessagesController : BaseController
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
            var viewModel = new ListModel(newsMessages);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewwModel = new CreateNewsMessageRequest();
            return View(viewwModel);
        }

        [HttpPost]
        public IActionResult Create(CreateNewsMessageRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _newsMessageService.CreateNewsMessage(viewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var newsMessage = await _newsMessageService.GetById(id);
            var viewModel = new UpdateNewsMessageRequest(newsMessage);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateNewsMessageRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            await _newsMessageService.UpdateNewsMessage(viewModel);

            return RedirectToAction("Index");
        }
    }
}
