using System;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
	public interface IJavascriptWebPartView : IView
	{
		string themes
		{
			get;
		}

		void Display();

		event EventHandler LoadForm;
	}
}