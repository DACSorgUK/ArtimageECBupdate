using System;
using System.Collections.Generic;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
	public interface IDocumentListView : IView
	{
		void Display(List<string> list);

		event EventHandler LoadData;
	}
}