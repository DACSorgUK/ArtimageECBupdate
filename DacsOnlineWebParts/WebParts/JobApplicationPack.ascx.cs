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

namespace DacsOnlineWebParts.WebParts
{
    [PresenterBinding(typeof(JobApplicationPackPresenter))]
    public partial class JobApplicationPack : MvpUserControl, IJobApplicationPackView
    {
        #region Event Handler
        public event EventHandler OnclickSubmit;
        public event EventHandler OnclickLink;
        public event EventHandler OnLoad;
        #endregion

        #region Page Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (OnLoad != null)
            {
                OnLoad(sender, e);
                if (!IsPostBack)
                {
                    confirmation.Visible = false;
                    sendemail.Visible = true;

                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (OnclickSubmit != null)
            {
                OnclickSubmit(sender, e);
            }
        }


        protected void lnkApplication_Click(object sender, EventArgs e)
        {
           
            if (OnclickLink != null)
            {
                OnclickLink(sender, e);
            }
        }


        #endregion

        #region Public Methods

        public void Display()
        {
            lbemail.Text = EmailDacs;

        }

        public void ShowSubmit()
        {
            enterEmail.Visible = true;
        }

        public void HideSubmit()
        {
            enterEmail.Visible = false;
            linkdownload.NavigateUrl = downloadjob;
        }

        public void ShowConfirmation()
        {
            confirmation.Visible = true;
        }
        public void HideConfirmation()
        {
            confirmation.Visible = false;
        }
        #endregion

        #region Properties
        public string EmailDacs
        {
            get { return ValidationHelper.GetString(this.GetValue("Email"), ""); }
        }

        public string EmailUser
        {
            get { return txtemail.Text; }
        }

        public string jobTitle
        {
            get { return ValidationHelper.GetString(this.GetValue("Form"), ""); }
        }

        public string downloadjob
        {
            get { return ValidationHelper.GetString(this.GetValue("DownloadJobApplication"), ""); }
        }

        #endregion


       
      
    }
}