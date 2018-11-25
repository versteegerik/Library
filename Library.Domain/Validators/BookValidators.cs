using FluentValidation;
using Library.Domain.Requests;

namespace Library.Domain.Validators
{
    public class CreateBookValidators : AbstractValidator<CreateBookRequest>
    {
        public CreateBookValidators()
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
