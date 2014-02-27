using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PK.Settings;
using System.Diagnostics.Contracts;

namespace PK.Settings.AppSettings
{
    /// <summary>
    /// A SettingManager which uses the <see cref="ConfigurationManager.AppSettings"/>
    /// </summary>
    public class AppSettingsSettingManager : ISettingManager
    {
        /// <summary>
        /// Gets a setting with the specified key
        /// </summary>
        /// <typeparam name="TSettingValue">The type of the value of a setting</typeparam>
        /// <param name="key">The key of the setting in the config file</param>
        /// <returns>The setting with the requested key</returns>
        public ISetting<TSettingValue> Get<TSettingValue>(string key)
        {
            ISetting<TSettingValue> setting;
            SettingType<TSettingValue> settingType;

            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
            {
                settingType = SettingType<TSettingValue>.Get();
                setting = new Setting<TSettingValue>(key)
                {
                    Type = settingType,
                    Value = settingType.ParseTo(ConfigurationManager.AppSettings[key]),
                };

                return setting;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Sets the value of the setting with the specified key
        /// </summary>
        /// <typeparam name="TSettingValue">The type of the value of a setting</typeparam>
        /// <param name="key">The key of the setting in the config file</param>
        /// <param name="value">The value of the setting</param>
        public void Set<TSettingValue>(string key, TSettingValue value)
        {
            SettingType<TSettingValue> settingType;

            settingType = SettingType<TSettingValue>.Get();
            ConfigurationManager.AppSettings[key] = settingType.ParseFrom(value);
        }
        /// <summary>
        /// Sets the value of the setting with the specified key
        /// </summary>
        /// <typeparam name="TSettingValue">The type of the value of a setting</typeparam>
        /// <param name="setting">The setting which will be changed</param>
        public void Set<TSettingValue>(ISetting<TSettingValue> setting)
        {
            Set(setting.Key, setting.Value);
        }
    }
}