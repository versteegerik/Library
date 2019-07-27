using Library.Application.Web.Common;
using Library.Domain.Common;
using Library.Domain.Models.Requests;
using Library.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Library.Application.Web.Views.Books
{
    public class BooksController : BaseController
    {
        private readonly IDomainPersistence _domainPersistence;
        private readonly BookService _bookService;

        public BooksController(IDomainPersistence domainPersistence, BookService bookService)
        {
            _domainPersistence = domainPersistence;
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var domainUser = _domainPersistence.GetDomainUser(User);
            var myBooks = _bookService.GetBooksForUser(domainUser);
            var booksModel = new BookListViewModel(myBooks);
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

            var domainUser = _domainPersistence.GetDomainUser(User);
            _bookService.CreateBook(request, domainUser);

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
