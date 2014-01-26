using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace PK.Settings
{
    /// <summary>
    /// Defines methods for changing settings
    /// </summary>
    [ContractClass(typeof(SettingChangerContract))]
    public interface ISettingChanger
    {
        /// <summary>
        /// Changes a setting with a specified key
        /// </summary>
        /// <typeparam name="TSettingValue">The type of the value of the setting</typeparam>
        /// <param name="key">The key of the setting</param>
        /// <param name="value">The value of the setting</param>
        void Set<TSettingValue>(string key, TSettingValue value);
        /// <summary>
        /// Changes the setting
        /// </summary>
        /// <typeparam name="TSettingValue">The type of the value of the setting</typeparam>
        /// <param name="setting">The setting which will be changes</param>
        void Set<TSettingValue>(ISetting<TSettingValue> setting);
    }
#pragma warning disable 1591
    [ContractClassFor(typeof(ISettingChanger))]
    abstract class SettingChangerContract : ISettingChanger
    {
        void ISettingChanger.Set<TSettingValue>(string key, TSettingValue value)
        {
            Contract.Requires<ArgumentNullException>(key != null, "key");
        }

        void ISettingChanger.Set<TSettingValue>(ISetting<TSettingValue> setting)
        {
            Contract.Requires<ArgumentNullException>(setting != null, "setting");
        }
    }
#pragma warning restore 1591
}