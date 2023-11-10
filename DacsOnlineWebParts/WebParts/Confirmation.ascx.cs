using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DacsOnline.Presentation.Presenters;
using DacsOnline.Presentation.Views;
using WebFormsMvp;
using WebFormsMvp.Web;
using CMS.GlobalHelper;


namespace DacsOnlineWebParts.WebParts
{
    [PresenterBinding(typeof(ConfirmationPresenter))]
    public partial class Confirmation : MvpUserControl, IConfirmationView
    {
        #region Event Handler
        /// <summary>
        /// Occurs when [load form].
        /// </summary>
        public event EventHandler LoadForm;
        #endregion

        #region Page Event
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {

       //  string aa = DataHelper.GetNotEmpty(GetValue("Path"), null);

            if (!IsPostBack)
            {
                if (LoadForm != null)
                    LoadForm(sender, e);
            }
        }
        #endregion


        #region Public Methods
        /// <summary>
        /// Displays the confirmation page depending on the Form.
        /// </summary>
        /// <param name="nameform">The nameform.</param>
        /// <param name="refe">The refe.</param>
        /// <param name="useremail">The useremail.</param>
        /// <param name="dacsemail">The dacsemail.</param>
        public void Display(string nameform, string refe, string useremail, string dacsemail)
        {
            string _title = DataHelper.GetNotEmpty(GetValue("Title"), null);
            if (!string.IsNullOrEmpty(_title))
                LbFormName1.Text = _title;
            else
                LbFormName1.Text = nameform;

            string _thanksFor = DataHelper.GetNotEmpty(GetValue("ThanksFor"), null);
            if (!string.IsNullOrEmpty(_thanksFor))
                lbFormName2.Text = _thanksFor;
            else
                lbFormName2.Text = nameform;

            string _followOn = DataHelper.GetNotEmpty(GetValue("followOn"), null);
            if (!string.IsNullOrEmpty(_followOn))
                lbFollowon.Text = _followOn;

            string _email = DataHelper.GetNotEmpty(GetValue("email"), null);
            if (!string.IsNullOrEmpty(_email))
                lbemaildacs.Text = _email;
            else
                lbemaildacs.Text = EmailDACS;

            string _phone = DataHelper.GetNotEmpty(GetValue("phone"), null);
            if (!string.IsNullOrEmpty(_phone))
                lbphone.Text = _phone;


            // LbFormName1.Text = nameform;
            //lbFormName2.Text = nameform;
            lbReference.Text = refe;
            //lbemaildacs.Text = EmailDACS;
            LbemailUser.Text = useremail;
        }
        #endregion

        #region Properties

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
                if (string.IsNullOrEmpty(Request.QueryString["form"]))
                    return "";
                else
                {
                    return HTMLHelper.HTMLEncode(Request.QueryString["form"].ToString());

                }

            }
        }

        public string EmailDACS
        {
            get { return HTMLHelper.HTMLEncode(ValidationHelper.GetString(this.GetValue("EmailDACS"), "")); }
        }

        public string FormEmail
        {
            get { return HTMLHelper.HTMLEncode(ValidationHelper.GetString(this.GetValue("email"), "")); }
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        public string Title
        {
            get
            {
                if (string.IsNullOrEmpty(Request.QueryString["form"]))
                    return "";
                else
                {
                    return DacsOnline.Model.Utilities.ConstantDataConfirmation.GetNameForm(HTMLHelper.HTMLEncode(Request.QueryString["form"]));

                }

            }
        }

        /// <summary>
        /// Gets the email.
        /// </summary>
        public string Email
        {
            get
            {
               // return "AA@BB.COM";

                if (Session["emailUser"] == null || String.IsNullOrEmpty(Session["emailUser"].ToString()))
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["emailUser"]))
                        return HTMLHelper.HTMLEncode(Request.QueryString["emailUser"].ToString());

                        return "";
                }
                else
                {
                    return HTMLHelper.HTMLEncode(Session["emailUser"].ToString());
                }
            }
        }

        /// <summary>
        /// Gets the iduser.
        /// </summary>
        public int Iduser
        {
            get
            {
                if (string.IsNullOrEmpty(HTMLHelper.HTMLEncode(Request.QueryString["Id"])))
                    return 0;
                else
                    return Int32.Parse(HTMLHelper.HTMLEncode(Request.QueryString["Id"]));
            }
        }

        #endregion

    }
}