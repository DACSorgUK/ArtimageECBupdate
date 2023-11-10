using DacsOnline.Model.Utilities.Interfaces;
using System;

namespace DacsOnline.Service.Service.Interfaces
{
	public interface IBaseService
	{
		IEventLogService EventLogService
		{
			get;
			set;
		}
	}
}