using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Service.Service.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Runtime.CompilerServices;

namespace DacsOnline.Service.Service
{
	public abstract class BaseService<TManager> : IBaseService
	where TManager : class
	{
		[Dependency]
		public IEventLogService EventLogService
		{
			get;
			set;
		}

		public TManager ServiceManager
		{
			get;
			private set;
		}

		protected BaseService(TManager serviceManager)
		{
			this.ServiceManager = serviceManager;
		}
	}
}