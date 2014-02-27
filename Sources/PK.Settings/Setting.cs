using System;
using System.Diagnostics.Contracts;

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
            Contract.Requires<ArgumentNullException>(key != null, "key");

            Key = key;
        }
    }
}
