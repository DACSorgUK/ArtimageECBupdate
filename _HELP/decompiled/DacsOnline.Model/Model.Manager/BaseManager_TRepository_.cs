using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.Utilities.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Runtime.CompilerServices;

namespace DacsOnline.Model.Manager
{
	public class BaseManager<TRepository> : IBaseManager
	where TRepository : class
	{
		[Dependency]
		public IEventLogService EventLogService
		{
			get;
			set;
		}

		public TRepository Repository
		{
			get;
			private set;
		}

		protected BaseManager(TRepository repository)
		{
			this.Repository = repository;
		}
	}
}