using DacsOnline.Model.Utilities.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Runtime.CompilerServices;
using WebFormsMvp;

namespace DacsOnline.Presentation.Presenters
{
	public abstract class BasePresenter<TView> : Presenter<TView>
	where TView : class, IView
	{
		[Dependency]
		public IEventLogService EventLogService
		{
			get;
			set;
		}

		public BasePresenter(TView view) : base(view)
		{
		}
	}
}