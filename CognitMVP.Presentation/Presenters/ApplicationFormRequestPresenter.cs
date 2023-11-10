using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Enums;
using DacsOnline.Presentation.Views;
using WebFormsMvp;
using System.Configuration;

namespace DacsOnline.Presentation.Presenters
{
    public class ApplicationFormRequestPresenter : BasePresenter<IApplicationFormRequestView>, IDisposable
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationFormRequestPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public ApplicationFormRequestPresenter(IApplicationFormRequestView view)
            : base(view)
        {
            this.View.Onclick += new EventHandler(Onclick);
            this.View.OnLoad += new EventHandler(Load);
           
        }

        #endregion

        #region Public Methods
        public void Dispose()
        {
            this.View.Onclick -= new EventHandler(Onclick);

        }
        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="FormName">Name of the form.</param>
        private void SendEmail(string address, string FormName)
        {
            string[,] replacements = new string[2, 2];
            replacements[0, 0] = "Address";
            replacements[0, 1] = address;
            replacements[1, 0] = "FormName";
            replacements[1, 1] = FormName;

            DacsOnline.Model.Utilities.SendEmail.SendEmailUsingTemplate("DACSOnline_PostApplicationForm", this.View.AdministratorEmail, replacements);
      
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Onclicks the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Onclick(object sender, EventArgs e)
        {
            try
            {

                SendEmail(this.View.Address, this.View.FormName);
            }
            catch (Exception ex)
            {
                this.EventLogService.LogData(MessageType.Error, "ApplicationFormPresenter", ex.Message);

            }

        }

        /// <summary>
        /// Loads the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Load(object sender, EventArgs e)
        {
            try
            {
                this.View.Display();
              
            }
            catch (Exception ex)
            {
                this.EventLogService.LogData(MessageType.Error, "ApplicationFormPresenter", ex.Message);

            }

        }


        #endregion

    }
}
