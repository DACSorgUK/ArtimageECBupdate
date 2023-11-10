using DacsOnline.Model.Enums;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Presentation.Views;
using DacsOnline.Service.Service.Interfaces;
using System;
using WebFormsMvp;

namespace DacsOnline.Presentation.Presenters
{
	public class CountrySelectorPresenter : BasePresenter<ICountrySelectorView>, IDisposable
	{
		private ICountrySelectorService _iCountrySelectorService;

		public CountrySelectorPresenter(ICountrySelectorView view, ICountrySelectorService iCountrySelectorService) : base(view)
		{
			base.View.LoadForm += new EventHandler(this.LoadForm);
			this._iCountrySelectorService = iCountrySelectorService;
		}

		public void Dispose()
		{
			base.View.LoadForm -= new EventHandler(this.LoadForm);
		}

		private void LoadForm(object sender, EventArgs e)
		{
			try
			{
				base.View.BindCountry(this._iCountrySelectorService.GetCountries());
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "CountrySelectorPresenter", exception.Message);
			}
		}
	}
}