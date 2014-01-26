using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace PK.Common.Reflection
{
    /// <summary>
    /// Contains static methods for retrieving propertyInfo from an <see cref="Object"/>
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Retrieves the PropertyInfo of a MemberExpression which represents a property
        /// </summary>
        /// <typeparam name="T">The type of the object which contains the property</typeparam>
        /// <typeparam name="Tvalue">The return type of the property</typeparam>
        /// <param name="object">An instance of T to get the PropertyInfo from</param>
        /// <param name="propertySelector">An MemberExpression which represents the property</param>
        /// <returns></returns>
        public static PropertyInfo GetPropertyInfo<T, Tvalue>(this T @object, Expression<Func<T, Tvalue>> propertySelector)
        {
            Contract.Requires<ArgumentNullException>(propertySelector != null, "propertySelector");
            Contract.Requires<ArgumentException>(propertySelector.Body is MemberExpression, "propertySelector is not a member expression");

            MemberExpression expression;

            expression = (MemberExpression)propertySelector.Body;
            if (expression.Member is PropertyInfo)
            {
                PropertyInfo foundPropertyInfo;

                foundPropertyInfo = (PropertyInfo)expression.Member;

                return foundPropertyInfo;
            }
            else
            {
                throw new ArgumentException("propertySelector does not represent a property", "propertySelector");
            }
        }
    }
}