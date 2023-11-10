using DacsOnline.Model.Enums;
using DacsOnline.Model.Utilities;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Presentation.Views;
using System;
using WebFormsMvp;

namespace DacsOnline.Presentation.Presenters
{
	public class ApplicationFormRequestPresenter : BasePresenter<IApplicationFormRequestView>, IDisposable
	{
		public ApplicationFormRequestPresenter(IApplicationFormRequestView view) : base(view)
		{
			base.View.Onclick += new EventHandler(this.Onclick);
			base.View.OnLoad += new EventHandler(this.Load);
		}

		public void Dispose()
		{
			base.View.Onclick -= new EventHandler(this.Onclick);
		}

		private void Load(object sender, EventArgs e)
		{
			try
			{
				base.View.Display();
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "ApplicationFormPresenter", exception.Message);
			}
		}

		private void Onclick(object sender, EventArgs e)
		{
			try
			{
				this.SendEmail(base.View.Address, base.View.FormName);
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "ApplicationFormPresenter", exception.Message);
			}
		}

		private void SendEmail(string address, string FormName)
		{
			string[,] replacements = new string[2, 2];
			replacements[0, 0] = "Address";
			replacements[0, 1] = address;
			replacements[1, 0] = "FormName";
			replacements[1, 1] = FormName;
			SendEmail.SendEmailUsingTemplate("DACSOnline_PostApplicationForm", base.View.AdministratorEmail, replacements);
		}
	}
}