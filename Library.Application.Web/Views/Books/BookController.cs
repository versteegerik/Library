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

        public IActionResult MyBooks()
        {
            var myBooks = _bookService.GetMyBooks();
            var booksModel = new BookListViewModel(myBooks);
            return View(booksModel);
        }

        public IActionResult MyWishList()
        {
            var myWishList = _bookService.GetMyWishList();
            var booksModel = new BookListViewModel(myWishList);
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

            _bookService.CreateBook(request);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ViewResult Edit()
        {
            return View(new EditBookRequest());
        }

        [HttpPost]
        public IActionResult Edit(EditBookRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            _bookService.EditBook(request);

            return RedirectToAction("Index", "Home");
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

        [HttpDelete]
        public IActionResult Delete(DeleteRequest request)
        {
            _bookService.Delete(request);

            return RedirectToAction("Index", "Home");
        }
    }
}
