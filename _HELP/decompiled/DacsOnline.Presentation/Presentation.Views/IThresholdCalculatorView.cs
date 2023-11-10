using System;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
	public interface IThresholdCalculatorView : IView
	{
		string Date
		{
			get;
		}

		void DefaultDate();

		void ExchangeEuro(string result);

		void ShowDate();

		void ShowPrice(string result);

		event EventHandler CalculateThreshold;

		event EventHandler LoadForm;
	}
}