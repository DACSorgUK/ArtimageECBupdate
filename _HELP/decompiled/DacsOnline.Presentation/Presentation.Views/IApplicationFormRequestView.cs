using System;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
	public interface IApplicationFormRequestView : IView
	{
		string Address
		{
			get;
		}

		string AdministratorEmail
		{
			get;
		}

		string FormName
		{
			get;
		}

		string Telephone
		{
			get;
		}

		void Display();

		event EventHandler Onclick;

		event EventHandler OnLoad;
	}
}