using Library.Domain.Common;
using Library.Domain.Models;
using Library.Domain.Models.Requests;
using Library.Domain.Models.Requests.Validators;
using System;
using System.Linq;

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

        public IQueryable<Book> GetAllBooks()
        {
            return Persistence.Books
                .OrderBy(_ => _.Title);
        }

        public IQueryable<Book> GetBooksForUser(DomainUser currentDomainUser)
        {
            return Persistence.DomainUsers
                .Single(d => d.Id == currentDomainUser.Id)
                .UserBookInformations
                .Where(ubi => !ubi.OnWishlist)
                .Select(ubi => ubi.Book)
                .OrderBy(_ => _.Title)
                .AsQueryable();
        }

        public IQueryable<Book> GetBookWishlistForUser(DomainUser currentDomainUser)
        {
            return Persistence.DomainUsers
                .Single(d => d.Id == currentDomainUser.Id)
                .UserBookInformations
                .Where(ubi => ubi.OnWishlist)
                .Select(ubi => ubi.Book)
                .OrderBy(_ => _.Title)
                .AsQueryable();
        }

        public void CreateBook(CreateBookRequest request, DomainUser domainUser)
        {
            if (!new CreateBookRequestValidator().Validate(request).IsValid)
            {
                throw new Exception("CreateBook validation error");
            }

            var book = new Book(request);
            Persistence.Create(book);

            if (request.AddToWishlist || request.AddToMyBooks)
            {
                var ubi = new UserBookInformation(book, request.AddToWishlist);
                domainUser.UserBookInformations.Add(ubi);
                Persistence.Update(domainUser);
            }
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
