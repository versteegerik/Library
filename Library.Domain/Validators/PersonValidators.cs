using FluentValidation;
using Library.Domain.Requests;

namespace Library.Domain.Validators
{
    public class CreatePersonValidator : AbstractValidator<CreatePersonRequest>
    {
        public CreatePersonValidator()
        {
            RuleFor(r => r.LastName)
                .NotEmpty();
        }
    }
}
