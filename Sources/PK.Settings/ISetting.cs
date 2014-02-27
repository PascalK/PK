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