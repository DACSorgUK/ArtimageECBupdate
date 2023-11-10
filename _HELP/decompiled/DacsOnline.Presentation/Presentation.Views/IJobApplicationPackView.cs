using System;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
	public interface IJobApplicationPackView : IView
	{
		string downloadjob
		{
			get;
		}

		string EmailDacs
		{
			get;
		}

		string EmailUser
		{
			get;
		}

		string jobTitle
		{
			get;
		}

		void Display();

		void HideConfirmation();

		void HideSubmit();

		void ShowConfirmation();

		void ShowSubmit();

		event EventHandler OnclickLink;

		event EventHandler OnclickSubmit;

		event EventHandler OnLoad;
	}
}