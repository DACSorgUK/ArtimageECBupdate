using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Utilities.Interfaces;

namespace DacsOnline.Service.Service.Interfaces
{
    public interface IBaseService
    {
        #region //Properties
        /// <summary>
        /// Gets or sets the event log service.
        /// </summary>
        /// <value>
        /// The event log service.
        /// </value>
        IEventLogService EventLogService { get; set; }
        #endregion
    }
}
