using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Presentation.Views;

namespace DacsOnline.Presentation.Presenters
{
    public class JavascriptWebPartPresenter : BasePresenter<IJavascriptWebPartView>, IDisposable
    {
        #region Contructor
        /// <summary>
        /// Initializes a new instance of the <see cref="JavascriptWebPartPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public JavascriptWebPartPresenter(IJavascriptWebPartView view)
            : base(view)
        {
            this.View.LoadForm += new EventHandler(LoadForm);
 
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

                this.View.Display();
            }
            catch (Exception ex)
            {
               // this.EventLogService.LogData(MessageType.Error, "JavascriptWebPartPresenter", ex.Message);
               
            }


        }

        #endregion
    }
}
