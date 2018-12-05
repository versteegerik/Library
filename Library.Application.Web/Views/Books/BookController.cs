using System;
using Microsoft.AspNetCore.Mvc;
using Library.Domain.Requests;
using Library.Domain.Services;

namespace Library.Application.Web.Views.Books
{
    public class BooksController : Controller
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View(new CreateBookRequest());
        }

        [HttpGet]
        public ViewResult Details(Guid id)
        {
            var book = _bookService.GetBookById(id);
            var bookDetailsModel = new BookDetailsModel(book);
            return View(bookDetailsModel);
        }

        [HttpGet]
        public ViewResult Delete(Guid id)
        {
            var book = _bookService.GetBookById(id);
            var bookDetailsModel = new BookDetailsModel(book);
            return View(bookDetailsModel);
        }
    }
}
