using DacsOnline.Model.Utilities.Interfaces;
using System;

namespace DacsOnline.Model.Manager.Interfaces
{
	public interface IBaseManager
	{
		IEventLogService EventLogService
		{
			get;
			set;
		}
	}
}