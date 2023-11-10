using System;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
	public interface INewsLetterSignUpView : IView
	{
		string EmailAddress
		{
			get;
		}

		string FirstName
		{
			get;
		}

		string LastName
		{
			get;
		}

		void SingUp(bool result);

		event EventHandler ClickButton;
	}
}