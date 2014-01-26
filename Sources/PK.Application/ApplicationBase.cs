using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PK.Application
{
    /// <summary>
    /// A default class implementing <see cref="IApplication"/>
    /// </summary>
    public abstract class ApplicationBase : IApplication
    {
        /// <summary>
        /// Function which is called when the application is initializing
        /// </summary>
        public virtual void OnInitialize() { }
        /// <summary>
        /// Function which is called when the application is starting
        /// </summary>
        public virtual void OnStart() { }
        /// <summary>
        /// Function which is called when the application is ending / closing
        /// </summary>
        public virtual void OnEnd() { }
        /// <summary>
        /// Function which is called when the application throws an unhandled error
        /// </summary>
        public virtual void OnError() { }
    }
}