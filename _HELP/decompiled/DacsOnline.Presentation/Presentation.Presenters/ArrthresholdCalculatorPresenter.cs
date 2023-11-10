using DacsOnline.Model.Enums;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Presentation.Views;
using DacsOnline.Service.Service.Interfaces;
using System;
using WebFormsMvp;

namespace DacsOnline.Presentation.Presenters
{
	public class ArrthresholdCalculatorPresenter : BasePresenter<IThresholdCalculatorView>, IDisposable
	{
		private ICalculatorService _service;

		public ArrthresholdCalculatorPresenter(IThresholdCalculatorView view, ICalculatorService service) : base(view)
		{
			base.View.LoadForm += new EventHandler(this.LoadForm);
			base.View.CalculateThreshold += new EventHandler(this.CalculateThreshold);
			this._service = service;
		}

		private void CalculateThreshold(object sender, EventArgs e)
		{
			try
			{
				base.View.ShowPrice(this._service.GetRate(DateTime.Parse(base.View.Date)));
				base.View.ShowDate();
				base.View.ExchangeEuro(this._service.GetExchangeEuro(DateTime.Parse(base.View.Date)).ToString());
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "ArrthresholdCalculatorPresenter", exception.Message);
			}
		}

		public void Dispose()
		{
			base.View.LoadForm -= new EventHandler(this.LoadForm);
			base.View.CalculateThreshold -= new EventHandler(this.CalculateThreshold);
		}

		private void LoadForm(object sender, EventArgs e)
		{
			try
			{
				base.View.DefaultDate();
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "ArrthresholdCalculatorPresenter", exception.Message);
			}
		}
	}
}