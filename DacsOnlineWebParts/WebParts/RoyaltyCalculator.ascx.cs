using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebFormsMvp;
using WebFormsMvp.Web;

using DacsOnline.Presentation.Presenters;
using DacsOnline.Presentation.Views;
using DacsOnline.Model.Enums;
using System.Globalization;
using CMS.GlobalHelper;

namespace DacsOnlineWebParts.WebParts
{
    [PresenterBinding(typeof(RoyaltyCalculatorPresenter))]
    public partial class RoyaltyCalculator : MvpUserControl, IRoyaltyCalculatorView
    {
        #region Event Handler
        public event EventHandler LoadForm;
        public event EventHandler CalculateRoyalty;

        #endregion

        #region Page Events
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoadForm != null)
            {
                if (!IsPostBack)
                {
                    LoadForm(sender, e);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CalculateRoyalty != null)
            {
                if (string.IsNullOrEmpty(TxtPrice.Text))
                {
                    TextResult.Visible = false;
                    TxtErrortoofar.Visible = true;
                }
                else
                {
                    TextResult.Visible = true;
                    //if they choose the today's date or a date in the future show the EBC source
                    if (DateTime.Parse(SaleDate) >= DateTime.Today)
                        ECBSource.Visible = true;
                    else
                        ECBSource.Visible = false;

                    TxtErrortoofar.Visible = false;
                    CalculateRoyalty(sender, e);
                }
            }

        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Defaults the date.
        /// </summary>
        public void DefaultDate()
        {

            txtDate.Text = DateTime.Today.Day + " " + String.Format("{0:MMMM}", DateTime.Today) + " " + DateTime.Today.Year;

        }

        /// <summary>
        /// Displays the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        public void Display(List<string> items)
        {
            ddlCurrency.DataSource = items;
            ddlCurrency.DataBind();
        }

        /// <summary>
        /// Shows the price.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="salepriceGBP">The saleprice GBP.</param>
        /// <param name="salepriceEUR">The saleprice EUR.</param>
        public void ShowPrice(string result, string currency, string salepriceGBP, string salepriceEUR)
        {
            if (result == "0.00")
            {
                TextResult.Visible = false;
                TxtErrorLess1000.Visible = true;
                TxtErrortoofar.Visible = false;
            }
            else if (result == "-1.00")
            {
                TxtErrorLess1000.Visible = false;
                TextResult.Visible = false;
                TxtErrortoofar.Visible = true;
            }
            else
            {

                lblSalePricePounds.Text = salepriceGBP;
                lblSalePriceEuro.Text = salepriceEUR;

                TextResult.Visible = true;
                TxtErrortoofar.Visible = false;
                TxtErrorLess1000.Visible = false;
                if (currency == "GBP")
                    LbResult.Text = "£ " + result;
                else if (currency == "Euro")
                    LbResult.Text = "€ " + result;
            }


        }





        /// <summary>
        /// Dates the sale.
        /// </summary>
        public void DateSale()
        {
            DateTime date = Convert.ToDateTime(txtDate.Text);
            lbDate.Text = date.Day + " " + String.Format("{0:MMMM}", date) + " " + date.Year;
        }

        /// <summary>
        /// Gets the exchangery euro.
        /// </summary>
        /// <param name="result">The result.</param>
        public void GetExchangeryEuro(string result)
        {
            lbExchangeEuro.Text = result;
        }
        /// <summary>
        /// Shows the price.
        /// </summary>
        /// <param name="p">The p.</param>
        public void ShowPrice(decimal p)
        {
            lblSalePricePounds.Text = p.ToString();

        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the sale date.
        /// </summary>
        public string SaleDate
        {
            get { return txtDate.Text; }
        }

        /// <summary>
        /// Gets the currency.
        /// </summary>
        public string currency
        {
            get
            {
                if (ddlCurrency.Text == "GBP: £")
                    return CurrancyType.GBP.ToString();
                else if (ddlCurrency.Text == "EUR: €")
                    return CurrancyType.Euro.ToString();
                else
                    return CurrancyType.GBP.ToString();
            }
        }

        /// <summary>
        /// Gets the price.
        /// </summary>
        public decimal price
        {
            get { return decimal.Parse(TxtPrice.Text); }
        }

        public string HowIsCalculated
        {
            get { return ValidationHelper.GetString(this.GetValue("HowIsCalculated"), ""); }
        }
        #endregion






    }
}