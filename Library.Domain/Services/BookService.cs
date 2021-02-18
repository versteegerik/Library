using Library.Domain.Models;
using Library.Domain.Requests;
using Library.Domain.Validators;
using System;
using System.Linq;
using Versteey.Infrastructure.Persistence;

namespace Library.Domain.Services
{
    public class BookService : BaseService
    {
        public BookService(IPersistence persistence) : base(persistence) { }

        public Book GetBookById(Guid id)
        {
            return Persistence.GetById<Book>(id);
        }

        public IQueryable<Book> GetAllBooks() => Persistence.Query<Book>().OrderBy(_ => _.Title);

        public Guid CreateBook(CreateBookRequest request)
        {
            Persistence.BeginTransaction();
            if (!new CreateBookRequestValidator().Validate(request).IsValid)
            {
                throw new Exception("CreateBook validation error");
            }

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
