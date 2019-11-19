using System;
using System.Linq;
using System.Linq.Expressions;
using FeedbackApp.Web.Views.Shared.DataTables;
using Library.Application.Web.Common;
using Library.Application.Web.Views.Books;
using Library.Domain.Models;
using Library.Domain.Models.Requests;
using Library.Domain.Services;
using Library.Infrastructure.Security.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Application.Web.Views.MyBooks
{
    public class MyBooksController : LoggedInController
    {
        private readonly BookService _bookService;

        public MyBooksController(BookService bookService, CurrentUserService cus) : base(cus)
        {
            _bookService = bookService;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public JsonResult BuildList(DataTablesViewModel dataTable)
        {
            Expression<Func<Book, dynamic>> GetOrdering()
            {
                switch (dataTable.SingleOrderColumn)
                {
                    //case 1: (see default)
                    case 2: return _ => _.Title;
                    case 3: return _ => _.Author;
                    default: return _ => _.Id;
                }
            }

            BookViewModel[] GetViewModels()
            {
                var books = _bookService.GetBooksForUser(_currentUserService.CurrentDomainUser);
                var filteredBooks = ApplyFilters(books, dataTable);
                var ordering = GetOrdering();
                filteredBooks = dataTable.SingleOrder.IsAscending ? filteredBooks.OrderBy(ordering) : filteredBooks.OrderByDescending(ordering);
                filteredBooks = filteredBooks.Skip(dataTable.start).Take(dataTable.length);

                var bookViewModels = filteredBooks.Select(b => new BookViewModel(b));
                return bookViewModels.ToArray();
            }

            var viewModels = GetViewModels();

            return Json(new
            {
                dataTable.draw,
                recordsTotal = viewModels.Length,
                recordsFiltered = viewModels.Length,
                data = viewModels
            });
        }

        private IQueryable<Book> ApplyFilters(IQueryable<Book> books, DataTablesViewModel dataTable)
        {
            if (!string.IsNullOrWhiteSpace(dataTable.search?.value))
            {
                var searchTerm = dataTable.search.value.ToLower();
                books = books.Where(b => 
                    b.Author.ToLower().Contains(searchTerm)
                    || b.Title.ToLower().Contains(searchTerm)
                );

            }
            return books;
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

            var domainUser = _currentUserService.CurrentDomainUser;
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
