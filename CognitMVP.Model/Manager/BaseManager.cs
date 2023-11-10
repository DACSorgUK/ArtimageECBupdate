using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.Utilities.Interfaces;
using Microsoft.Practices.Unity;

namespace DacsOnline.Model.Manager
{
    public class BaseManager<TRepository> : IBaseManager
      where TRepository : class
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


        public TRepository Repository { get; private set; }
        #endregion

        #region //Constructor

        protected BaseManager(TRepository repository)
        {
            this.Repository = repository;
        }
        #endregion
    }
}
