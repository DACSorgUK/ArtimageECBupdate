using System;
using System.Collections.Generic;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
	public interface IRoyaltyCalculatorView : IView
	{
		string currency
		{
			get;
		}

		decimal price
		{
			get;
		}

		string SaleDate
		{
			get;
		}

		void DefaultDate();

		void Display(List<string> models);

		void GetExchangeryEuro(string result);

		void ShowPrice(string result, string currency, string salepriceGBP, string salepriceEUR);

		event EventHandler CalculateRoyalty;

		event EventHandler LoadForm;
	}
}