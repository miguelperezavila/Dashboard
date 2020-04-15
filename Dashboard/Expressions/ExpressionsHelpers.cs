
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Dashboard
{
    /// <summary>
    /// A helper for expressions
    /// </summary>
    public static class ExpressionsHelpers
    {
        /// <summary>
        /// Compiles an expression and gets the function return value
        /// </summary>
        /// <typeparam name="T">The type of return value</typeparam>
        /// <param name="lambda">The expression to compile</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }

        /// <summary>
        /// Sets the underlying properties value to the given value
        /// from an expression that contains the propery
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lambda"></param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value )
        {
            //  Converts a lambda () => some.property to some.property
            var expression = (lambda as LambdaExpression).Body as MemberExpression;

            // Get the property information so we can set it

            var propertyInfo = (PropertyInfo)expression.Member;

            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            // set the property value
            propertyInfo.SetValue(target, value);
        }
            

    }
}
