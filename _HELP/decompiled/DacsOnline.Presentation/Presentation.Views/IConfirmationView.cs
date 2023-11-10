using System;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
	public interface IConfirmationView : IView
	{
		string Email
		{
			get;
		}

		string FormName
		{
			get;
		}

		int Iduser
		{
			get;
		}

		string Title
		{
			get;
		}

		void Display(string nameform, string refe, string useremail, string dacsemail);

		event EventHandler LoadForm;
	}
}