using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;

namespace PK.Settings.StoreApps
{
    /// <summary>
    /// A SettingManager which uses a <see cref="IPropertySet"/>
    /// </summary>
    public class PropertySetSettingManager : ISettingManager
    {
        #region Dependencies

        /// <summary>
        /// The values used as a source for the settings managed by this class
        /// </summary>
        protected readonly IPropertySet settingValues;

        #endregion
        /// <summary>
        /// Initializes a new instance of the PropertySetSettingLoader class with the IPropertySet as a setting source
        /// </summary>
        /// <param name="settingSource">The IPropertySet which will be used as a source for the settings</param>
        public PropertySetSettingManager(IPropertySet settingSource)
        {
            if (settingSource == null) throw new ArgumentNullException("settingSource");

            settingValues = settingSource;
        }
        /// <summary>
        /// Gets a setting with the specified key
        /// </summary>
        /// <typeparam name="TSettingValue">The type of the value of a setting</typeparam>
        /// <param name="key">The key of the setting in the IPropertSet</param>
        /// <returns>The setting with the requested key</returns>
        public ISetting<TSettingValue> Get<TSettingValue>(string key)
        {
            if (key == null) throw new ArgumentNullException("key");

            object localSetting;
            SettingType<TSettingValue> settingType;

            settingValues.TryGetValue(key, out localSetting);
            if (localSetting != null)
            {
                settingType = SettingType<TSettingValue>.Get();
                return new Setting<TSettingValue>(key)
                {
                    Value = settingType.ParseTo(localSetting.ToString()),
                    Type = settingType,
                };
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
        /// <param name="key">The key of the setting in the IPropertySet</param>
        /// <param name="value">The value of the setting</param>
        public void Set<TSettingValue>(string key, TSettingValue value)
        {
            if (key == null) throw new ArgumentNullException("key");

            SettingType<TSettingValue> settingType;

            settingType = SettingType<TSettingValue>.Get();

            settingValues[key] = settingType.ParseFrom(value);
        }
        /// <summary>
        /// Sets the value of the setting with the specified key
        /// </summary>
        /// <typeparam name="TSettingValue">The type of the value of a setting</typeparam>
        /// <param name="setting">The setting which will be changed</param>
        public void Set<TSettingValue>(ISetting<TSettingValue> setting)
        {
            if (setting == null) throw new ArgumentNullException("setting");

            Set(setting.Key, setting.Value);
        }
    }
}
