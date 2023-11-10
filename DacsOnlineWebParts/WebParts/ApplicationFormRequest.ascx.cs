using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.GlobalHelper;
using DacsOnline.Model.Utilities;
using DacsOnline.Presentation.Presenters;
using DacsOnline.Presentation.Views;
using WebFormsMvp;
using WebFormsMvp.Web;
using System.Configuration;


namespace DacsOnlineWebParts.WebParts
{
    [PresenterBinding(typeof(ApplicationFormRequestPresenter))]
    public partial class ApplicationFormRequest : MvpUserControl, IApplicationFormRequestView
    {
        #region //Event Handler
        /// <summary>
        /// Occurs when [onclick].
        /// </summary>
        public event EventHandler Onclick;
        /// <summary>
        /// Occurs when [on load].
        /// </summary>
        public event EventHandler OnLoad;
        #endregion

        #region //PageEvent
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (OnLoad != null)
            {
                OnLoad(sender, e);
            }
        }
        /// <summary>
        /// Handles the Click event of the Button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Onclick != null)
            {
                Onclick(sender, e);
                confirmation.Visible = true;
                postme.Visible = false;
            }

        }
        #endregion

        #region //Public Properties
        /// <summary>
        /// Gets the name of the form.
        /// </summary>
        /// <value>
        /// The name of the form.
        /// </value>
        public string FormName
        {
            get
            {
                string applicationForm = ValidationHelper.GetString(GetValue("FormName"), "");
                if (string.IsNullOrEmpty(applicationForm))
                    return string.Empty;
                else
                {
                    return applicationForm;
                }

            }
        }

        /// <summary>
        /// Gets the address.
        /// </summary>
        public string Address
        {
            get { return txtPost.Text; }
        }

        /// <summary>
        /// Gets the administrator email.
        /// </summary>
        public string AdministratorEmail
        {
            get { return ValidationHelper.GetString(this.GetValue("Administrator_Email"), ""); }
        }

        /// <summary>
        /// Gets the telephone.
        /// </summary>
        public string Telephone
        {
            get { return ValidationHelper.GetString(this.GetValue("Telephone"), ""); }
        }
        #endregion

        #region //Public Methods

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            lblEmail.Text = AdministratorEmail;
            lblTelephone.Text = Telephone;
        }
       
        #endregion

    }
}