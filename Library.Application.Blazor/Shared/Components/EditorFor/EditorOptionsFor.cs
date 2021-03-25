using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace Library.Application.Blazor.Shared.Components.EditorFor
{
    public abstract class EditorOptionsFor<TValue> : ComponentBase
    {
        [CascadingParameter] private EditContext CascadedEditContext { get; set; }

        private TValue _value;
        [Parameter] public TValue Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (!Equals(_value, value))
                {
                    ValueChanged.InvokeAsync(value);
                }

                _value = value;
            }
        }
        [Parameter] public Expression<Func<TValue>> ValueExpression { get; set; }
        [Parameter] public EventCallback<TValue> ValueChanged { get; set; }

        protected string GetDisplayName()
        {
            var expression = (MemberExpression)ValueExpression.Body;
            var value = expression.Member.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
            return value?.GetName() ?? expression.Member.Name;
        }
    }

    public enum BooleanType
    {
        Checkbox = 0,
        YesNo = 1
    }

    public class EditorOptionsForBoolean : EditorOptionsFor<bool>
    {
        [Parameter] public BooleanType Type { get; set; } = BooleanType.Checkbox;
    }

    public class EditorOptionsForString : EditorOptionsFor<string>
    {
        [Parameter] public bool IsTextArea { get; set; }
    }

}
