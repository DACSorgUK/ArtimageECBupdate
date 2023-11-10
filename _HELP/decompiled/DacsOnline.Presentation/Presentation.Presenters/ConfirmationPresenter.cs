using DacsOnline.Model.Enums;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Presentation.Views;
using System;
using WebFormsMvp;

namespace DacsOnline.Presentation.Presenters
{
	public class ConfirmationPresenter : BasePresenter<IConfirmationView>, IDisposable
	{
		public ConfirmationPresenter(IConfirmationView view) : base(view)
		{
			base.View.LoadForm += new EventHandler(this.LoadForm);
		}

		public void Dispose()
		{
			base.View.LoadForm -= new EventHandler(this.LoadForm);
		}

		private void LoadForm(object sender, EventArgs e)
		{
			try
			{
				base.View.Display(base.View.Title, string.Concat(base.View.FormName, "-", base.View.Iduser), base.View.Email, "dacs@dacs.org.uk");
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "ConfirmationPresenter", exception.Message);
			}
		}
	}
}