using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.Storage;

namespace PK.Settings.StoreApps
{
    /// <summary>
    /// Specific <see cref="PropertySetSettingManager"/> using the current RoamingSettings by default
    /// </summary>
    public class RoamingSettingsSettingManager : PropertySetSettingManager
    {
        /// <summary>
        /// Initializes a new instance of the RoamingSettingsSettingLoader class with the current RoamingSettings as a setting source
        /// </summary>
        public RoamingSettingsSettingManager()
            : this(ApplicationData.Current.RoamingSettings.Values)
        {
            Contract.Requires<ArgumentNullException>(ApplicationData.Current != null, "ApplicationData.Current");
            Contract.Requires<ArgumentNullException>(ApplicationData.Current.RoamingSettings != null, "ApplicationData.Current.RoamingSettings");
            Contract.Requires<ArgumentNullException>(ApplicationData.Current.RoamingSettings.Values != null, "ApplicationData.Current.RoamingSettings.Values");
        }
        /// <summary>
        /// Initializes a new instance of the RoamingSettingsSettingLoader class with a IPropertySet as a setting source
        /// </summary>
        /// <param name="settingSource">The source of the settings</param>
        public RoamingSettingsSettingManager(IPropertySet settingSource)
            : base(settingSource)
        {
            Contract.Requires<ArgumentNullException>(settingSource != null, "settingSource");
        }
    }
}
