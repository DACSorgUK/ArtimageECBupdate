using DacsOnline.Model.Manager.Interfaces;
using System;
using System.Globalization;

namespace DacsOnline.Model.Manager
{
	public class CalculatorManager : ICalculatorManager
	{
		private IExchangeManager _exchange;

		public CalculatorManager(IExchangeManager exchange)
		{
			this._exchange = exchange;
		}

		public decimal GetExchangeEuro(DateTime date)
		{
			return this._exchange.GetExchangeEuro(date);
		}

		public string GetPrice(DateTime date, string currency, decimal price)
		{
			string str;
			decimal resultFinal = new decimal(0);
			decimal salepriceEuros = this.GetPriceEuro(date, currency, price);
			if (!(salepriceEuros < new decimal(0)))
			{
				if (salepriceEuros < new decimal(1000))
				{
					resultFinal = new decimal(0);
				}
				else if (!(salepriceEuros <= new decimal(0) ? true : !(salepriceEuros <= new decimal(5000000, 0, 0, false, 2))))
				{
					resultFinal = this.Percent(salepriceEuros, new decimal(4));
				}
				else if (!(salepriceEuros <= new decimal(5000001, 0, 0, false, 2) ? true : !(salepriceEuros <= new decimal(20000000, 0, 0, false, 2))))
				{
					resultFinal = this.Percent(new decimal(5000000, 0, 0, false, 2), new decimal(4)) + this.Percent(salepriceEuros - new decimal(5000000, 0, 0, false, 2), new decimal(3));
				}
				else if (!(salepriceEuros <= new decimal(20000001, 0, 0, false, 2) ? true : !(salepriceEuros <= new decimal(35000000, 0, 0, false, 2))))
				{
					resultFinal = (this.Percent(new decimal(5000000, 0, 0, false, 2), new decimal(4)) + this.Percent(new decimal(15000000, 0, 0, false, 2), new decimal(3))) + this.Percent(salepriceEuros - new decimal(20000000, 0, 0, false, 2), new decimal(1));
				}
				else if (!(salepriceEuros <= new decimal(35000001, 0, 0, false, 2) ? true : !(salepriceEuros <= new decimal(50000000, 0, 0, false, 2))))
				{
					resultFinal = ((this.Percent(new decimal(5000000, 0, 0, false, 2), new decimal(4)) + this.Percent(new decimal(15000000, 0, 0, false, 2), new decimal(3))) + this.Percent(new decimal(15000000, 0, 0, false, 2), new decimal(1))) + this.Percent(salepriceEuros - new decimal(35000000, 0, 0, false, 2), new decimal(5, 0, 0, false, 1));
				}
				else if (salepriceEuros > new decimal(50000001, 0, 0, false, 2))
				{
					resultFinal = (((this.Percent(new decimal(5000000, 0, 0, false, 2), new decimal(4)) + this.Percent(new decimal(15000000, 0, 0, false, 2), new decimal(3))) + this.Percent(new decimal(150000), new decimal(1))) + this.Percent(new decimal(15000000, 0, 0, false, 2), new decimal(5, 0, 0, false, 1))) + this.Percent(salepriceEuros - new decimal(50000000, 0, 0, false, 2), new decimal(25, 0, 0, false, 2));
				}
				if (resultFinal >= new decimal(12500))
				{
					resultFinal = new decimal(12500);
				}
				if (currency == "GBP")
				{
					resultFinal = resultFinal / this._exchange.GetExchangeEuro(date);
				}
				decimal solu = decimal.Round(resultFinal, 2);
				str = solu.ToString("N", CultureInfo.InvariantCulture);
			}
			else
			{
				str = "-1.00";
			}
			return str;
		}

		public decimal GetPriceEuro(DateTime date, string currency, decimal price)
		{
			decimal rate = new decimal(0);
			decimal salepriceEuros = new decimal(0);
			if (currency == "Euro")
			{
				salepriceEuros = price;
			}
			else if (!(currency == "GBP"))
			{
				rate = this._exchange.GetExchangeEuro(date);
				salepriceEuros = price * rate;
			}
			else
			{
				rate = this._exchange.GetExchangeEuro(date);
				salepriceEuros = price * rate;
			}
			return salepriceEuros;
		}

		private decimal GetRate(DateTime dateTime)
		{
			return this._exchange.GetExchangeEuro(dateTime);
		}

		public decimal GetRateThreshold(DateTime date)
		{
			return this._exchange.GetExchangeEuro(date);
		}

		private decimal Percent(decimal price, decimal percent)
		{
			return (price * percent) / new decimal(100);
		}

		public string SalePriceEuro(decimal price, string currency, DateTime date)
		{
			decimal solu;
			string str;
			decimal rate = new decimal(0);
			decimal result = new decimal(0);
			if (!(currency == "Euro"))
			{
				if (!(currency == "GBP"))
				{
					rate = this._exchange.GetExchangeEuro(date);
					result = price * rate;
				}
				else
				{
					rate = this._exchange.GetExchangeEuro(date);
					result = price * rate;
				}
				solu = decimal.Round(result, 2);
				str = solu.ToString("N", CultureInfo.InvariantCulture);
			}
			else
			{
				solu = decimal.Round(price, 2);
				str = solu.ToString("N", CultureInfo.InvariantCulture);
			}
			return str;
		}

		public string SalePriceGBP(decimal price, string currency, DateTime date)
		{
			decimal solu;
			string str;
			decimal rate = new decimal(0);
			decimal result = new decimal(0);
			if (!(currency == "GBP"))
			{
				if (!(currency == "Euro"))
				{
					rate = this._exchange.GetExchangeGBP(date);
					result = price * rate;
				}
				else
				{
					rate = this._exchange.GetExchangeGBP(date);
					result = price * rate;
				}
				solu = decimal.Round(result, 2);
				str = solu.ToString("N", CultureInfo.InvariantCulture);
			}
			else
			{
				solu = decimal.Round(price, 2);
				str = solu.ToString("N", CultureInfo.InvariantCulture);
			}
			return str;
		}
	}
}