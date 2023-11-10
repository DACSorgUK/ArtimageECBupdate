using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DacsOnline.Model.Utilities;
using DacsOnline.Presentation.Presenters;
using DacsOnline.Presentation.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace DacsOnlineWebParts.WebParts
{
    [PresenterBinding(typeof(NewsLetterSignUpPresenter))]
    public partial class NewsLetterSignUp : MvpUserControl, INewsLetterSignUpView
    {

        #region event Handler
        /// <summary>
        /// Occurs when [click button].
        /// </summary>
        public event EventHandler ClickButton;
        #endregion

        #region Page Event
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the BtnSignup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnSignup_Click(object sender, EventArgs e)
        {
            Page.Validate("ValGroupNewsLetterSignUp");
             if(Page.IsValid)
             {
                    if (ClickButton != null)
                    {
                        ClickButton(sender, e);
                    }
             }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Sings up.
        /// </summary>
        /// <param name="result">if set to <c>true</c> [result].</param>
        public void SingUp(bool result)
        {
            if (result)
            {
                confirmation.Visible = true;
                signup.Visible = false;
            }
            else
            {
                confirmation.Visible = false;
                signup.Visible = true;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the first name.
        /// </summary>
        public string FirstName
        {
            get { return TxtFirstName.Text; }
        }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        public string LastName
        {
            get { return TxtSecondName.Text; }
        }

        /// <summary>
        /// Gets the email address.
        /// </summary>
        public string EmailAddress
        {
            get { return Txtemail.Text; }
        }
        #endregion











    }
}