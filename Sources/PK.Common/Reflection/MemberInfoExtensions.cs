using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PK.Common.Reflection
{
    /// <summary>
    /// Contains static methods for retrieving custom attributes of <see cref="MemberInfo"/> types
    /// </summary>
    public static class MemberInfoExtensions
    {
        //Only usefull for .Net4. These are added to the .Net 4.5 CLR
        /// <summary>
        /// Retrieves a custom attribute of a specified type that is applied to a specified element, and optionally inspects the ancestors of that element.
        /// </summary>
        /// <remarks>This function is only usefull when targeting .Net 4.0. These functions are added to the .Net 4.5 CLR</remarks>
        /// <typeparam name="TAttribute">The type of attribute to search for</typeparam>
        /// <param name="element">The element to inspect</param>
        /// <param name="inherit">true to inspect the ancestors of element; otherwise, false</param>
        /// <returns>A custom attribute that matches TAttribute, or null if no such attribute is found</returns>
        public static TAttribute GetCustomAttribute<TAttribute>(this MemberInfo element, bool inherit)
            where TAttribute : Attribute
        {
            if (element == null) throw new ArgumentNullException("element");

            return element.GetCustomAttributes<TAttribute>(inherit).SingleOrDefault();
        }
        /// <summary>
        /// Retrieves a custom attribute of a specified type that is applied to a specified member
        /// </summary>
        /// <remarks>This function is only usefull when targeting .Net 4.0. These functions are added to the .Net 4.5 CLR</remarks>
        /// <typeparam name="TAttribute">The type of attribute to search for</typeparam>
        /// <param name="element"> The member to inspect</param>
        /// <returns>A custom attribute that matches T, or null if no such attribute is found</returns>
        public static TAttribute GetCustomAttribute<TAttribute>(this MemberInfo element) 
            where TAttribute : Attribute
        {
            if (element == null) throw new ArgumentNullException("element");

            return element.GetCustomAttribute<TAttribute>(false);
        }
        /// <summary>
        /// Retrieves a collection of custom attributes that are applied to a specified element, and optionally inspects the ancestors of that element.
        /// </summary>
        /// <remarks>This function is only usefull when targeting .Net 4.0. These functions are added to the .Net 4.5 CLR</remarks>
        /// <typeparam name="TAttribute">The type of attribute to search for</typeparam>
        /// <param name="element">The element to inspect</param>
        /// <param name="inherit">true to inspect the ancestors of element; otherwise, false</param>
        /// <returns>A collection of the custom attributes that are applied to element and that match TAttribute, or an empty collection if no such attributes exist</returns>
        public static IEnumerable<TAttribute> GetCustomAttributes<TAttribute>(this MemberInfo element, bool inherit)
            where TAttribute : Attribute
        {
            if (element == null) throw new ArgumentNullException("element");

            return element.GetCustomAttributes(inherit).OfType<TAttribute>().ToArray();
        }
        /// <summary>
        /// Retrieves a collection of custom attributes of a specified type that are applied to a specified member
        /// </summary>
        /// <remarks>This function is only usefull when targeting .Net 4.0. These functions are added to the .Net 4.5 CLR</remarks>
        /// <typeparam name="TAttribute">The type of attribute to search for</typeparam>
        /// <param name="element">The member to inspect</param>
        /// <returns>A collection of the custom attributes that are applied to element and that match T, or an empty collection if no such attributes exist</returns>
        public static IEnumerable<TAttribute> GetCustomAttributes<TAttribute>(this MemberInfo element) 
            where TAttribute : Attribute
        {
            if (element == null) throw new ArgumentNullException("element");

            return element.GetCustomAttributes<TAttribute>(false);
        }
    }
}
