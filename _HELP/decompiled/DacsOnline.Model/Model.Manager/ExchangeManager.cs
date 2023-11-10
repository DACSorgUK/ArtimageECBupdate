using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.RepostioriesInterfaces;
using System;

namespace DacsOnline.Model.Manager
{
	public class ExchangeManager : IExchangeManager
	{
		private IExchangeRepository _exchangeRepository;

		public ExchangeManager(IExchangeRepository exchangeRepository)
		{
			this._exchangeRepository = exchangeRepository;
		}

		public decimal GetExchangeEuro(DateTime dateTime)
		{
			decimal num;
			try
			{
				decimal re = decimal.Divide(new decimal(1), this._exchangeRepository.GetExchangeGBP(dateTime));
				num = decimal.Round(re, 4);
			}
			catch (Exception exception)
			{
				num = new decimal(0);
			}
			return num;
		}

		public decimal GetExchangeGBP(DateTime dateTime)
		{
			return this._exchangeRepository.GetExchangeGBP(dateTime);
		}
	}
}