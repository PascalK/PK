using System;
using System.Linq.Expressions;
using System.Reflection;

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
            if (propertySelector == null) throw new ArgumentNullException("propertySelector");
            if (!(propertySelector.Body is MemberExpression)) throw new ArgumentException("propertySelector is not a member expression");

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