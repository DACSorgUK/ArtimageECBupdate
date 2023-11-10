using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DacsOnlineWebParts.DacsOnlineControls;
using DacsOnline.Model.Business_Objects;
using WebFormsMvp.Web;
using DacsOnline.Presentation.Views;
using WebFormsMvp;
using DacsOnline.Presentation.Presenters;
using DacsOnline.Model.Utilities;
using CMS.GlobalHelper;

namespace DacsOnlineWebParts.WebParts
{
    [PresenterBinding(typeof(ArtMarketSalesFormPresenter))]
    public partial class ArtMarketSalesForm : MvpUserControl, IArtMarketSalesFormView
    {
        #region //Page Events
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddUserControal();
                if (LoadData != null)
                {
                    LoadData(sender, e);
                }
            }
            else
            {
                LoadControal();
            }
        }

        /// <summary>
        /// Handles the Click event of the btAddAnother control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btAddAnother_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                this.Page.MaintainScrollPositionOnPostBack = false;
                foreach (Control ctrl in plcSales.Controls)
                {
                    SalesInformation objCtrl = (SalesInformation)ctrl;
                   // objCtrl.HidPanel();
                }
                AddUserControal();
                this.Page.SetFocus(btAddAnother);
            }
            else
            {
                this.Page.MaintainScrollPositionOnPostBack = false;
                this.Page.SetFocus(ddTitle);
                //SetScrollPosition(); //Commented code to put generic error message
            }
        }

        /// <summary>
        /// Handles the Click event of the btSubmitData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btSubmitData_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                this.Page.MaintainScrollPositionOnPostBack =false;
                if (SubmitData != null)
                {
                    SubmitData(sender, e);
                }
            }
            else
            {
                this.Page.MaintainScrollPositionOnPostBack = false;
                this.Page.SetFocus(ddTitle);
                //SetScrollPosition(); //Commented code to put generic error message
            }
           
        }

        
        #endregion

        #region //Custom Validators

        /// <summary>
        /// Handles the ServerValidate event of the cusValName control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                args.IsValid = false;
            }
        }

        /// <summary>
        /// Handles the ServerValidate event of the cusValLastName control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValLastName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
            {
                args.IsValid = false;
            }
        }

        /// <summary>
        /// Handles the ServerValidate event of the cusValTitle control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValTitle_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddTitle.SelectedIndex == 0)
            {
                args.IsValid = false;
            }
        }

       

        /// <summary>
        /// Handles the ServerValidate event of the cusValAddressLine1 control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValAddressLine1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtAddressLine1.Text.Trim()))
            {
                args.IsValid = false;
            }
        }

        /// <summary>
        /// Handles the ServerValidate event of the cusValAddressLine2 control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValAddressLine2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtAddressLine2.Text.Trim()))
            {
                args.IsValid = false;
            }
        }

        

        /// <summary>
        /// Handles the ServerValidate event of the cusValCity control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValCity_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtCity.Text.Trim()))
            {
                args.IsValid = false;
            }
        }

        /// <summary>
        /// Handles the ServerValidate event of the cusValRegion control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValRegion_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtRegion.Text.Trim()))
            {
                args.IsValid = false;
            }
        }

        /// <summary>
        /// Handles the ServerValidate event of the cusValPostCode control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValPostCode_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtPostCode.Text.Trim()))
            {
                args.IsValid = false;
            }
        }

        /// <summary>
        /// Handles the ServerValidate event of the cusValCountry control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValCountry_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(ArtCountrySelector.Country) || ArtCountrySelector.Country == "Type to select Country") 
            {
                args.IsValid = false;
            }
        }

        /// <summary>
        /// Handles the ServerValidate event of the cusValPhone control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValPhone_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                args.IsValid = Validation.ValidatePhoneNumber(txtPhone.Text.Trim());
            }
            else
            {
                args.IsValid = false;
            }
        }

        /// <summary>
        /// Handles the ServerValidate event of the cusValMobile control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValMobile_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(txtBoxMobile.Text.Trim()))
            {
                args.IsValid = Validation.ValidatePhoneNumber(txtBoxMobile.Text.Trim());
            }
        }

        /// <summary>
        /// Handles the ServerValidate event of the cusValfax control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValfax_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(txtFax.Text.Trim()))
            {
                args.IsValid = Validation.ValidatePhoneNumber(txtFax.Text.Trim());
            }
        }

        /// <summary>
        /// Handles the ServerValidate event of the cusValEmail control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                args.IsValid = Validation.ValidateEmailAddress(txtEmail.Text.Trim().ToLower());
            }
            else
            {
                args.IsValid = false;
            }
        }

        /// <summary>
        /// Handles the ServerValidate event of the cusValWebSite control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValWebSite_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(txtWebSite.Text.Trim()))
            {
                args.IsValid = Validation.ValidateWebsite(txtWebSite.Text.Trim());
            }
        }

        /// <summary>
        /// Handles the ServerValidate event of the cusValCompany control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValCompany_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtCompany.Text.Trim()))
            {
                args.IsValid = false;
            }
        }
        #endregion

        #region //LoadDynamicControl
        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        private int count
        {
            set
            {
                ViewState["controlcount"] = value;
            }
            get
            {
                if (ViewState["controlcount"] == null)
                {
                    return 0;
                }
                else
                {
                    return (int)ViewState["controlcount"];
                }
            }
        }

        /// <summary>
        /// Adds the user controal.
        /// </summary>
        private void AddUserControal()
        {
            SalesInformation txt = (SalesInformation)LoadControl("~/CMSWebParts/DacsOnlineControls/SalesInformation.ascx");
            txt.ID = count + "Sales";
            txt.LinkTitle = (count + 1).ToString();
            //txt.HasControls();
            plcSales.Controls.Add(txt);
            count = count + 1;
        }

        /// <summary>
        /// Loads the controal.
        /// </summary>
        private void LoadControal()
        {
            for (int i = 0; i < count; i++)
            {
                SalesInformation txt = (SalesInformation)LoadControl("~/CMSWebParts/DacsOnlineControls/SalesInformation.ascx");
                txt.ID = i + "Sales";
                txt.LinkTitle = (i + 1).ToString();
                plcSales.Controls.Add(txt);

            }
        }

     
        #endregion

        #region //Public properties
        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return txtName.Text.Trim();
            }
            set
            {
                txtName.Text = value;
            }
        }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        public string LastName
        {
            get
            {
                return txtLastName.Text.Trim();
            }
            set
            {
                txtLastName.Text = value;
            }
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        public string Title
        {
            get
            {
                return ddTitle.SelectedValue;
            }
            set
            {
                ListItem item = ddTitle.Items.FindByValue(value);
                int index = ddTitle.Items.IndexOf(item);
                ddTitle.SelectedIndex = index;
            }
        }

        /// <summary>
        /// Gets the company.
        /// </summary>
        public string Company
        {
            get
            {
                return txtCompany.Text.Trim();
            }
            set
            {
                txtCompany.Text = value;
            }
        }

        /// <summary>
        /// Gets the address line1.
        /// </summary>
        public string AddressLine1
        {
            get
            {
                return txtAddressLine1.Text.Trim();
            }
            set
            {
                txtAddressLine1.Text = value;
            }
        }

        /// <summary>
        /// Gets the address line2.
        /// </summary>
        public string AddressLine2
        {
            get
            {
                return txtAddressLine2.Text.Trim();
            }
            set
            {
                txtAddressLine2.Text = value;
            }
        }

        /// <summary>
        /// Gets the address line3.
        /// </summary>
        public string AddressLine3
        {
            get
            {
                return txtAddressLine3.Text.Trim();
            }
            set
            {
                txtAddressLine3.Text = value;
            }
        }

        /// <summary>
        /// Gets the city.
        /// </summary>
        public string City
        {
            get
            {
                return txtCity.Text.Trim();
            }
            set
            {
                txtCity.Text = value;
            }
        }

        /// <summary>
        /// Gets the region.
        /// </summary>
        public string CountyRegion
        {
            get
            {
                return txtRegion.Text.Trim();
            }
            set
            {
                txtRegion.Text = value;
            }
        }

        /// <summary>
        /// Gets the post code.
        /// </summary>
        public string PostCode
        {
            get
            {
                return txtPostCode.Text.Trim();
            }
            set
            {
                txtPostCode.Text = value;
            }
        }

        /// <summary>
        /// Gets the country.
        /// </summary>
        public string Country
        {
            get
            {
                return ArtCountrySelector.Country;
            }
            set
            {
                ArtCountrySelector.Country = value;
            }
        }

        /// <summary>
        /// Gets the phone.
        /// </summary>
        public string Phone
        {
            get
            {
                return txtPhone.Text.Trim();
            }
            set
            {
                txtPhone.Text = value;
            }
        }

        /// <summary>
        /// Gets the mobile.
        /// </summary>
        public string Mobile
        {
            get
            {
                return txtBoxMobile.Text.Trim();
            }
            set
            {
                txtBoxMobile.Text = value;
            }
        }

        /// <summary>
        /// Gets the fax.
        /// </summary>
        public string Fax
        {
            get
            {
                return txtFax.Text.Trim();
            }
            set
            {
                txtFax.Text = value;
            }
        }


        /// <summary>
        /// Gets the email address.
        /// </summary>
        public string  EmailAddress
        {
            get
            {
                return txtEmail.Text.Trim();
            }
            set
            {
                txtEmail.Text = value;
            }
        }

        /// <summary>
        /// Gets the website.
        /// </summary>
        public string Website
        {
            get
            {
                return txtWebSite.Text.Trim();
            }
            set
            {
                txtWebSite.Text = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [remember details].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [remember details]; otherwise, <c>false</c>.
        /// </value>
        public bool RememberDetails
        {
            get
            {
                return chkCookie.Checked;
            }
        }

        /// <summary>
        /// Gets the sales information.
        /// </summary>
        public List<SalesInformationData> SalesInformation
        {
            get
            {
                return GetSalesInformation();
            }
        }

        /// <summary>
        /// Gets the confirmation URL.
        /// </summary>
        public string ConfirmationUrl
        {
            get
            {
                  return ValidationHelper.GetString(this.GetValue("ConfirmationUrl"), ""); 
            }
        }


        /// <summary>
        /// Gets the cookie URL.
        /// </summary>
        public string CookieUrl
        {
            get
            {
                return ValidationHelper.GetString(this.GetValue("CookieUrl"), "");
            }
        }

        
        #endregion

        #region //Private Methods

        /// <summary>
        /// Sets the scroll position.
        /// </summary>
        private void SetScrollPosition()
        {
            this.Page.MaintainScrollPositionOnPostBack = false;
            // find the first validator that failed
            foreach (IValidator validator in this.Page.GetValidators("ValGroupArtMarketsales"))
            {
                if (validator is BaseValidator && !validator.IsValid)
                {
                    BaseValidator bv = (BaseValidator)validator;

                    // look up the control that failed validation
                    Control target =
                        bv.NamingContainer.FindControl(bv.ControlToValidate);

                    // set the focus to it
                    if (target != null)
                    {
                        this.Page.SetFocus(target);

                        //target.Focus();
                    }

                    break;
                }
            }
        }
        /// <summary>
        /// Gets the sales information.
        /// </summary>
        /// <returns></returns>
        private List<SalesInformationData> GetSalesInformation()
        {
            List<SalesInformationData> obj = new List<SalesInformationData>();
            foreach (Control ctrl in plcSales.Controls)
            {
                SalesInformation objCtrl = (SalesInformation)ctrl;
                SalesInformationData objData = new SalesInformationData();
                objData.ArtistName = objCtrl.ArtistName;
              //  objData.BoughtAsStock = objCtrl.BoughtAsStock;

                //if (objCtrl.DateOfBirth !=null)
                //    objData.DateOfBirth = Convert.ToDateTime(objCtrl.DateOfBirth);

                //if (objCtrl.DateOfDeath !=null)
                //    objData.DateOfDeath = Convert.ToDateTime(objCtrl.DateOfDeath);

                if (objCtrl.DateOfBirth != null && objCtrl.DateOfBirth.Trim() != "yyyy")
                    objData.DateOfBirth = objCtrl.DateOfBirth;

                if (objCtrl.DateOfDeath != null && objCtrl.DateOfDeath.Trim() != "yyyy")
                    objData.DateOfDeath = objCtrl.DateOfDeath;

                objData.EditionNumber = objCtrl.EditionNumber;
                objData.Dimensions = objCtrl.Dimensions;
                objData.Medium = objCtrl.Medium;
                objData.Nationality = objCtrl.Nationality;
                objData.Refrence = objCtrl.Refrence;

                if (!string.IsNullOrEmpty(objCtrl.SalesDate))
                    objData.SalesDate = Convert.ToDateTime(objCtrl.SalesDate);

                objData.SalesPrice = objCtrl.SalesPrice;
                objData.TitleOfWork = objCtrl.TitleOfWork;
                obj.Add(objData);
            }

            return obj;
        }
        #endregion

        #region //Event Handlers


        /// <summary>
        /// Occurs when [submit data].
        /// </summary>
        public event EventHandler SubmitData;

        /// <summary>
        /// Occurs when [load data].
        /// </summary>
        public event EventHandler LoadData;

        #endregion

        #region //Public Methods
        /// <summary>
        /// Binds the titles.
        /// </summary>
        /// <param name="titles">The titles.</param>
        public void BindTitles(string[] titles)
        {
            ddTitle.DataSource = titles;
            ddTitle.DataBind();

        }

        /// <summary>
        /// Redirects the form.
        /// </summary>
        /// <param name="url">The URL.</param>
        public void RedirectForm(string url)
        {
            Response.Redirect(url, true);
        }

        /// <summary>
        /// Shows the error.
        /// </summary>
        public void ShowError()
        {

        }
        #endregion

    }
}