using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Presentation.Views;
using DacsOnline.Service.Service.Interfaces;
using DacsOnline.Model.Enums;


namespace DacsOnline.Presentation.Presenters
{

 public class ArrthresholdCalculatorPresenter : BasePresenter<IThresholdCalculatorView>, IDisposable
 {
     #region //Private Properties

     /// <summary>
     /// 
     /// </summary>
         private ICalculatorService _service;
     #endregion

         /// <summary>
         /// Initializes a new instance of the <see cref="ArrthresholdCalculatorPresenter"/> class.
         /// </summary>
         /// <param name="view">The view.</param>
         /// <param name="service">The service.</param>
         public ArrthresholdCalculatorPresenter(IThresholdCalculatorView view, ICalculatorService service)
            : base(view)
        {
            this.View.LoadForm += new EventHandler(LoadForm);
            this.View.CalculateThreshold += new EventHandler(CalculateThreshold);
           _service = service;
        }

         #region public Methods
         /// <summary>
         /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
         /// </summary>
         public void Dispose()
         {
             this.View.LoadForm -= new EventHandler(LoadForm);
             this.View.CalculateThreshold -= new EventHandler(CalculateThreshold);

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

                this.View.DefaultDate();
             }
             catch (Exception ex)
             {
                 this.EventLogService.LogData(MessageType.Error, "ArrthresholdCalculatorPresenter", ex.Message);
                 //this.View.ErrorMessage = "An error occured when processing your request";
             }


         }


         /// <summary>
         /// Calculates the threshold.
         /// </summary>
         /// <param name="sender">The sender.</param>
         /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
         private void CalculateThreshold(object sender, EventArgs e)
         {
             try
             {

                 this.View.ShowPrice(_service.GetRate(DateTime.Parse(View.Date)));
                 this.View.ShowDate();
                 this.View.ExchangeEuro(_service.GetExchangeEuro(DateTime.Parse(View.Date)).ToString());

                 // this.View.ShowPrice(_service.GetPrice("", new DateTime(2000,1,1), View.currency,View.price).ToString());
             }
             catch (Exception ex)
             {
                 this.EventLogService.LogData(MessageType.Error, "ArrthresholdCalculatorPresenter", ex.Message);
                 //this.View.ErrorMessage = "An error occured when processing your request";
             }


         }
#endregion
 }
}
