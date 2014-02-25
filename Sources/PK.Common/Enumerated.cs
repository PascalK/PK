using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace PK.Common
{
    /// <summary>
    /// Base class for an enumerated type, this implements a generic descriptor pattern
    /// </summary>
    /// <typeparam name="TEnumerated">The type that is enumerated</typeparam>
    /// <typeparam name="TValue">The value of the enumerated type</typeparam>
    [DataContract]
    public abstract class Enumerated<TEnumerated, TValue> : IEnumerated<TEnumerated, TValue>
        where TEnumerated : class, IEnumerated<TEnumerated, TValue>
    {
        /// <summary>
        /// The value of the enumerated type
        /// </summary>
        /// <remarks>
        /// Usually this will be an identifier of the enumerated type
        /// </remarks>
        [DataMember]
        public virtual TValue Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Enumerated class with a value indicated by a TValue
        /// </summary>
        /// <param name="value">The value if the enumerated instance to create</param>
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
            //TODO: Performance
            foreach (FieldInfo field in typeof(TEnumerated).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                if (field.FieldType == typeof(TEnumerated))
                {
                    yield return (TEnumerated)field.GetValue(typeof(TEnumerated));
                }
            }
        }
        /// <summary>
        /// Gets the enumerated item with the specified value
        /// </summary>
        /// <param name="value">The value of the enumerated to get</param>
        /// <returns>The enumerated item with the specified value</returns>
        /// <exception cref="InvalidOperationException">If no enumerated item with the specified value exists</exception>
        public static TEnumerated Get(TValue value)
        {
            TEnumerated foundValue;

            foundValue = GetOrDefault(value);
            if (foundValue != null)
            {
                return foundValue;
            }
            else
            {
                throw new InvalidOperationException(
                    string.Format("No '{0}' found with value '{1}'",
                        typeof(TEnumerated).Name,
                        value != null ? value.ToString() : "NULL"));
            }
        }
        /// <summary>
        /// Gets the only enumerated item with the specified value or a default value if none exists
        /// </summary>
        /// <param name="value">The value of the enumerated to get</param>
        /// <returns>The enumerated item with the specified value or null if none exists</returns>
        public static TEnumerated GetOrDefault(TValue value)
        {
            if (value != null)
            {
                return (from codeListItem in GetAll()
                        where codeListItem.Value.Equals(value)
                        select codeListItem).SingleOrDefault();
            }
            else
            {
                return (from codeListItem in GetAll()
                        where codeListItem.Value == null
                        select codeListItem).SingleOrDefault();
            }
        }
    }
}
