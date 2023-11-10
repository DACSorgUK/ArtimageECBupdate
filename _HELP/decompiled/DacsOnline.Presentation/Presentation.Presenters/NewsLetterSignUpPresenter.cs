using DacsOnline.Model.Adadpters;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Presentation.Views;
using System;
using WebFormsMvp;

namespace DacsOnline.Presentation.Presenters
{
	public class NewsLetterSignUpPresenter : BasePresenter<INewsLetterSignUpView>, IDisposable
	{
		public NewsLetterSignUpPresenter(INewsLetterSignUpView view) : base(view)
		{
			base.View.ClickButton += new EventHandler(this.Clikbutton);
		}

		private void Clikbutton(object sender, EventArgs e)
		{
			try
			{
				base.View.SingUp(this.SingUp(base.View.FirstName, base.View.LastName, base.View.EmailAddress));
			}
			catch (Exception exception)
			{
			}
		}

		public void Dispose()
		{
			base.View.ClickButton -= new EventHandler(this.Clikbutton);
		}

		private bool SingUp(string firstname, string lastname, string email)
		{
			return (new MailChimpAdapter()).SubscribeUser(email, "HTML", firstname, lastname);
		}
	}
}