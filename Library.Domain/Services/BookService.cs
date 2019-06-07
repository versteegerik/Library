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

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            return await BookRepository.FindAsync<Book>(id);
        }

        public async Task<IEnumerable<Book>> GetBooksForUserAsync(ClaimsPrincipal currentPrincipal)
        {
            var user = await BookRepository.FindUserByClaimsPrincipalAsync(currentPrincipal);
            return BookRepository.GetBooksByUser(user);
        }

        public async Task CreateBookAsync(CreateBookRequest request, ClaimsPrincipal currentPrincipal)
        {
            if (!new CreateBookRequestValidator().Validate(request).IsValid)
            {
                throw new Exception("CreateBook validation error");
            }

            var owner = await BookRepository.FindUserByClaimsPrincipalAsync(currentPrincipal);
            var book = new Book(request, owner);

            BookRepository.Add(book);
            BookRepository.SaveChanges();
        }

        public async Task EditBook(EditBookRequest request)
        {
            if (!new EditBookRequestValidator().Validate(request).IsValid)
            {
                throw new Exception("EditBook validation error");
            }

            var book = await GetBookByIdAsync(request.Id);
            book.Edit(request);

            BookRepository.SaveChanges();
        }

        public async Task Delete(DeleteRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
