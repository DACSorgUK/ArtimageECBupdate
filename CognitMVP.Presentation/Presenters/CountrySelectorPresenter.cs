using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Presentation.Views;
using DacsOnline.Model.Enums;
using DacsOnline.Service.Service.Interfaces;

namespace DacsOnline.Presentation.Presenters
{
    public class CountrySelectorPresenter : BasePresenter<ICountrySelectorView>, IDisposable
    {
        #region //Private Propeties
        private ICountrySelectorService _iCountrySelectorService;
        #endregion

        #region Contructor
        /// <summary>
        /// Initializes a new instance of the <see cref="JavascriptWebPartPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public CountrySelectorPresenter(ICountrySelectorView view, ICountrySelectorService iCountrySelectorService)
            : base(view)
        {
            this.View.LoadForm += new EventHandler(LoadForm);
            _iCountrySelectorService = iCountrySelectorService;
 
        }
        #endregion

        #region public Methods
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.View.LoadForm -= new EventHandler(LoadForm);
        }
        #endregion

        #region private Methods
        /// <summary>
        /// Loads the form.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LoadForm(object sender, EventArgs e)
        {
            try
            {
                this.View.BindCountry(_iCountrySelectorService.GetCountries());
            }
            catch (Exception ex)
            {
                this.EventLogService.LogData(MessageType.Error, "CountrySelectorPresenter", ex.Message);
               
            }


        }

        #endregion
    }
}
