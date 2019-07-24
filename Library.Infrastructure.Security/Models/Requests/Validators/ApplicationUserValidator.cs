using FluentValidation;

namespace Library.Infrastructure.Security.Models.Requests.Validators
{
    public class CreateApplicationUserRequestValidator : AbstractValidator<CreateApplicationUserRequest>
    {
        public CreateApplicationUserRequestValidator()
        {
            RuleFor(r => r.UserName).NotEmpty();
            RuleFor(r => r.Email).NotEmpty();
            RuleFor(r => r.Password).NotEmpty();
        }
    }

    public class EditApplicationUserRequestValidator : AbstractValidator<EditApplicationUserRequest>
    {
        public EditApplicationUserRequestValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.Email).NotEmpty();
        }
    }
}
