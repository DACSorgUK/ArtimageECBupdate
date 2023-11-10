using System;

namespace DacsOnline.Model.Manager.Interfaces
{
	public interface ICalculatorManager
	{
		decimal GetExchangeEuro(DateTime date);

		string GetPrice(DateTime date, string currency, decimal price);

		string SalePriceEuro(decimal price, string currency, DateTime date);

		string SalePriceGBP(decimal price, string currency, DateTime date);
	}
}