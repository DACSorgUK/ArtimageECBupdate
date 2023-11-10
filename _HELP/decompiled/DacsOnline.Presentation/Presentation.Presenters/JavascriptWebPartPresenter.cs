using DacsOnline.Presentation.Views;
using System;
using WebFormsMvp;

namespace DacsOnline.Presentation.Presenters
{
	public class JavascriptWebPartPresenter : BasePresenter<IJavascriptWebPartView>, IDisposable
	{
		public JavascriptWebPartPresenter(IJavascriptWebPartView view) : base(view)
		{
			base.View.LoadForm += new EventHandler(this.LoadForm);
		}

		public void Dispose()
		{
			base.View.LoadForm -= new EventHandler(this.LoadForm);
		}

		private void LoadForm(object sender, EventArgs e)
		{
			try
			{
				base.View.Display();
			}
			catch (Exception exception)
			{
			}
		}
	}
}