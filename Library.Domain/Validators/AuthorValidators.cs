using FluentValidation;
using Library.Domain.Requests;

namespace Library.Domain.Validators
{
    public class CreateAuthorRequestValidator : AbstractValidator<CreateAuthorRequest>
    {
        public CreateAuthorRequestValidator()
        {
            RuleFor(r => r.LastName).NotEmpty();
        }
    }
    public class UpdateAuthorRequestValidator : AbstractValidator<UpdateAuthorRequest>
    {
        public UpdateAuthorRequestValidator()
        {
            RuleFor(r => r.LastName).NotEmpty();
        }
    }
}
