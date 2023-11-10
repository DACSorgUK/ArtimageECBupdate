using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Utilities.Interfaces;
using CMS.EventLog;
using DacsOnline.Model.Enums;


namespace DacsOnline.Model.Utilities
{
    public class NullLogger : IEventLogService
    {
        #region //Public Methods
        public void LogData(MessageType type,string description,string error)
        {
            var eventLogProvider = new EventLogProvider();
            string errorType = string.Empty;
            switch (type)
            {
                case MessageType.Error:
                    errorType = "E";
                    break;
                default:
                    errorType = "I";
                    break;
            }
            eventLogProvider.LogEvent(errorType, DateTime.Now, description, error);
        }
        #endregion
    }
}
