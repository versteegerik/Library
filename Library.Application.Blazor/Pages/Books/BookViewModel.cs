using Library.Domain.Models;
using Library.Domain.Requests;
using System;

namespace Library.Application.Blazor.Pages.Books
{
    public class CreateBookViewModel : CreateBookRequest
    {
        public Guid AuthorId { get; set; }
    }
    public class UpdateBookViewModel : UpdateBookRequest
    {
        public Guid AuthorId { get; set; }

        public UpdateBookViewModel(Book book) : base (book)
        {
            AuthorId = book.Author.Id;
        }
    }
}
