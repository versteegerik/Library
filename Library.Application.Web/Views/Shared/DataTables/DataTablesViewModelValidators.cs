using System.Collections.Generic;
using System.Linq;

using FluentValidation;
using Library.Application.Web.Properties;

namespace FeedbackApp.Web.Views.Shared.DataTables
{
    public sealed class DataTablesViewModelValidator : AbstractValidator<DataTablesViewModel>
    {
        public DataTablesViewModelValidator()
        {
            RuleForEach(_ => _.order).SetValidator(_ => new OrderValidator(_.columns)).When(_ => _.order.Count > 0);
        }
    }

    public sealed class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator() { } // Needed for ValidationFactory

        public OrderValidator(IEnumerable<Column> columns) : this()
        {
            RuleFor(_ => _.column)
                .Must(column => column >= 0 && column < columns.Count())
                .WithErrorCode(nameof(WebResources.Validation_DataTables_Column_Invalid))
                .WithMessage(_ => string.Format(WebResources.Validation_DataTables_Column_Invalid, _.column));

            void DirRule() => RuleFor(_ => _.dir)
                                  .Must((order, dir) => dir.Equals("asc") || dir.Equals("desc"))
                                  .WithErrorCode(nameof(WebResources.Validation_DataTables_Dir_Invalid))
                                  .WithMessage(_ => string.Format(WebResources.Validation_DataTables_Dir_Invalid, _.column));

            When(_ => !string.IsNullOrEmpty(_.dir), DirRule);
        }
    }
}
