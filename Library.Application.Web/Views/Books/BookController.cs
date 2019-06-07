using System;
using System.Threading.Tasks;
using Library.Application.Web.Common;
using Microsoft.AspNetCore.Mvc;
using Library.Domain.Requests;
using Library.Domain.Services;

namespace Library.Application.Web.Views.Books
{
    public class BooksController : BaseController
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var myBooks = await _bookService.GetBooksForUserAsync(User);
            var booksModel = new BookListViewModel(myBooks);
            return View(booksModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View(new CreateBookRequest());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _bookService.CreateBookAsync(request, User);

            return RedirectToAction("Index", "Books");
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

            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public async Task<ViewResult> Details(Guid id)
        {
            var book = await _bookService.GetBookById(id);
            var bookDetailsModel = new BookDetailsModel(book);
            return View(bookDetailsModel);
        }

        [HttpGet]
        public async Task<ViewResult> Delete(Guid id)
        {
            var book = await _bookService.GetBookById(id);
            var bookDetailsModel = new BookDetailsModel(book);
            return View(bookDetailsModel);
        }

        [HttpDelete]
        public IActionResult Delete(DeleteRequest request)
        {
            _bookService.Delete(request);

            return RedirectToAction("Index", "Books");
        }
    }
}
