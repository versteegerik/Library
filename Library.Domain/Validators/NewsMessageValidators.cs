using FluentValidation;
using Library.Domain.Requests;

namespace Library.Domain.Validators
{
    public class CreateNewsMessageRequestValidator : AbstractValidator<CreateNewsMessageRequest>
    {
        public CreateNewsMessageRequestValidator()
        {
            RuleFor(r => r.Title).NotEmpty();
            RuleFor(r => r.Message).NotEmpty();
            RuleFor(r => r.IsShown).NotEmpty();
        }
    }

    public class EditNewsMessageRequestValidator : AbstractValidator<EditNewsMessageRequest>
    {
        public EditNewsMessageRequestValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.Title).NotEmpty();
            RuleFor(r => r.Message).NotEmpty();
            RuleFor(r => r.IsShown).NotEmpty();
        }
    }
}
