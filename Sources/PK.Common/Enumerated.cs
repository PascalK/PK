using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PK.Common
{
    /// <summary>
    /// Base class which implements a generic descriptor pattern
    /// </summary>
    /// <typeparam name="TEnumerated">Type to descibe</typeparam>
    /// <typeparam name="TValue">Type of the value part of the type to describe</typeparam>
    public abstract class Enumerated<TEnumerated, TValue> : IEnumerated<TEnumerated, TValue>
        where TEnumerated : class, IEnumerated<TEnumerated, TValue>
    {
        public virtual TValue Value { get; private set; }

        public Enumerated(TValue value)
        {
            Value = value;
        }

        /// <summary>
        /// Get all defined enumerated items
        /// </summary>
        /// <returns>All defined enumerated items</returns>
        public static IEnumerable<TEnumerated> GetAll()
        {
            foreach (FieldInfo field in typeof(TEnumerated).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                yield return (TEnumerated)field.GetValue(typeof(TEnumerated));
            }
        }
        /// <summary>
        /// Gets the enumerated item with the specified value
        /// </summary>
        /// <param name="value">The value of the enumerated to get</param>
        /// <returns>The enumerated item with the specified value</returns>
        /// <remarks>Returns null when the specified value is null</remarks>
        public static TEnumerated Get(TValue value)
        {
            if (value != null)
            {
                return (from codeListItem in GetAll()
                        where codeListItem.Value.Equals(value)
                        select codeListItem).Single();
            }
            else
            {
                return (from codeListItem in GetAll()
                        where codeListItem.Value == null
                        select codeListItem).Single();
            }
        }
    }
}
