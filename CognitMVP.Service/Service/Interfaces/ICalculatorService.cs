using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacsOnline.Service.Service.Interfaces
{
    public interface ICalculatorService : IBaseService
    {
        /// <summary>
        /// Gets the rate.
        /// </summary>
        /// <param name="datetime">The datetime.</param>
        /// <returns></returns>
        string GetRate(DateTime datetime);
        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <param name="saleprice">The saleprice.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        string GetPrice(DateTime saleprice, string currency, decimal price);
        /// <summary>
        /// Gets the list currency.
        /// </summary>
        /// <returns></returns>
        List<string> GetListCurrency();
        /// <summary>
        /// Gets the exchange euro.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        string GetExchangeEuro(DateTime date);
        /// <summary>
        /// Sales the price euro.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        string SalePriceEuro(decimal price, string currency, DateTime date);
        /// <summary>
        /// Sales the price GBP.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        string SalePriceGBP(decimal price, string currency, DateTime date);

    }
}
