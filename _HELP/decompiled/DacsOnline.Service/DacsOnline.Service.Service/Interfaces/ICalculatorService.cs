using System;
using System.Collections.Generic;

namespace DacsOnline.Service.Service.Interfaces
{
	public interface ICalculatorService : IBaseService
	{
		string GetExchangeEuro(DateTime date);

		List<string> GetListCurrency();

		string GetPrice(DateTime saleprice, string currency, decimal price);

		string GetRate(DateTime datetime);

		string SalePriceEuro(decimal price, string currency, DateTime date);

		string SalePriceGBP(decimal price, string currency, DateTime date);
	}
}