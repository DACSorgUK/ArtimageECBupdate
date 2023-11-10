using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
    public interface IRoyaltyCalculatorView : IView
    {
        #region properties
        /// <summary>
        /// Gets the sale date.
        /// </summary>
        string SaleDate { get; }
        /// <summary>
        /// Gets the currency.
        /// </summary>
        string currency { get; }
        /// <summary>
        /// Gets the price.
        /// </summary>
        decimal price { get; }
        #endregion

        #region public Method
        /// <summary>
        /// Shows the price.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="salepriceGBP">The saleprice GBP.</param>
        /// <param name="salepriceEUR">The saleprice EUR.</param>
        void ShowPrice(string result, string currency,string salepriceGBP, string salepriceEUR);

        /// <summary>
        /// Displays the specified models.
        /// </summary>
        /// <param name="models">The models.</param>
        void Display(List<string> models);
        /// <summary>
        /// Defaults the date.
        /// </summary>
        void DefaultDate();

        /// <summary>
        /// Gets the exchangery euro.
        /// </summary>
        /// <param name="result">The result.</param>
        void GetExchangeryEuro(string result);
        /// <summary>
        /// Prices the sale GBP.
        /// </summary>
        /// <param name="result">The result.</param>
        //void PriceSaleGBP(string result);
        #endregion

        #region EventHandler
        /// <summary>
        /// Occurs when [load form].
        /// </summary>
        event EventHandler LoadForm;
        /// <summary>
        /// Occurs when [calculate royalty].
        /// </summary>
        event EventHandler CalculateRoyalty;
        #endregion

    }
}
