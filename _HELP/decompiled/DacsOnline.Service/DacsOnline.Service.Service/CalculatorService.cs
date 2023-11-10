using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Service.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace DacsOnline.Service.Service
{
	public class CalculatorService : BaseService<ICalculatorManager>, ICalculatorService, IBaseService
	{
		private IExchangeManager _exchange;

		private ICalculatorManager _calculatorManager;

		public CalculatorService(ICalculatorManager calculatorManager, IExchangeManager exchange) : base(calculatorManager)
		{
			this._calculatorManager = calculatorManager;
			this._exchange = exchange;
		}

		string DacsOnline.Service.Service.Interfaces.ICalculatorService.SalePriceEuro(decimal price, string currency, DateTime date)
		{
			return this._calculatorManager.SalePriceGBP(price, currency, date);
		}

		string DacsOnline.Service.Service.Interfaces.ICalculatorService.SalePriceGBP(decimal price, string currency, DateTime date)
		{
			return this._calculatorManager.SalePriceEuro(price, currency, date);
		}

		public string GetExchangeEuro(DateTime date)
		{
			decimal num = decimal.Round(this._exchange.GetExchangeEuro(date), 4);
			return num.ToString();
		}

		public List<string> GetListCurrency()
		{
			return new List<string>()
			{
				"GBP: £",
				"EUR: €"
			};
		}

		public string GetPrice(DateTime date, string currency, decimal price)
		{
			return this._calculatorManager.GetPrice(date, currency, price);
		}

		public string GetRate(DateTime date)
		{
			decimal exch = this._exchange.GetExchangeEuro(date);
			decimal re = new decimal(1000) / exch;
			return decimal.Round(re, 2).ToString();
		}
	}
}