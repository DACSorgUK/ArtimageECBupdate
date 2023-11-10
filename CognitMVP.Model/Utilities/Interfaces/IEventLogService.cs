using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Enums;

namespace DacsOnline.Model.Utilities.Interfaces
{
    public interface IEventLogService
    {
        #region //Methods
        /// <summary>
        /// Logs the data.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="description">The description.</param>
        /// <param name="error">The error.</param>
        void LogData(MessageType type, string description, string error);
        #endregion
    }
}
