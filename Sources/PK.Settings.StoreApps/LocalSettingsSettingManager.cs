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
    /// /// Specific <see cref="PropertySetSettingManager"/> using the current LocalSettings by default
    /// </summary>
    public class LocalSettingsSettingManager : PropertySetSettingManager
    {
        /// <summary>
        /// Initializes a new instance of the RoamingSettingsSettingLoader class with the LocalSettings as a setting source
        /// </summary>
        public LocalSettingsSettingManager()
            : this(ApplicationData.Current.LocalSettings.Values) 
        {
            if (ApplicationData.Current == null) throw new ArgumentNullException("ApplicationData.Current");
            if (ApplicationData.Current.LocalSettings == null) throw new ArgumentNullException("ApplicationData.Current.LocalSettings");
            if (ApplicationData.Current.LocalSettings.Values == null) throw new ArgumentNullException("ApplicationData.Current.LocalSettings.Values");
        }
        /// <summary>
        /// Initializes a new instance of the RoamingSettingsSettingLoader class with a IPropertySet as a setting source
        /// </summary>
        /// <param name="settingSource">The source of the settings</param>
        public LocalSettingsSettingManager(IPropertySet settingSource)
            : base(settingSource)
        {
            if (settingSource == null) throw new ArgumentNullException("settingSource");
        }
    }
}
