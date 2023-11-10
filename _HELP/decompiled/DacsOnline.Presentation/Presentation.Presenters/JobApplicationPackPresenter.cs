using DacsOnline.Model.Enums;
using DacsOnline.Model.Utilities;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Presentation.Views;
using System;
using WebFormsMvp;

namespace DacsOnline.Presentation.Presenters
{
	public class JobApplicationPackPresenter : BasePresenter<IJobApplicationPackView>, IDisposable
	{
		public JobApplicationPackPresenter(IJobApplicationPackView view) : base(view)
		{
			base.View.OnclickLink += new EventHandler(this.OnLink);
			base.View.OnclickSubmit += new EventHandler(this.OnSubmit);
			base.View.OnLoad += new EventHandler(this.Load);
		}

		public void Dispose()
		{
			base.View.OnclickLink -= new EventHandler(this.OnLink);
			base.View.OnclickSubmit -= new EventHandler(this.OnSubmit);
			base.View.OnLoad -= new EventHandler(this.Load);
		}

		private void Load(object sender, EventArgs e)
		{
			try
			{
				base.View.Display();
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "HowApplyPresenter", exception.Message);
			}
		}

		private void OnLink(object sender, EventArgs e)
		{
			try
			{
				base.View.ShowSubmit();
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "HowApplyPresenter", exception.Message);
			}
		}

		private void OnSubmit(object sender, EventArgs e)
		{
			try
			{
				this.SendEmail(base.View.EmailUser, base.View.jobTitle);
				base.View.ShowConfirmation();
				base.View.HideSubmit();
			}
			catch (Exception exception)
			{
				Exception ex = exception;
				base.View.HideConfirmation();
				base.EventLogService.LogData(MessageType.Error, "HowApplyPresenter", ex.Message);
			}
		}

		private void SendEmail(string address, string jobTitle)
		{
			string[,] replacement = new string[2, 2];
			replacement[0, 0] = "email";
			replacement[0, 1] = address;
			replacement[1, 0] = "jobtitle";
			replacement[1, 1] = jobTitle;
			SendEmail.SendEmailUsingTemplate("DACS_ApplyJob", address, replacement);
		}
	}
}