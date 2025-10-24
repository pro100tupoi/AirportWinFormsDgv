using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AirportWinFormsDgv
{
    public static class Extensions
    {
        public static void AddBinding<TControl, TSource>(this TControl control,
            Expression<Func<TControl, object>> destinationProperty,
            TSource source,
            Expression<Func<TSource, object>> sourceProperty,
            ErrorProvider? errorProvider = null
            )
            where TControl : Control
            where TSource : class
        {
            var destProName = GetPropertyName(destinationProperty);
            var sourceProName = GetPropertyName(sourceProperty);
            var binding = new Binding(destProName, source, sourceProName);
            control.DataBindings.Add(destProName, source, sourceProName);

            if (errorProvider != null)
            {
                var context = new ValidationContext(source);
                var results = new List<ValidationResult>();
                if (!Validator.TryValidateObject(source, context, results, true))
                {
                    var propError = results.FirstOrDefault(x => x.MemberNames.Contains(sourceProName));
                    if (propError != null)
                    {
                        errorProvider.SetError(control, "error");
                    }
                }
                else
                {
                    errorProvider.SetError(control, string.Empty);
                }
            }
        }

        static string GetPropertyName<TType>(Expression<Func<TType, object>> expression)
        {
            Expression body = expression.Body;
            if (body.NodeType == ExpressionType.Convert)
            {
                body = ((UnaryExpression)body).Operand;
            }

            if (body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            throw new ArgumentException("Expression must be a property access.", nameof(expression));
        }
    }
}
