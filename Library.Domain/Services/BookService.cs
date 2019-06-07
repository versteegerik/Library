using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Library.Domain.Model;
using Library.Domain.Repositories;
using Library.Domain.Requests;
using Library.Domain.Validators;

namespace Library.Domain.Services
{
    public class BookService
    {
        public BookRepository BookRepository { get; }

        public BookService(BookRepository bookRepository)
        {
            BookRepository = bookRepository;
        }

        public async Task<Book> GetBookById(Guid id)
        {
            return await BookRepository.FindAsync<Book>(id);
        }

        public IEnumerable<Book> GetMyBooks(ApplicationUser applicationUser)
        {
            return BookRepository.GetBooksByUser(applicationUser);
        }

        public async Task CreateBookAsync(CreateBookRequest request, ClaimsPrincipal currentPrincipal)
        {
            if (!new CreateBookRequestValidator().Validate(request).IsValid)
            {
                throw new Exception("CreateBook validation error");
            }

            var owner = await BookRepository.FindUserByClaimsPrincipalAsync(currentPrincipal);
            var book = new Book(request, owner);
        }

        public void EditBook(EditBookRequest request)
        {
            throw new NotImplementedException();
        }

        public void Delete(DeleteRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
