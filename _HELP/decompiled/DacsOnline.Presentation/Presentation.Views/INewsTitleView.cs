using System;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
	public interface INewsTitleView : IView
	{
		string Category
		{
			get;
		}

		void Showtitle();

		event EventHandler Load;
	}
}