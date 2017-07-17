using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A helper for expressions
    /// </summary>
    public static class ExpressionHelpers
    {
        /// <summary>
        /// Compiles an expression and get hte functions return value
        /// </summary>
        /// <typeparam name="T">Type of return value</typeparam>
        /// <param name="lambda">expression to compile</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }

        /// <summary>
        /// Sets the underlying property value to the passed in value
        /// </summary>
        /// <typeparam name="T">Type of value to set</typeparam>
        /// <param name="lambda">Expression</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            //coverts a lambda () => some.Property, to some.Property.
            var exp = (lambda as LambdaExpression).Body as MemberExpression;

            //Get the property information
            var propertyInfo = (PropertyInfo)exp.Member;
            var target = Expression.Lambda(exp.Expression).Compile().DynamicInvoke();

            //set the property value
            propertyInfo.SetValue(target, value);
        }
    }
}
