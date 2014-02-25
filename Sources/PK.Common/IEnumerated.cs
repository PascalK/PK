namespace PK.Common
{
    /// <summary>
    /// A generic interface for an enumerated type
    /// </summary>
    /// <typeparam name="TEnumerated">The type that is enumerated</typeparam>
    /// <typeparam name="TValue">The value of the enumerated type</typeparam>
    public interface IEnumerated<TEnumerated, TValue>
        where TEnumerated : class, IEnumerated<TEnumerated, TValue>
    {
        /// <summary>
        /// The value of the enumerated type
        /// </summary>
        /// <remarks>
        /// Usually this will be an identifier of the enumerated type
        /// </remarks>
        TValue Value { get; }
    }
}
