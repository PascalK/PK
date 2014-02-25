using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PK.Common;
using System.Globalization;

namespace PK.Settings
{
    /// <summary>
    /// Defines setting types for settings with different types and contains generic logic for nullable types
    /// </summary>
    /// <typeparam name="TSettingValue">The type of the value of a setting</typeparam>
    public class SettingTypeNullable<TSettingValue> : SettingType<Nullable<TSettingValue>>
        where TSettingValue : struct
    {
        /// <summary>
        /// Initializes a new instance of the SettingType class with the ParseFrom and ParseTo functions.
        /// </summary>
        /// <remarks>Null checks are provided by the class so the Parse methods do not have to provide them</remarks>
        /// <param name="parseToFunction">The function to convert from a string to a TSettingValue</param>
        /// <param name="parseFromFunction">The function to convert from a TSettingValue to a string</param>
        public SettingTypeNullable(Func<string, TSettingValue> parseToFunction, Func<TSettingValue, string> parseFromFunction)
            : base(
                value => string.IsNullOrEmpty(value) ? new Nullable<TSettingValue>() : parseToFunction(value),
                value => value.HasValue ? parseFromFunction(value.Value) : null) { }
    }
    /// <summary>
    /// Defines setting types for settings with different types
    /// </summary>
    /// <typeparam name="TSettingValue">The type of the value of a setting</typeparam>
    public class SettingType<TSettingValue> : Enumerated<SettingType<TSettingValue>, Type>
    {
        private Func<string, TSettingValue> parseTo;
        private Func<TSettingValue, string> parseFrom;
        /// <summary>
        /// Initializes a new instance of the SettingType class with the ParseFrom and ParseTo functions
        /// </summary>
        /// <param name="parseToFunction">The function to convert from a string to a TSettingValue</param>
        /// <param name="parseFromFunction">The function to convert from a TSettingValue to a string</param>
        public SettingType(
            Func<string, TSettingValue> parseToFunction,
            Func<TSettingValue, string> parseFromFunction)
            : base(typeof(TSettingValue))
        {
            if (parseToFunction == null) throw new ArgumentNullException("parseToFunction");
            if (parseFromFunction == null) throw new ArgumentNullException("parseFromFunction");

            parseTo = parseToFunction;
            parseFrom = parseFromFunction;
        }
        
        /// <summary>
        /// Gets the SettingType instance which corresponds with the specified type TSettingValue
        /// </summary>
        /// <returns>The SettingType instance for TSettingValue</returns>
        public static SettingType<TSettingValue> Get()
        {
            return Get(typeof(TSettingValue));
        }

        /// <summary>
        /// Parses the value from a string to a TSettingValue
        /// </summary>
        /// <param name="valueToParse">The string to parse to a settingValue</param>
        /// <returns>The string parsed as a settingValue</returns>
        public TSettingValue ParseTo(string valueToParse)
        {
            return parseTo(valueToParse);
        }

        /// <summary>
        /// Parses the value from a TSettingValue to a string
        /// </summary>
        /// <param name="settingValue">The value of the setting to parse to a string</param>
        /// <returns>The settingValue parsed as a string</returns>
        public string ParseFrom(TSettingValue settingValue)
        {
            return parseFrom(settingValue);
        }

        /// <summary>
        /// The SettingType for settings with a value of type <see cref="DateTime"/>
        /// </summary>
        public static SettingType<DateTime> DateTime = new SettingType<DateTime>(
            value => System.DateTime.Parse(value, CultureInfo.InvariantCulture),
            value => value.ToString(CultureInfo.InvariantCulture));
        /// <summary>
        /// The SettingType for settings with a value of type <see cref="int"/>
        /// </summary>
        public static SettingType<int> Int = new SettingType<int>(
            value => int.Parse(value, CultureInfo.InvariantCulture),
            value => value.ToString(CultureInfo.InvariantCulture));
        /// <summary>
        /// The SettingType for settings with a value of type <see cref="T:byte[]"/>
        /// </summary>
        /// <remarks>Binary setting with UTF16 / Unicode encoding</remarks>
        public static SettingType<byte[]> Binary = new SettingType<byte[]>(
            value => string.IsNullOrEmpty(value) ? null : Encoding.Unicode.GetBytes(value),
            value => value != null ? Encoding.Unicode.GetString(value, 0, value.Length) : null);
        /// <summary>
        /// The SettingType for settings with a value of type <see cref="string"/>
        /// </summary>
        public static SettingType<string> Text = new SettingType<string>(
            value => value,
            value => value);
        
        /// <summary>
        /// The SettingType for settings with a value of type <see cref="Nullable{DateTime}"/>
        /// </summary>
        public static SettingType<DateTime?> DateTimeNullable = new SettingTypeNullable<DateTime>(
            DateTime.ParseTo,
            DateTime.ParseFrom);
        /// <summary>
        /// The SettingType for settings with a value of type <see cref="Nullable{Int32}"/>
        /// </summary>
        public static SettingType<int?> IntNullable = new SettingTypeNullable<int>(
            Int.ParseTo,
            Int.ParseFrom);
    }
}