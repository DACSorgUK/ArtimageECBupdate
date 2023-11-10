using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacsOnline.Model.Manager.Interfaces
{

    public interface ICalculatorManager
    {

        #region properties
       

        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <param name="date">The date where we want to get the rate</param>
        /// <param name="currency">The currency: €,£</param>
        /// <param name="price">The price of the sale</param>
        /// <returns></returns>
        string GetPrice( DateTime date, string currency, decimal price);

        /// <summary>
        /// Gets the exchange euro.
        /// </summary>
        /// <param name="date">The date where we want to get the rate</param>
        /// <returns></returns>
        decimal GetExchangeEuro(DateTime date);

        /// <summary>
        /// Sales the price GBP.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        string SalePriceGBP(decimal price, string currency, DateTime date);
        /// <summary>
        /// Sales the price euro.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        string SalePriceEuro(decimal price, string currency, DateTime date);

        #endregion
    }
}
