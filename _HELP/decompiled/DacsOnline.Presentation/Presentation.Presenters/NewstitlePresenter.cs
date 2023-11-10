using DacsOnline.Model.Enums;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Presentation.Views;
using System;
using WebFormsMvp;

namespace DacsOnline.Presentation.Presenters
{
	public class NewstitlePresenter : BasePresenter<INewsTitleView>, IDisposable
	{
		public NewstitlePresenter(INewsTitleView view) : base(view)
		{
			base.View.Load += new EventHandler(this.OnLoad);
		}

		public void Dispose()
		{
			base.View.Load -= new EventHandler(this.OnLoad);
		}

		private void OnLoad(object sender, EventArgs e)
		{
			try
			{
				base.View.Showtitle();
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "NewstitlePresenter", exception.Message);
			}
		}
	}
}