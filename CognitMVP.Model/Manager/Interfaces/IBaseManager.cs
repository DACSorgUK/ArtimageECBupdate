using DacsOnline.Model.Utilities.Interfaces;

namespace DacsOnline.Model.Manager.Interfaces
{
    public interface IBaseManager
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
