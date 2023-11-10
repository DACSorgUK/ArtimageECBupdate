using DacsOnline.Model.Enums;
using System;

namespace DacsOnline.Model.Utilities.Interfaces
{
	public interface IEventLogService
	{
		void LogData(MessageType type, string description, string error);
	}
}