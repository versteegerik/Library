using Library.Domain.Models;
using Library.Domain.Requests;
using Library.Domain.Validators;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using Versteey.Infrastructure.Persistence;

namespace Library.Domain.Services
{
    public class BookService : BasePersonService
    {
        public BookService(IPersistence persistence, IHttpContextAccessor httpContextAccessor) : base(persistence, httpContextAccessor) { }

        public Book GetBookById(Guid id) => Persistence.GetById<Book>(id);

        public IQueryable<Book> GetAllBooks(SearchBookRequest request)
        {
            var query = Persistence.Query<Book>();
            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                query = query.Where(_ => _.Title.Contains(request.Title) || _.AlternativeTitle.Contains(request.Title));
            }
            return query.OrderBy(_ => _.Title);
        }
        public IQueryable<Book> GetOwnedBooks()
        {
            var person = GetCurrentPerson();
            return person.OwnedBooks.AsQueryable().OrderBy(_ => _.Title);
        }
        public IQueryable<BookGenre> GetAllGenres() => Persistence.Query<BookGenre>().OrderBy(_ => _.Code);

        public Guid CreateBook(CreateBookRequest request)
        {
            if (!new CreateBookRequestValidator().Validate(request).IsValid)
            {
                throw new Exception("CreateBook validation error");
            }

            Persistence.BeginTransaction();

            var book = new Book(request);
            Persistence.Create(book);
            Persistence.Commit();
            return book.Id;
        }

        public void UpdateBook(UpdateBookRequest request)
        {
            Persistence.BeginTransaction();
            if (!new UpdateBookRequestValidator().Validate(request).IsValid)
            {
                throw new Exception("UpdateBook validation error");
            }

            var book = GetBookById(request.Id);
            book.Update(request);
            Persistence.Commit();
        }
    }
}
