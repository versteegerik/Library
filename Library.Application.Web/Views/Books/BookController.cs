using Library.Application.Web.Common;
using Library.Domain.Requests;
using Library.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public async Task<IActionResult> Index()
        {
            var myBooks = await _bookService.GetBooksForUser(User);
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

            await _bookService.CreateBook(request, User);

            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public async Task<ViewResult> Edit(Guid id)
        {
            var book = await _bookService.GetBookById(id);
            return View(new EditBookRequest(book));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBookRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _bookService.EditBook(request);

            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public async Task<ViewResult> Delete(Guid id)
        {
            var book = await _bookService.GetBookById(id);
            var bookDetailsModel = new DeleteBookRequest(book);
            return View(bookDetailsModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteBookRequest request)
        {
            await _bookService.DeleteBook(request);

            return RedirectToAction("Index", "Books");
        }
    }
}
