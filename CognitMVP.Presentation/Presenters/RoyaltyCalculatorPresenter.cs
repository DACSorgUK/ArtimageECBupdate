using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Presentation.Views;
using DacsOnline.Service.Service.Interfaces;
using DacsOnline.Model.Enums;


namespace DacsOnline.Presentation.Presenters
{
    public class RoyaltyCalculatorPresenter : BasePresenter<IRoyaltyCalculatorView>, IDisposable
    {
        #region properties

        private ICalculatorService _service;
        #endregion
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="RoyaltyCalculatorPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="service">The service.</param>
        public RoyaltyCalculatorPresenter(IRoyaltyCalculatorView view, ICalculatorService service)
            : base(view)
        {
            this.View.LoadForm += new EventHandler(LoadForm);
            this.View.CalculateRoyalty += new EventHandler(CalculateRoyalties);
            _service = service;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.View.LoadForm -= new EventHandler(LoadForm);
            this.View.CalculateRoyalty -= new EventHandler(CalculateRoyalties);

        }
        #endregion


        #region Private Methods
        /// <summary>
        /// Loads the form.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LoadForm(object sender, EventArgs e)
        {
            try
            {

                this.View.Display(_service.GetListCurrency());
                this.View.DefaultDate();
            }
            catch (Exception ex)
            {
                this.EventLogService.LogData(MessageType.Error, "RoyaltyCalculatorPresenter", ex.Message);

       
            }


        }
        /// <summary>
        /// Calculates the royalties.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CalculateRoyalties(object sender, EventArgs e)
        {
            try
            {

                this.View.ShowPrice(_service.GetPrice(DateTime.Parse(View.SaleDate), View.currency, View.price).ToString(), View.currency, _service.SalePriceEuro(this.View.price, this.View.currency, DateTime.Parse(View.SaleDate)).ToString(), _service.SalePriceGBP(this.View.price, this.View.currency, DateTime.Parse(View.SaleDate)).ToString());
               
                this.View.GetExchangeryEuro(_service.GetExchangeEuro(DateTime.Parse(View.SaleDate)).ToString());
            }
            catch (Exception ex)
            {
                this.EventLogService.LogData(MessageType.Error, "RoyaltyCalculatorPresenter", ex.Message);
                
            }


        }

        #endregion
    }
}
