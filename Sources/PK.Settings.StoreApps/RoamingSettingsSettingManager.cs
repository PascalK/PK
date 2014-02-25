using System;
using System.Collections.Generic;
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
            if (ApplicationData.Current == null) throw new ArgumentNullException("ApplicationData.Current");
            if (ApplicationData.Current.RoamingSettings == null) throw new ArgumentNullException("ApplicationData.Current.RoamingSettings");
            if (ApplicationData.Current.RoamingSettings.Values == null) throw new ArgumentNullException("ApplicationData.Current.RoamingSettings.Values");
        }
        /// <summary>
        /// Initializes a new instance of the RoamingSettingsSettingLoader class with a IPropertySet as a setting source
        /// </summary>
        /// <param name="settingSource">The source of the settings</param>
        public RoamingSettingsSettingManager(IPropertySet settingSource)
            : base(settingSource)
        {
            if (settingSource == null) throw new ArgumentNullException("settingSource");
        }
    }
}
