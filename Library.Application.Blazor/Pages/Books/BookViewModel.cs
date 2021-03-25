using FluentValidation;
using Library.Domain.Models;
using Library.Domain.Requests;
using Library.Domain.Validators;
using System;

namespace Library.Application.Blazor.Pages.Books
{
    public class CreateBookViewModel : CreateBookRequest
    {
        public Guid AuthorId { get; set; }
    }
    public class CreateBookViewModelValidator : AbstractValidator<CreateBookViewModel>
    {
        public CreateBookViewModelValidator()
        {
            RuleFor(x => x).SetValidator(new CreateBookRequestValidator());
        }
    }

    public class UpdateBookViewModel : UpdateBookRequest
    {
        public Guid AuthorId { get; set; }

        public UpdateBookViewModel(Book book) : base (book)
        {
            AuthorId = book.Author.Id;
        }
    }
    public class UpdateBookViewModelValidator : AbstractValidator<UpdateBookViewModel>
    {
        public UpdateBookViewModelValidator()
        {
            RuleFor(x => x).SetValidator(new UpdateBookRequestValidator());
        }
    }

}
