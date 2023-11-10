using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.Utilities;
using System.Globalization;


namespace DacsOnline.Model.Manager
{
    public class CalculatorManager : ICalculatorManager
    {
        #region private properties
        /// <summary>
        /// To get the exchange
        /// </summary>
        private IExchangeManager _exchange;

        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorManager"/> class.
        /// </summary>
        /// <param name="exchange">The exchange.</param>
        public CalculatorManager(IExchangeManager exchange)
            : base()
        {
            _exchange = exchange;

        }
        #endregion


        #region public methods
        /// <summary>
        /// Get the rate in a datetime
        /// </summary>
        /// <param name="date"></param>
        /// <returns>rate</returns>
        public decimal GetRateThreshold(DateTime date)
        {

            return (_exchange.GetExchangeEuro(date));
        }

        /// <summary>
        /// Gets the exchange euro.
        /// </summary>
        /// <param name="date">The date where we want to get the rate</param>
        /// <returns></returns>
        public decimal GetExchangeEuro(DateTime date)
        {
            return (_exchange.GetExchangeEuro(date));
        }


        /// <summary>
        /// Gets the price euro.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        public decimal GetPriceEuro(DateTime date, string currency, decimal price)
        {
            //Check if its euro or pound
            decimal rate = 0;
            decimal salepriceEuros = 0;

            if (currency == "Euro")
            {
                salepriceEuros = price;
            }
            else if (currency == "GBP")
            {
                rate = _exchange.GetExchangeEuro(date);
                salepriceEuros = price * rate;
            }
            else //default pounds
            {
                rate = _exchange.GetExchangeEuro(date);
                salepriceEuros = price * rate;
            }
            return salepriceEuros;

        }

        /// <summary>
        /// Calculate the royalty for a datetime
        /// </summary>
        /// <param name="status"></param>
        /// <param name="date"></param>
        /// <param name="currency"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public string GetPrice(DateTime date, string currency, decimal price)
        {
            decimal resultFinal = 0;
            decimal salepriceEuros = GetPriceEuro(date, currency, price);

            if (salepriceEuros < 0)
                return "-1.00";
              //Minimun eligibility
            if (salepriceEuros < ConstantData.MinElegibility)
                resultFinal = 0;
            else
            {
                if (salepriceEuros > ConstantData.interval0 && salepriceEuros <= ConstantData.interval50000)
                {
                    resultFinal = Percent(salepriceEuros, ConstantData.Percent4);
                }
                else if (salepriceEuros > ConstantData.interval50001 && salepriceEuros <= ConstantData.interval200000)
                {
                    resultFinal = Percent(ConstantData.interval50000, ConstantData.Percent4) + Percent(salepriceEuros - ConstantData.interval50000, ConstantData.Percent3);
                }

                else if (salepriceEuros > ConstantData.interval200001 && salepriceEuros <= ConstantData.interval350000)
                {

                    resultFinal = Percent(ConstantData.interval50000, ConstantData.Percent4) + Percent(ConstantData.interval200000 - ConstantData.interval50000, ConstantData.Percent3) + Percent(salepriceEuros - ConstantData.interval200000, ConstantData.Percent1);
                }
                else if (salepriceEuros > ConstantData.interval350001 && salepriceEuros <= ConstantData.interval500000)
                {

                    resultFinal = Percent(ConstantData.interval50000, ConstantData.Percent4) + Percent(ConstantData.interval200000 - ConstantData.interval50000, ConstantData.Percent3) + Percent(ConstantData.interval350000 - ConstantData.interval200000, ConstantData.Percent1) + Percent(salepriceEuros - ConstantData.interval350000, ConstantData.Percent05);

                }
                else if (salepriceEuros > ConstantData.interval500001)
                {
                    resultFinal = Percent(ConstantData.interval50000, ConstantData.Percent4) + Percent(ConstantData.interval200000 - ConstantData.interval50000, ConstantData.Percent3) + Percent(150000, ConstantData.Percent1) + Percent(ConstantData.interval500000 - ConstantData.interval350000, ConstantData.Percent05) + Percent(salepriceEuros - ConstantData.interval500000, ConstantData.Percent025);

                }

            }
            //check if it's more than 12500
            if (resultFinal >= ConstantData.MaxRoyalty)
                resultFinal = ConstantData.MaxRoyalty;
            //Return the result in pounds or euro
            if (currency == "GBP")
            {
                decimal rate = _exchange.GetExchangeEuro(date);
                resultFinal = resultFinal / rate;

            }

            //already is in euro
            decimal solu = decimal.Round(resultFinal, 2);
            return solu.ToString("N", CultureInfo.InvariantCulture);
                       // return decimal.Round(resultFinal, 2);
        }

        

        /// <summary>
        /// Sales the price euro.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public string SalePriceEuro(decimal price, string currency, DateTime date)
        {
            decimal rate = 0;
            decimal result = 0;
            decimal solu;
            if (currency == "Euro")
            {
                solu = decimal.Round(price, 2);
                return solu.ToString("N", CultureInfo.InvariantCulture);
            }
            else if (currency == "GBP")
            {
                rate = _exchange.GetExchangeEuro(date);
                result = price * rate;
            }
            else //default pounds
            {
                rate = _exchange.GetExchangeEuro(date);
                result = price * rate;
            }
            solu = decimal.Round(result, 2);
            return solu.ToString("N", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Sales the price GBP.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public string SalePriceGBP(decimal price, string currency, DateTime date)
        {
            decimal rate = 0;
            decimal result = 0;
            decimal solu;
            if (currency == "GBP")
            {
                solu = decimal.Round(price, 2);
                return solu.ToString("N", CultureInfo.InvariantCulture);
            }
            else if (currency == "Euro")
            {
                rate = _exchange.GetExchangeGBP(date);
                result = price * rate;
            }
            else //default pounds
            {
                rate = _exchange.GetExchangeGBP(date);
                result = price * rate;
            }
           solu = decimal.Round(result, 2);
            return solu.ToString("N", CultureInfo.InvariantCulture);
                  }

        #endregion


        #region private methods
        /// <summary>
        /// Percents the specified price.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="percent">The percent.</param>
        /// <returns></returns>
        private decimal Percent(decimal price, decimal percent)
        {
            return (price * percent / 100);
        }


        /// <summary>
        /// Gets the rate.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        private decimal GetRate(DateTime dateTime)
        {
            return _exchange.GetExchangeEuro(dateTime);
        }

        #endregion

    }
}
