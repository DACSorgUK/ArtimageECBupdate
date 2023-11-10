using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebFormsMvp;
using WebFormsMvp.Web;
using DacsOnline.Presentation.Views;
using DacsOnline.Presentation.Presenters;

namespace DacsOnlineWebParts.WebParts
{
    [PresenterBinding(typeof(ArrthresholdCalculatorPresenter))]
    public partial class ArrThresholdCalculator : MvpUserControl, IThresholdCalculatorView
    {
        #region Event Handler
        /// <summary>
        /// Occurs when [calculate threshold].
        /// </summary>
        public event EventHandler CalculateThreshold;
        /// <summary>
        /// Occurs when [load form].
        /// </summary>
        public event EventHandler LoadForm;
        #endregion

        #region Page Event
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (LoadForm!= null)
                {
                    LoadForm(sender, e);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the Button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            //decimal price = decimal.Parse(TxtPrice.Text);
            if (CalculateThreshold != null)
            {
                TextResult.Visible = true;
                //if they choose the today's date or a date in the future show the EBC source
                if (DateTime.Parse(Date) >= DateTime.Today)
                    ECBSource.Visible = true;
                else
                    ECBSource.Visible = false;

                    CalculateThreshold(sender, e);
            }

        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Shows the date.
        /// </summary>
        public void ShowDate()
        {
            DateTime date = DateTime.Parse(txtDate.Text);
            lbdateToday.Text = date.Day + " " + String.Format("{0:MMMM}", date) + " " + date.Year;
            lbdateToday2.Text = date.Day + " " + String.Format("{0:MMMM}", date) + " " + date.Year;
            lbdateToday3.Text = date.Day + " " + String.Format("{0:MMMM}", date) + " " + date.Year;
        }
        /// <summary>
        /// Shows the price.
        /// </summary>
        /// <param name="result">The result.</param>
        public void ShowPrice(string result)
        {
            if (result == "0.00")
            {
                TextResult.Visible = false;
                TxtErrortoofar.Visible = true;
                LbResult.Text = result;
                LbResult1.Text = result;
                LbpriceGBP.Text = result;
            }
            else if (result == "-1000")
            {
               
                TextResult.Visible = false;
                TxtErrortoofar.Visible = true;
                LbResult.Text = result;
                LbResult1.Text = result;
                LbpriceGBP.Text = result;
            }
            else
            {
                TextResult.Visible = true;
                TxtErrortoofar.Visible = false;
                LbResult.Text = result;
                LbResult1.Text = result;
                LbpriceGBP.Text = result;
            }


            
        }
        /// <summary>
        /// Defaults the date.
        /// </summary>
        public void DefaultDate()
        {
            txtDate.Text = DateTime.Today.Day + " " + String.Format("{0:MMMM}", DateTime.Today) + " " + DateTime.Today.Year;
        }
        /// <summary>
        /// Exchanges the euro.
        /// </summary>
        /// <param name="result">The result.</param>
        public void ExchangeEuro(string result)
        {

            LbExchangeEuro.Text = result;
            LbExchangeEuro2.Text = result;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the date.
        /// </summary>
        public string Date
        {
            get { return txtDate.Text; }
        }

        #endregion

       


       
    }
}