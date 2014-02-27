using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PK.Application.Web
{
    /// <summary>
    /// Base class for using PK.Application with web applications
    /// </summary>
    /// <remarks>
    /// To use this, let the Global.asax class inherit from this
    /// </remarks>
    /// <typeparam name="TApplication">The <see cref="ApplicationBase"/> type used for this application</typeparam>
    public abstract class WebApplicationBase<TApplication> : HttpApplication
        where TApplication : ApplicationBase, new()
    {
        #region Dependencies

        /// <summary>
        /// The TApplication instance for this application
        /// </summary>
        public new TApplication Application { get; private set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the WebApplicationBase class
        /// </summary>
        public WebApplicationBase()
        {
            Application = InitializeApplication();
        }
        /// <summary>
        /// Initialized a new instance of TApplication
        /// </summary>
        /// <returns></returns>
        protected virtual TApplication InitializeApplication()
        {
            Contract.Ensures(Contract.Result<TApplication>() != null);

            return new TApplication();
        }
        /// <summary>
        /// Handles the Application_Error "event" of a standard HttpApplication class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Application_Error(object sender, EventArgs e)
        {
            Application.OnError();
        }
        /// <summary>
        /// Executes custom initialization code after all event handler modules have been added.
        /// </summary>
        public override void Init()
        {
            base.Init();
            Application.OnInitialize();
        }
        /// <summary>
        /// Executes custom start code
        /// </summary>
        /// <param name="sender">The objects from which the event originated</param>
        /// <param name="e">The arguments of the event</param>
        protected virtual void Application_Start(object sender, EventArgs e)
        {
            Application.OnStart();
        }
        /// <summary>
        /// Executes custom end code
        /// </summary>
        /// <param name="sender">The objects from which the event originated</param>
        /// <param name="e">The arguments of the event</param>
        protected virtual void Application_End(object sender, EventArgs e)
        {
            Application.OnEnd();
        }
    }
}