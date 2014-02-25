using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PK.Settings
{
    /// <summary>
    /// Interface which represents a single setting
    /// </summary>
    /// <typeparam name="TSettingValue">The type of the value of the setting</typeparam>
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
}