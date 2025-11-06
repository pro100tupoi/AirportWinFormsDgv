using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AirportWinFormsDgv
{
    /// <summary>
    /// Методы расширения для упрощения привязки данных
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Привязывает свойство контрола к свойству источника данных
        /// </summary>
        /// <typeparam name="TControl">Тип элемента управления (должен наследоваться от <see cref="Control"/>).</typeparam>
        /// <typeparam name="TSource">Тип источника данных (должен быть ссылочным типом).</typeparam>
        /// <param name="control">Элемент управления, к которому применяется привязка.</param>
        /// <param name="destinationProperty">Лямбда-выражение, указывающее свойство элемента управления.</param>
        /// <param name="source">Объект-источник данных.</param>
        /// <param name="sourceProperty">Лямбда-выражение, указывающее свойство источника данных.</param>
        /// <param name="errorProvider">Провайдер отображения ошибок валидации (опционально).</param>
        public static void AddBinding<TControl, TSource>(this TControl control,
            Expression<Func<TControl, object>> destinationProperty,
            TSource source,
            Expression<Func<TSource, object>> sourceProperty,
            ErrorProvider? errorProvider = null
            )
            where TControl : Control
            where TSource : class
        {
            var controlPropName = GetPropertyName(destinationProperty);
            var sourcePropName = GetPropertyName(sourceProperty);

            var existing = control.DataBindings[controlPropName];
            if (existing != null)
            {
                control.DataBindings.Remove(existing);
            }

            var binding = new Binding(controlPropName, source, sourcePropName, true)
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };

            control.DataBindings.Add(binding);

            if (errorProvider != null)
            {
                AddValidation(control, source, sourcePropName, errorProvider);
            }
        }

        private static void AddValidation<TControl, TSource>(
            TControl control,
            TSource source,
            string sourcePropertyName,
            ErrorProvider errorProvider)
            where TControl : Control
            where TSource : class
        {
            var sourcePropertyInfo = source.GetType().GetProperty(sourcePropertyName);
            if (sourcePropertyInfo == null)
            {
                return;
            }

            control.Validating += (_, _) =>
            {
                ValidateControl(control, source, sourcePropertyName, errorProvider);
            };
        }

        private static void ValidateControl<TControl, TSource>(
            TControl control,
            TSource source,
            string sourcePropertyName,
            ErrorProvider errorProvider)
            where TControl : Control
            where TSource : class
        {
            var sourcePropertyInfo = source.GetType().GetProperty(sourcePropertyName);
            if (sourcePropertyInfo == null)
            {
                return;
            }

            var context = new ValidationContext(source) { MemberName = sourcePropertyName };
            var results = new List<ValidationResult>();

            var propertyValue = sourcePropertyInfo.GetValue(source);

            var isValid = Validator.TryValidateProperty(propertyValue, context, results);

            if (!isValid && results.Count > 0)
            {
                var propertyError = results.Where(x => x.MemberNames.Contains(sourcePropertyName));

                errorProvider.SetError(control, propertyError.First().ErrorMessage);
            }
            else
            {
                errorProvider.SetError(control, string.Empty);
            }
        }

        private static string GetPropertyName<TType>(Expression<Func<TType, object>> expression)
        {
            var body = expression.Body;
            if (body.NodeType == ExpressionType.Convert)
            {
                body = ((UnaryExpression)body).Operand;
            }

            if (body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            throw new ArgumentException($"Выражение должно быть доступом к свойству {nameof(expression)}");
        }
    }
}
