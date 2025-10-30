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
            var destName = GetPropertyName(destinationProperty);
            var srcName = GetPropertyName(sourceProperty);

            if (control.DataBindings[destName] != null)
            {
                control.DataBindings.Remove(control.DataBindings[destName]);
            }

            control.DataBindings.Add(destName, source, srcName, false, DataSourceUpdateMode.OnPropertyChanged);
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
