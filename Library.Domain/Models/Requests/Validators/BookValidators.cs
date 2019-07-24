using FluentValidation;

namespace Library.Domain.Models.Requests.Validators
{
    public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
    {
        public CreateBookRequestValidator()
        {
            RuleFor(r => r.Title).NotEmpty();
            RuleFor(r => r.Author).NotEmpty();
        }
    }

    public class UpdateBookRequestValidator : AbstractValidator<UpdateBookRequest>
    {
        public UpdateBookRequestValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.Title).NotEmpty();
            RuleFor(r => r.Author).NotEmpty();
        }
    }
    public class DeleteBookRequestValidator : AbstractValidator<DeleteBookRequest>
    {
        public DeleteBookRequestValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
        }
    }
}
