using Library.Domain.Common;
using Library.Domain.Models;
using Library.Domain.Models.Requests;
using Library.Domain.Models.Requests.Validators;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.Domain.Services
{
    public class BookService
    {
        private readonly IDomainPersistence Persistence;

        public BookService(IDomainPersistence persistence)
        {
            Persistence = persistence;
        }

        public Book GetBookById(Guid id)
        {
            return Persistence.Books.Single(_ => _.Id == id);
        }

        public void CreateBook(CreateBookRequest request, DomainUser owner)
        {
            if (!new CreateBookRequestValidator().Validate(request).IsValid)
            {
                throw new Exception("CreateBook validation error");
            }

            var book = new Book(request, owner);

            Persistence.Create(book);
        }

        public void UpdateBook(UpdateBookRequest request)
        {
            if (!new UpdateBookRequestValidator().Validate(request).IsValid)
            {
                throw new Exception("EditBook validation error");
            }

            var book = GetBookById(request.Id);
            book.Update(request);

            Persistence.Update(book);
        }

        public void DeleteBook(DeleteBookRequest request)
        {
            if (!new DeleteBookRequestValidator().Validate(request).IsValid)
            {
                throw new Exception("DeleteBook validation error");
            }

            var book = GetBookById(request.Id);

            Persistence.Delete(book);
        }
    }
}
