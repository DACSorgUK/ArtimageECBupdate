using DacsOnline.Model.Enums;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Presentation.Views;
using DacsOnline.Service.Service.Interfaces;
using System;
using WebFormsMvp;

namespace DacsOnline.Presentation.Presenters
{
	public class RoyaltyCalculatorPresenter : BasePresenter<IRoyaltyCalculatorView>, IDisposable
	{
		private ICalculatorService _service;

		public RoyaltyCalculatorPresenter(IRoyaltyCalculatorView view, ICalculatorService service) : base(view)
		{
			base.View.LoadForm += new EventHandler(this.LoadForm);
			base.View.CalculateRoyalty += new EventHandler(this.CalculateRoyalties);
			this._service = service;
		}

		private void CalculateRoyalties(object sender, EventArgs e)
		{
			try
			{
				base.View.ShowPrice(this._service.GetPrice(DateTime.Parse(base.View.SaleDate), base.View.currency, base.View.price).ToString(), base.View.currency, this._service.SalePriceEuro(base.View.price, base.View.currency, DateTime.Parse(base.View.SaleDate)).ToString(), this._service.SalePriceGBP(base.View.price, base.View.currency, DateTime.Parse(base.View.SaleDate)).ToString());
				base.View.GetExchangeryEuro(this._service.GetExchangeEuro(DateTime.Parse(base.View.SaleDate)).ToString());
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "RoyaltyCalculatorPresenter", exception.Message);
			}
		}

		public void Dispose()
		{
			base.View.LoadForm -= new EventHandler(this.LoadForm);
			base.View.CalculateRoyalty -= new EventHandler(this.CalculateRoyalties);
		}

		private void LoadForm(object sender, EventArgs e)
		{
			try
			{
				base.View.Display(this._service.GetListCurrency());
				base.View.DefaultDate();
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "RoyaltyCalculatorPresenter", exception.Message);
			}
		}
	}
}