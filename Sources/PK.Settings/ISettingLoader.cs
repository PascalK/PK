using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace PK.Settings
{
    /// <summary>
    /// Defines methods for loading settings
    /// </summary>
    [ContractClass(typeof(SettingLoaderContract))]
    public interface ISettingLoader
    {
        /// <summary>
        /// Gets a setting of a specified type with a specified key
        /// </summary>
        /// <typeparam name="TSetting">The type of the value of the setting</typeparam>
        /// <param name="key">The key of the setting</param>
        /// <returns>A setting corresponding with the specified key</returns>
        ISetting<TSetting> Get<TSetting>(string key);
    }
#pragma warning disable 1591
    [ContractClassFor(typeof(ISettingLoader))]
    abstract class SettingLoaderContract : ISettingLoader
    {
        ISetting<TSetting> ISettingLoader.Get<TSetting>(string key)
        {
            Contract.Requires<ArgumentNullException>(key != null, "key");

            return Contract.Result<ISetting<TSetting>>();
        }
    }
#pragma warning restore 1591
}