using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Service.Service.Interfaces;
using DacsOnline.Model.Manager.Interfaces;


namespace DacsOnline.Service.Service
{
    public class CalculatorService : BaseService<ICalculatorManager>, ICalculatorService
    {
        #region private properties
        /// <summary>
        /// Exchange manager
        /// </summary>
        private IExchangeManager _exchange;
        /// <summary>
        /// Calculator Manager
        /// </summary>
        private ICalculatorManager _calculatorManager;

        #endregion


        #region Contructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorService"/> class.
        /// </summary>
        /// <param name="calculatorManager">The calculator manager.</param>
        /// <param name="exchange">The exchange.</param>
        public CalculatorService(ICalculatorManager calculatorManager, IExchangeManager exchange)
            : base(calculatorManager)
        {
            _calculatorManager = calculatorManager;
            _exchange = exchange;
  
        }

        #endregion 

        #region public methods

        /// <summary>
        /// Get the price for royalty calcutor
        /// </summary>
        /// <param name="date"></param>
        /// <param name="currency"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public string GetPrice(DateTime date, string currency, decimal price)
        {
            return _calculatorManager.GetPrice(date, currency, price);
        }

        /// <summary>
        /// Get the equivalence in pounds for 1000€ 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string GetRate(DateTime date)
        {
            decimal exch = _exchange.GetExchangeEuro(date);
            decimal re = 1000/exch;
            decimal result = decimal.Round(re, 2);
            return result.ToString();


        }

        /// <summary>
        /// Gets the exchange euro.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
         public string GetExchangeEuro(DateTime date)
         {
             return decimal.Round(_exchange.GetExchangeEuro(date), 4).ToString();
         }

        
       

        /// <summary>
        /// Gets the list currency.
        /// </summary>
        /// <returns></returns>
        public List<string> GetListCurrency()
        {
            var list = new List<string>();
            list.Add("GBP: £");
            list.Add("EUR: €");
            return list;
        }



        /// <summary>
        /// Sales the price euro.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        string ICalculatorService.SalePriceEuro(decimal price, string currency, DateTime date)
        {
            return _calculatorManager.SalePriceGBP(price, currency, date);
        }

        /// <summary>
        /// Sales the price GBP.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        string ICalculatorService.SalePriceGBP(decimal price, string currency, DateTime date)
        {
            return _calculatorManager.SalePriceEuro(price, currency, date);
        }

        #endregion 
    }
}
