using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace PK.Settings
{
    /// <summary>
    /// Interface which represents a single setting
    /// </summary>
    /// <typeparam name="TSettingValue">The type of the value of the setting</typeparam>
    [ContractClass(typeof(ISettingContract<>))]    
    public interface ISetting<TSettingValue>
    {
        /// <summary>
        /// The key which identifies the setting
        /// </summary>
        string Key { get; }
        /// <summary>
        /// The <see cref="SettingType{TSettingValue}"/> for the setting 
        /// </summary>
        SettingType<TSettingValue> Type { get; set; }
        /// <summary>
        /// The value of the setting
        /// </summary>
        TSettingValue Value { get; set; }
    }
    /// <summary>
    /// A basic implementation of a <see cref="ISetting{TSettingValue}"/> interface
    /// </summary>
    /// <typeparam name="TSettingValue"></typeparam>
    public class Setting<TSettingValue> : ISetting<TSettingValue>
    {
        /// <summary>
        /// The key which identifies the setting
        /// </summary>
        public string Key { get; private set; }
        /// <summary>
        /// The <see cref="SettingType{TSettingValue}"/> for the setting 
        /// </summary>
        public SettingType<TSettingValue> Type { get; set; }
        private TSettingValue value;
        /// <summary>
        /// The value of the setting
        /// </summary>
        public TSettingValue Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }
        /// <summary>
        /// Initializes a new instance of the Setting class with the key
        /// </summary>
        /// <param name="key">The key which identifies the setting</param>
        public Setting(string key)
        {
            Key = key;
        }
    }
    [ContractClassFor(typeof(ISetting<>))]
    abstract class ISettingContract<TSettingValue> : ISetting<TSettingValue>
    {
        string ISetting<TSettingValue>.Key
        {
            get 
            {
                Contract.Ensures(Contract.Result<string>() != null);
                return default(string);
            }
        }
        SettingType<TSettingValue> ISetting<TSettingValue>.Type
        {
            get
            {
                return default(SettingType<TSettingValue>);
            }
            set
            {
            }
        }

        TSettingValue ISetting<TSettingValue>.Value
        {
            get
            {
                return default(TSettingValue);
            }
            set
            {
            }
        }
    }
}