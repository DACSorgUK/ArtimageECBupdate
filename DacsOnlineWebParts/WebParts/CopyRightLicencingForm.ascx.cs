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
using System.IO;
using System.Web.UI.HtmlControls;
using DacsOnline.Model.RepostioriesInterfaces;
using CMS.SettingsProvider;
using CMS.SiteProvider;
using System.Data;
using CMS.CMSHelper;

namespace DacsOnlineWebParts.WebParts
{
    [PresenterBinding(typeof(CopyRightLicencingFormPresenter))]
    public partial class CopyRightLicencingForm : MvpUserControl, ICopyRightLicencingFormView
    {
        #region //Page Events
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCountry();
            if (!IsPostBack)
            {
                AddUserControal();
                if (LoadData != null)
                {
                    LoadData(sender, e);

                    if (rbListinvoice.SelectedValue == "No")
                    {
                        pnlInvoice.Visible = true;
                    }
                }

                if (Session["SessionKeyCLFileList"] != null)
                {
                    Session.Remove("SessionKeyCLFileList");
                }

                if (Session["SessionKeyReproducctionList"] != null)
                {
                    Session.Remove("SessionKeyReproducctionList");
                }

                CountrySelector countryData = new CountrySelector();

                //IARRArtistSearchRepository SearchRepository = new ARRArtistSearchRepository();

                //foreach (string item in _SearchRepository)
                //{
                //    ArtCountrySelector.Items.Add(new ListItem(item, item));
                //    ArtInvoiceCountrySelector.Items.Add(new ListItem(item, item));

                //}
                // ArtCountrySelector.Items.Add(new ListItem(item, item));
            }
            else
            {
                if (Session["SessionKeyCLFileList"] != null)
                {
                    List<string> _files = Files;

                    foreach (string temp in _files)
                    {

                        FileInfo fi = new FileInfo(Server.MapPath(ConstantDataForForms.GLOBAL_TEMP + "/" + temp));

                        if (fi != null)
                        {

                            string[] filePart = fi.Name.Split('_');

                            var _contentLength = (fi.Length / (1024));
                            var text = _contentLength + " KB";

                            if (_contentLength > (1024))
                            {
                                text = (_contentLength / 1024) + " MB";
                            }

                            HtmlTableRow row = new HtmlTableRow();
                            HtmlTableCell cell1 = new HtmlTableCell();
                            cell1.InnerText = filePart[filePart.Length - 1];
                            HtmlTableCell cell2 = new HtmlTableCell();
                            cell2.InnerText = text;
                            row.Cells.Add(cell1);
                            row.Cells.Add(cell2);
                            clientSide.Rows.Add(row);
                        }
                    }
                }

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
            Page.Validate("ValGroupCLForm");
            if (Page.IsValid)
            {
                this.Page.MaintainScrollPositionOnPostBack = false;
                foreach (Control ctrl in plcProduct.Controls)
                {
                    CLProduct objCtrl = (CLProduct)ctrl;
                    objCtrl.HidPanel();
                }
                AddUserControal();

                this.Page.SetFocus(btAddAnother);
            }
            else
            {
                this.Page.MaintainScrollPositionOnPostBack = false;
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
                this.Page.MaintainScrollPositionOnPostBack = false;
                if (SubmitData != null)
                {
                    SubmitData(sender, e);
                    Session.Remove("SessionKeyReproducctionList");
                }
            }
            else
            {
                this.Page.MaintainScrollPositionOnPostBack = false;
                //SetScrollPosition(); //Commented code to put generic error message
            }

        }

        protected void rbListinvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbListinvoice.SelectedValue != "Yes")
            {
                pnlInvoice.Visible = true;
            }
            else
            {
                pnlInvoice.Visible = false;
            }
        }

        public void BindCountry()
        {

            //countryselectorDacs.DataSource = CountryList;
            //countryselectorDacs.DataBind();
            ArtCountrySelector.Items.Insert(0, new ListItem("Type to select Country", "Type to select Country"));
            ArtInvoiceCountrySelector.Items.Insert(0, new ListItem("Type to select Country", "Type to select Country"));

            CustomTableItemProvider customTableProvider = new CustomTableItemProvider(CMSContext.CurrentUser);

            string customTableClassName = ConstantDataArtistSearch.NationalityTable;
            DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);
            List<Nationality> list = new List<Nationality>();
            if (customTable != null)
            {
                DataSet customTableItems = customTableProvider.GetItems(customTableClassName, null, "Country");
                if (!DataHelper.DataSourceIsEmpty(customTableItems))
                {
                    foreach (DataRow customTableItemDr in customTableItems.Tables[0].Rows)
                    {
                        Nationality obj = new Nationality();
                        CustomTableItem modifyCustomTableItem = new CustomTableItem(customTableItemDr, customTableClassName);
                        obj.Country = ValidationHelper.GetString(modifyCustomTableItem.GetValue("Country"), "");
                        obj.Person = ValidationHelper.GetString(modifyCustomTableItem.GetValue("Person"), "");
                        obj.EEA = ValidationHelper.GetBoolean(modifyCustomTableItem.GetValue("EEA"), false);
                        list.Add(obj);

                    }

                }
            }

            int location = 1;
            foreach (Nationality item in list)
            {
                //countryselectorDacs.Items.Insert(location, new ListItem(item, item));
                ArtCountrySelector.Items.Add(new ListItem(item.Country, item.Country));
                ArtInvoiceCountrySelector.Items.Add(new ListItem(item.Country, item.Country));
                location++;
            }
        }

        #endregion

        #region //Custom Validators

        /// <summary>
        /// Handles the ServerValidate event of the cusValCountry control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValCountry_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(ArtCountrySelector.SelectedValue) || ArtCountrySelector.SelectedValue == "Type to select Country")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void cusValInvoiceCountry_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(ArtInvoiceCountrySelector.SelectedValue) || ArtInvoiceCountrySelector.SelectedValue == "Type to select Country")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
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
        /// Handles the ServerValidate event of the CusValFirstName control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void CusValFirstName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
            {
                args.IsValid = false;
            }
        }

        ///// <summary>
        ///// Handles the ServerValidate event of the cusValTitle control.
        ///// </summary>
        ///// <param name="source">The source of the event.</param>
        ///// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        //protected void cusValTitle_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    if (ddTitle.SelectedIndex == 0)
        //    {
        //        args.IsValid = false;
        //    }
        //}



        /// <summary>
        /// Handles the ServerValidate event of the cusValAddressLine1 control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValAddressLine1_ServerValidateT(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtAddressLine1.Text.Trim()))
            {
                args.IsValid = false;
            }
        }

        protected void cusValInvoiceAddressLine1_ServerValidateT(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtInvoiceAddressLine1.Text.Trim()))
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

        protected void cusValInvoiceCity_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtInvoiceCity.Text.Trim()))
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

        protected void cusValInvoicePostCode_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtInvoicePostCode.Text.Trim()))
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
        ////protected void cusValMobile_ServerValidate(object source, ServerValidateEventArgs args)
        ////{
        ////    if (!string.IsNullOrEmpty(txtBoxMobile.Text.Trim()))
        ////    {
        ////        args.IsValid = Validation.ValidatePhoneNumber(txtBoxMobile.Text.Trim());
        ////    }
        ////}

        /// <summary>
        /// Handles the ServerValidate event of the cusValfax control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        ////protected void cusValfax_ServerValidate(object source, ServerValidateEventArgs args)
        ////{
        ////    if (!string.IsNullOrEmpty(txtFax.Text.Trim()))
        ////    {
        ////        args.IsValid = Validation.ValidatePhoneNumber(txtFax.Text.Trim());
        ////    }
        ////}
        ///
        protected void CusValCompany_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtInvoiceCompany.Text.Trim()))
            {
                args.IsValid = false;
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
                args.IsValid = Validation.ValidateEmailAddress(txtEmail.Text.Trim());
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void cusValBillingEmailAddress_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(txtBillingEmailAddress.Text.Trim()))
            {
                args.IsValid = Validation.ValidateEmailAddress(txtBillingEmailAddress.Text.Trim());
            }
            else
            {
                args.IsValid = true;
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
        /// Handles the ServerValidate event of the cusContactDetails control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusContactDetails_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (rbListinvoice.SelectedIndex == -1)
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
                ViewState["controlcountProduct"] = value;
            }
            get
            {
                if (ViewState["controlcountProduct"] == null)
                {
                    return 0;
                }
                else
                {
                    return (int)ViewState["controlcountProduct"];
                }
            }
        }

        /// <summary>
        /// Adds the user controal.
        /// </summary>
        private void AddUserControal()
        {
            CLProduct con = (CLProduct)LoadControl("~/CMSWebParts/DacsOnlineControls/CLProduct.ascx");
            con.ID = count + "CLProduct";
            int count2 = count + 1;
            con.LinkTitle = count2.ToString();

            //Label lbProduct = new Label();
            //lbProduct.ID = count2 + "lbProduct";
            //lbProduct.Text = "Product " + count2;
            //plcProduct.Controls.Add(lbProduct);

            plcProduct.Controls.Add(con);
            count = count + 1;
        }

        /// <summary>
        /// Loads the controal.
        /// </summary>
        private void LoadControal()
        {
            for (int i = 0; i < count; i++)
            {


                CLProduct con = (CLProduct)LoadControl("~/CMSWebParts/DacsOnlineControls/CLProduct.ascx");
                con.ID = i + "CLProduct";
                con.LinkTitle = (i + 1).ToString();
                plcProduct.Controls.Add(con);

            }


        }


        #endregion

        #region //Public properties

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
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return txtFirstName.Text.Trim();
            }
            set
            {
                txtFirstName.Text = value;
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
                return "";
            }
            set
            {

            }
            //get
            //{
            //    return ddTitle.SelectedValue;
            //}
            //set
            //{
            //    ListItem item = ddTitle.Items.FindByValue(value);
            //    int index = ddTitle.Items.IndexOf(item);
            //    ddTitle.SelectedIndex = index;
            //}
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
                return ArtCountrySelector.SelectedValue;
            }
            set
            {
                ArtCountrySelector.SelectedValue = value;
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
        ////public string Mobile
        ////{
        ////    get
        ////    {
        ////        return txtBoxMobile.Text.Trim();
        ////    }
        ////    set
        ////    {
        ////        txtBoxMobile.Text = value;
        ////    }
        ////}

        /// <summary>
        /// Gets the fax.
        /// </summary>
        ////public string Fax
        ////{
        ////    get
        ////    {
        ////        return txtFax.Text.Trim();
        ////    }
        ////    set
        ////    {
        ////        txtFax.Text = value;
        ////    }
        ////}
        ///


        /// <summary>
        /// Gets the email address.
        /// </summary>
        public string EmailAddress
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
        /// Gets the copy right licencing product information.
        /// </summary>
        public List<CopyRightLicencingProduct> CopyRightLicencingProductInformation
        {
            get { return GetSalesInformation(); }
        }

        /// <summary>
        /// Gets or sets the vat number.
        /// </summary>
        /// <value>
        /// The vat number.
        /// </value>
        public string VatNumber
        {
            get
            {
                return txtVatNumber.Text.Trim();
            }
            set
            {
                txtVatNumber.Text = value;
            }
        }

        public string BillingContactName
        {
            get
            {
                return txtBillingContactName.Text.Trim();
            }
            set
            {
                txtBillingContactName.Text = value;
            }
        }

        public string BillingEmailAddress
        {
            get
            {
                return txtBillingEmailAddress.Text.Trim();
            }
            set
            {
                txtBillingEmailAddress.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the use contact details invoice.
        /// </summary>
        /// <value>
        /// The use contact details invoice.
        /// </value>
        public string UseContactDetailsInvoice
        {
            get
            {
                return rbListinvoice.SelectedValue;
            }
            set
            {
                rbListinvoice.SelectedValue = value;
            }
        }

        public string InvoiceCompany
        {
            get
            {
                return txtInvoiceCompany.Text.Trim();
            }
            set
            {
                txtInvoiceCompany.Text = value;
            }
        }

        /// <summary>
        /// Gets the address line1.
        /// </summary>
        public string InvoiceAddressLine1
        {
            get
            {
                return txtInvoiceAddressLine1.Text.Trim();
            }
            set
            {
                txtInvoiceAddressLine1.Text = value;
            }
        }

        /// <summary>
        /// Gets the address line2.
        /// </summary>
        public string InvoiceAddressLine2
        {
            get
            {
                return txtInvoiceAddressLine2.Text.Trim();
            }
            set
            {
                txtInvoiceAddressLine2.Text = value;
            }
        }

        /// <summary>
        /// Gets the address line3.
        /// </summary>
        public string InvoiceAddressLine3
        {
            get
            {
                return txtInvoiceAddressLine3.Text.Trim();
            }
            set
            {
                txtInvoiceAddressLine3.Text = value;
            }
        }

        /// <summary>
        /// Gets the city.
        /// </summary>
        public string InvoiceCity
        {
            get
            {
                return txtInvoiceCity.Text.Trim();
            }
            set
            {
                txtInvoiceCity.Text = value;
            }
        }

        /// <summary>
        /// Gets the region.
        /// </summary>
        public string InvoiceCountyRegion
        {
            get
            {
                return txtInvoiceRegion.Text.Trim();
            }
            set
            {
                txtInvoiceRegion.Text = value;
            }
        }

        /// <summary>
        /// Gets the post code.
        /// </summary>
        public string InvoicePostCode
        {
            get
            {
                return txtInvoicePostCode.Text.Trim();
            }
            set
            {
                txtInvoicePostCode.Text = value;
            }
        }

        /// <summary>
        /// Gets the country.
        /// </summary>
        public string InvoiceCountry
        {
            get
            {
                return ArtInvoiceCountrySelector.SelectedValue;
            }
            set
            {
                ArtInvoiceCountrySelector.SelectedValue = value;
            }
        }

        public List<string> Files
        {
            get
            {
                var fileList = new List<string>();
                if (Session["SessionKeyCLFileList"] != null)
                {
                    fileList = (List<string>)Session["SessionKeyCLFileList"];

                }

                return fileList;
            }
            set
            {

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
            foreach (IValidator validator in this.Page.GetValidators("ValGroupCLForm"))
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
        private List<CopyRightLicencingProduct> GetSalesInformation()
        {
            List<CopyRightLicencingProduct> list = new List<CopyRightLicencingProduct>();
            foreach (Control ctrl in plcProduct.Controls)
            {
                CLProduct objCtrl = (CLProduct)ctrl;
                CopyRightLicencingProduct obj = new CopyRightLicencingProduct();
                obj.DateLicenceNeeds = objCtrl.DateLicenceNeeds;
                obj.launctDate = objCtrl.PlannedDateOfIssue;
                //// obj.ProductDescription = objCtrl.ProductDescription;
                obj.PrintRun = objCtrl.PrintRun;
                obj.PrintRunDigital = objCtrl.PrintRunDigital;
                obj.ProductReproductions = objCtrl.Reproductions;
                //// obj.ProductSellingPrice = objCtrl.ProductSellingPrice;
                ////obj.PublishDate = objCtrl.PublishDate;
                obj.Publishlanguage = objCtrl.Language;
                obj.TitleOfProcuct = objCtrl.TitleOfProcuct;
                obj.ISBN = objCtrl.ISBN;
                ///  obj.TypeOfEdition = objCtrl.TypeOfEdition;
                obj.TypeOfProduct = objCtrl.TypeOfProduct;
                obj.UsageRightsRequired = objCtrl.UsageRightsRequired;
                obj.WhereItemDistributed = objCtrl.WhereItemDistributed;
                obj.FurtherInformation = objCtrl.FurtherInformation;
                //////// obj.PostedFile = objCtrl.PostedFile;

                obj.LicenceDuration = objCtrl.LicenceDuration;
                obj.Website = objCtrl.Website;
                obj.ContextOfUseCropped = objCtrl.ContextOfUseCropped;
                obj.ContextOfUseCover = objCtrl.ContextOfUseCover;

                list.Add(obj);
            }

            return list;
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
            //ddTitle.DataSource = titles;
            //ddTitle.DataBind();

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

        public void FileUploadComplete(object sender, EventArgs e)
        {
            //string filePrefix = Guid.NewGuid().ToString() + "_";
            //string filename = System.IO.Path.GetFileName(AsyncFileUpload1.FileName);
            //string finalFileName = filePrefix + filename;

            //if (!Directory.Exists(HttpContext.Current.Server.MapPath(ConstantDataForForms.GLOBAL_TEMP)))
            //{
            //    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(ConstantDataForForms.GLOBAL_TEMP));
            //}

            //AsyncFileUpload1.SaveAs(Server.MapPath(ConstantDataForForms.GLOBAL_TEMP + "/") + finalFileName);

            //if (Session["SessionKeyCLFileList"] != null)
            //{
            //    var fileList = (List<string>)Session["SessionKeyCLFileList"];
            //    fileList.Add(finalFileName);
            //    Session["SessionKeyCLFileList"] = fileList;
            //}
            //else
            //{
            //    List<string> fileList = new List<string>();
            //    fileList.Add(finalFileName);
            //    Session["SessionKeyCLFileList"] = fileList;
            //}
        }

        #endregion
    }
}

