﻿using Library.Application.Models.Requests;
using Library.Application.Services;
using Library.Application.Web.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public IActionResult Update(Guid id)
        {
            var newsMessage = _newsMessageService.GetById(id);
            var viewModel = new UpdateNewsMessageRequest(newsMessage);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(UpdateNewsMessageRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _newsMessageService.UpdateNewsMessage(viewModel);

            return RedirectToAction("Index");
        }
    }
}
