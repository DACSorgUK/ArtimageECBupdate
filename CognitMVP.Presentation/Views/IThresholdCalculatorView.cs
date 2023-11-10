using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
    public interface IThresholdCalculatorView : IView
    {
        #region properties
        string Date { get; }
        #endregion

        #region Public Methods
        void ShowPrice(string result);
        void DefaultDate();
        void ShowDate();
        void ExchangeEuro(string result);
        #endregion

        #region EventHandler
        event EventHandler CalculateThreshold;
        event EventHandler LoadForm;
        #endregion
    }
}
