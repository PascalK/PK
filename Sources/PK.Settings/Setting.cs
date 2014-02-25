using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PK.Settings
{
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
        /// <summary>
        /// The value of the setting
        /// </summary>
        public TSettingValue Value { get; set; }
        /// <summary>
        /// Initializes a new instance of the Setting class with the key
        /// </summary>
        /// <param name="key">The key which identifies the setting</param>
        public Setting(string key)
        {
            if (key == null) throw new ArgumentNullException("key");

            Key = key;
        }
    }
}
