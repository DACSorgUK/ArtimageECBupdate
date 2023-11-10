using CMS.EventLog;
using DacsOnline.Model.Enums;
using DacsOnline.Model.Utilities.Interfaces;
using System;

namespace DacsOnline.Model.Utilities
{
	public class NullLogger : IEventLogService
	{
		public NullLogger()
		{
		}

		public void LogData(MessageType type, string description, string error)
		{
			EventLogProvider eventLogProvider = new EventLogProvider();
			string errorType = string.Empty;
			errorType = (type == MessageType.Error ? "E" : "I");
			eventLogProvider.LogEvent(errorType, DateTime.Now, description, error);
		}
	}
}