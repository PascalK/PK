using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PK.Settings
{
    /// <summary>
    /// Defines methods for loading and changing settings
    /// </summary>
    /// <remarks>Combines <see cref="ISettingLoader"/> and <see cref="ISettingChanger"/></remarks>
    public interface ISettingManager : ISettingLoader, ISettingChanger
    {
    }
}
