using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.RepostioriesInterfaces;




namespace DacsOnline.Model.Manager
{
    public class ExchangeManager : IExchangeManager
    {
        private IExchangeRepository _exchangeRepository;

        public ExchangeManager(IExchangeRepository exchangeRepository)
        {
            _exchangeRepository = exchangeRepository;
        }

        public decimal GetExchangeGBP(DateTime dateTime)
        {
            return _exchangeRepository.GetExchangeGBP(dateTime);
         
        }

        public decimal GetExchangeEuro(DateTime dateTime)
        {
            try
            {
                decimal re = decimal.Divide(1, _exchangeRepository.GetExchangeGBP(dateTime));
                return decimal.Round(re, 4);
                 
            }
            catch (Exception)
            {

                return 0;
            }
            
        }
    }
}
