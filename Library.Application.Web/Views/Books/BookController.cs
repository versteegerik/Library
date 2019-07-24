using Library.Application.Web.Common;
using Library.Domain.Models;
using Library.Domain.Models.Requests;
using Library.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Application.Web.Views.Books
{
    public class BooksController : BaseController
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            //TODO
            //var myBooks = await _bookService.GetBooksForUser(User);
            var booksModel = new BookListViewModel(new List<Book>()); //new BookListViewModel(myBooks);
            return View(booksModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View(new CreateBookRequest());
        }

        [HttpPost]
        public IActionResult Create(CreateBookRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            //TODO
            //_bookService.CreateBook(request, User);

            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public ViewResult Update(Guid id)
        {
            var book = _bookService.GetBookById(id);
            return View(new UpdateBookRequest(book));
        }

        [HttpPost]
        public IActionResult Update(UpdateBookRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            _bookService.UpdateBook(request);

            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public ViewResult Delete(Guid id)
        {
            var book = _bookService.GetBookById(id);
            var bookDetailsModel = new DeleteBookRequest(book);
            return View(bookDetailsModel);
        }

        [HttpPost]
        public IActionResult Delete(DeleteBookRequest request)
        {
            _bookService.DeleteBook(request);

            return RedirectToAction("Index", "Books");
        }
    }
}
