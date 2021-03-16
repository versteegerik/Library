using FluentValidation;
using Library.Common.Properties;
using Library.Domain.Requests;

namespace Library.Domain.Validators
{
    public class SearchBookGroupRequestValidator : AbstractValidator<SearchBookGroupRequest>
    {
        public SearchBookGroupRequestValidator()
        {
            RuleFor(_ => _).Must(_ => $"{_.Name}{_.Title}{_.Author}".Length > 1).WithMessage(Resources.SearchBookGroupRequest_RequiredMessage);
        }
    }
    public class CreateBookGroupRequestValidator : AbstractValidator<CreateBookGroupRequest>
    {
        public CreateBookGroupRequestValidator()
        {
            RuleFor(_ => _.Name).NotEmpty();
        }
    }
}
