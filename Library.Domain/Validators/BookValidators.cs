using FluentValidation;
using Library.Domain.Requests;

namespace Library.Domain.Validators
{
    public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
    {
        public CreateBookRequestValidator()
        {
            RuleFor(r => r.Title)
                .NotEmpty();
            RuleFor(r => r.Author)
                .NotEmpty();
            RuleFor(r => r.Owner)
                .NotEmpty();
        }
    }
}
