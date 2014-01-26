using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace PK.Application
{
    /// <summary>
    /// Extension of <see cref="IApplication"/> with application wide settings
    /// </summary>
    /// <typeparam name="TSettings"></typeparam>
    [ContractClass(typeof(ApplicationContract<>))]
    public interface IApplication<TSettings> : IApplication
    {
        /// <summary>
        /// Application wide settings
        /// </summary>
        TSettings Settings { get; }
    }
    /// <summary>
    /// A base interface containing functions for various application wide functions
    /// </summary>
    [ContractClass(typeof(ApplicationContract))]
    public interface IApplication
    {
        /// <summary>
        /// Function which, when implemented, is called when the application is initializing
        /// </summary>
        void OnInitialize();
        /// <summary>
        /// Function which, when implemented, is called when the application is starting
        /// </summary>
        void OnStart();
        /// <summary>
        /// Function which, when implemented, is called when the application is ending / closing
        /// </summary>
        void OnEnd();
        /// <summary>
        /// Function which, when implemented, is called when the application throws an unhandled error
        /// </summary>
        void OnError();
    }

#pragma warning disable 1591
    [ContractClassFor(typeof(IApplication))]
    abstract class ApplicationContract : IApplication
    {
        void IApplication.OnInitialize() { }
        void IApplication.OnStart() { }
        void IApplication.OnEnd() { }
        void IApplication.OnError() { }
    }
    [ContractClassFor(typeof(IApplication<>))]
    abstract class ApplicationContract<TSettings> : IApplication<TSettings>
    {
        TSettings IApplication<TSettings>.Settings
        {
            get
            {
                Contract.Ensures(Contract.Result<TSettings>() != null);
                return default(TSettings);
            }
        }
        void IApplication.OnInitialize() { }
        void IApplication.OnStart() { }
        void IApplication.OnEnd() { }
        void IApplication.OnError() { }
    }
#pragma warning restore 1591
}