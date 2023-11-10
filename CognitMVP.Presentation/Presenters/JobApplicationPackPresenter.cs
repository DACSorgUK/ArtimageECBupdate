using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Enums;
using DacsOnline.Presentation.Views;

namespace DacsOnline.Presentation.Presenters
{
    /// <summary>
    /// 
    /// </summary>
    public class JobApplicationPackPresenter : BasePresenter<IJobApplicationPackView>, IDisposable
    {
        #region Constructor

        public JobApplicationPackPresenter(IJobApplicationPackView view)
            : base(view)
        {
            this.View.OnclickLink += new EventHandler(OnLink);
            this.View.OnclickSubmit += new EventHandler(OnSubmit);
            this.View.OnLoad += new EventHandler(Load);

        }
        #endregion

        #region private Methods
        /// <summary>
        /// Called when we click in the link application pack.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnLink(object sender, EventArgs e)
        {
            try
            {
                this.View.ShowSubmit();
                

            }
            catch (Exception ex)
            {
                this.EventLogService.LogData(MessageType.Error, "HowApplyPresenter", ex.Message);
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
                this.EventLogService.LogData(MessageType.Error, "HowApplyPresenter", ex.Message);
            }

        }

        /// <summary>
        /// Called when we want to send a email to the HR for information that how to apply.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnSubmit(object sender, EventArgs e)
        {
            try
            {
                SendEmail(this.View.EmailUser, this.View.jobTitle);
                this.View.ShowConfirmation();
                this.View.HideSubmit();
            }
            catch (Exception ex)
            {
                this.View.HideConfirmation();
                this.EventLogService.LogData(MessageType.Error, "HowApplyPresenter", ex.Message);
            }

        }

        /// <summary>
        /// Sends the email to the HR
        /// </summary>
        /// <param name="address">The address's user</param>
        /// <param name="jobTitle">The job title.</param>
        private void SendEmail(string address, string jobTitle)
        {
            string[,] replacement = new string[2, 2];
            replacement[0, 0] = "email";
            replacement[0, 1] = address;
            replacement[1, 0] = "jobtitle";
            replacement[1, 1] = jobTitle;
            DacsOnline.Model.Utilities.SendEmail.SendEmailUsingTemplate("DACS_ApplyJob", address, replacement);

        }

        #endregion
        #region Public Methods
        public void Dispose()
        {
            this.View.OnclickLink -= new EventHandler(OnLink);
            this.View.OnclickSubmit -= new EventHandler(OnSubmit);
            this.View.OnLoad -= new EventHandler(Load);
        }
        #endregion

    }
}
