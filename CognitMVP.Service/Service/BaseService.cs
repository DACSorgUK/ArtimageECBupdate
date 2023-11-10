using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Service.Service.Interfaces;
using Microsoft.Practices.Unity;


namespace DacsOnline.Service.Service
{
    public abstract class BaseService<TManager> : IBaseService
    where TManager : class
    {
        #region //Public Properties

        /// <summary>
        /// Gets or sets the event log service.
        /// </summary>
        /// <value>
        /// The event log service.
        /// </value>
        [Dependency]
        public IEventLogService EventLogService { get; set; }

        /// <summary>
        /// Gets or sets the service manager.
        /// </summary>
        /// <value>The service manager.</value>
        public TManager ServiceManager { get; private set; }
        #endregion

        #region //Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService&lt;TManager&gt;"/> class.
        /// </summary>
        /// <param name="serviceManager">The service manager.</param>
        protected BaseService(TManager serviceManager)
        {
            this.ServiceManager = serviceManager;
        }
        #endregion
    }
}
