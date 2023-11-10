using CMS.GlobalHelper;
using CMS.PortalControls;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Utilities;
using DacsOnline.Presentation.Presenters;
using DacsOnline.Presentation.Views;
using DacsOnlineWebParts.DacsOnlineControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace DacsOnlineWebParts.WebParts
{
	[PresenterBinding(typeof(CopyRightLicencingFormPresenter))]
	public class CopyRightLicencingForm : MvpUserControl, ICopyRightLicencingFormView, IView
	{
		protected ValidationSummary valSummaryCL;

		protected DropDownList ddTitle;

		protected TextBox txtName;

		protected TextBox txtLastName;

		protected CustomValidator CusValFirstName;

		protected CustomValidator cusValLastName;

		protected TextBox txtCompany;

		protected TextBox txtAddressLine1;

		protected TextBox txtAddressLine2;

		protected TextBox txtAddressLine3;

		protected CustomValidator cusValAddressLine1;

		protected TextBox txtCity;

		protected CustomValidator cusValCity;

		protected TextBox txtRegion;

		protected TextBox txtPostCode;

		protected CustomValidator cusValPostCode;

		protected CountrySelector ArtCountrySelector;

		protected CustomValidator cusValCountrySelector;

		protected TextBox txtPhone;

		protected CustomValidator cusValPhone;

		protected TextBox txtBoxMobile;

		protected CustomValidator cusValMobile;

		protected TextBox txtFax;

		protected CustomValidator cusValfax;

		protected TextBox txtEmail;

		protected CustomValidator cusValEmail;

		protected TextBox txtWebSite;

		protected CustomValidator cusValWebSite;

		protected TextBox txtVatNumber;

		protected RadioButtonList rbListinvoice;

		protected CustomValidator cusValContactDetails;

		protected TextBox txtInvoiceCompany;

		protected TextBox txtAddressLine1Invoice;

		protected TextBox txtAddressLine2Invoice;

		protected TextBox txtAddressLine3Invoice;

		protected CustomValidator cusValInvoiceAddress;

		protected TextBox txtCityInvoice;

		protected CustomValidator cusValtxtCityInvoice;

		protected TextBox txtRegionInvoice;

		protected TextBox txtPostCodeInvoice;

		protected CustomValidator cusValtxtPostCodeInvoice;

		protected CountrySelector CountrySelectorInvoice;

		protected CustomValidator cusValCountrySelectorInvoice;

		protected CheckBox chkCookie;

		protected PlaceHolder plcProduct;

		protected Button btAddAnother;

		protected Button btSubmit;

		public string AddressLine1
		{
			get
			{
				return this.txtAddressLine1.Text.Trim();
			}
			set
			{
				this.txtAddressLine1.Text = value;
			}
		}

		public string AddressLine2
		{
			get
			{
				return this.txtAddressLine2.Text.Trim();
			}
			set
			{
				this.txtAddressLine2.Text = value;
			}
		}

		public string AddressLine3
		{
			get
			{
				return this.txtAddressLine3.Text.Trim();
			}
			set
			{
				this.txtAddressLine3.Text = value;
			}
		}

		public string City
		{
			get
			{
				return this.txtCity.Text.Trim();
			}
			set
			{
				this.txtCity.Text = value;
			}
		}

		public string Company
		{
			get
			{
				return this.txtCompany.Text.Trim();
			}
			set
			{
				this.txtCompany.Text = value;
			}
		}

		public string ConfirmationUrl
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("ConfirmationUrl"), "");
			}
		}

		public string CookieUrl
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("CookieUrl"), "");
			}
		}

		public List<CopyRightLicencingProduct> CopyRightLicencingProductInformation
		{
			get
			{
				return this.GetSalesInformation();
			}
		}

		private int count
		{
			get
			{
				int num;
				num = (this.ViewState["controlcountProduct"] != null ? (int)this.ViewState["controlcountProduct"] : 0);
				return num;
			}
			set
			{
				this.ViewState["controlcountProduct"] = value;
			}
		}

		public string Country
		{
			get
			{
				return this.ArtCountrySelector.Country;
			}
			set
			{
				this.ArtCountrySelector.Country = value;
			}
		}

		public string CountyRegion
		{
			get
			{
				return this.txtRegion.Text.Trim();
			}
			set
			{
				this.txtRegion.Text = value;
			}
		}

		public string EmailAddress
		{
			get
			{
				return this.txtEmail.Text.Trim();
			}
			set
			{
				this.txtEmail.Text = value;
			}
		}

		public string Fax
		{
			get
			{
				return this.txtFax.Text.Trim();
			}
			set
			{
				this.txtFax.Text = value;
			}
		}

		public string InvoiceAddressLine1
		{
			get
			{
				return this.txtAddressLine1Invoice.Text.Trim();
			}
			set
			{
				this.txtAddressLine1Invoice.Text = value;
			}
		}

		public string InvoiceAddressLine2
		{
			get
			{
				return this.txtAddressLine2Invoice.Text.Trim();
			}
			set
			{
				this.txtAddressLine2Invoice.Text = value;
			}
		}

		public string InvoiceAddressLine3
		{
			get
			{
				return this.txtAddressLine3Invoice.Text.Trim();
			}
			set
			{
				this.txtAddressLine3Invoice.Text = value;
			}
		}

		public string InvoiceCity
		{
			get
			{
				return this.txtCityInvoice.Text.Trim();
			}
			set
			{
				this.txtCityInvoice.Text = value;
			}
		}

		public string InvoiceCompany
		{
			get
			{
				return this.txtInvoiceCompany.Text.Trim();
			}
			set
			{
				this.txtInvoiceCompany.Text = value;
			}
		}

		public string InvoiceCountry
		{
			get
			{
				return this.CountrySelectorInvoice.Country;
			}
			set
			{
				this.CountrySelectorInvoice.Country = value;
			}
		}

		public string InvoiceCountyRegion
		{
			get
			{
				return this.txtRegionInvoice.Text.Trim();
			}
			set
			{
				this.txtRegionInvoice.Text = value;
			}
		}

		public string InvoicePostCode
		{
			get
			{
				return this.txtPostCodeInvoice.Text.Trim();
			}
			set
			{
				this.txtPostCodeInvoice.Text = value;
			}
		}

		public string LastName
		{
			get
			{
				return this.txtLastName.Text.Trim();
			}
			set
			{
				this.txtLastName.Text = value;
			}
		}

		public string Mobile
		{
			get
			{
				return this.txtBoxMobile.Text.Trim();
			}
			set
			{
				this.txtBoxMobile.Text = value;
			}
		}

		public string Name
		{
			get
			{
				return this.txtName.Text.Trim();
			}
			set
			{
				this.txtName.Text = value;
			}
		}

		public string Phone
		{
			get
			{
				return this.txtPhone.Text.Trim();
			}
			set
			{
				this.txtPhone.Text = value;
			}
		}

		public string PostCode
		{
			get
			{
				return this.txtPostCode.Text.Trim();
			}
			set
			{
				this.txtPostCode.Text = value;
			}
		}

		public bool RememberDetails
		{
			get
			{
				return this.chkCookie.Checked;
			}
		}

		public string Title
		{
			get
			{
				return this.ddTitle.SelectedValue;
			}
			set
			{
				ListItem item = this.ddTitle.Items.FindByValue(value);
				int index = this.ddTitle.Items.IndexOf(item);
				this.ddTitle.SelectedIndex = index;
			}
		}

		public string UseContactDetailsInvoice
		{
			get
			{
				return this.rbListinvoice.SelectedValue;
			}
			set
			{
				this.rbListinvoice.SelectedValue = value;
			}
		}

		public string VatNumber
		{
			get
			{
				return this.txtVatNumber.Text.Trim();
			}
			set
			{
				this.txtVatNumber.Text = value;
			}
		}

		public string Website
		{
			get
			{
				return this.txtWebSite.Text.Trim();
			}
			set
			{
				this.txtWebSite.Text = value;
			}
		}

		public CopyRightLicencingForm()
		{
		}

		private void AddUserControal()
		{
			CLProduct con = (CLProduct)base.LoadControl("~/CMSWebParts/DacsOnlineControls/CLProduct.ascx");
			con.ID = string.Concat(this.count, "CLProduct");
			con.LinkTitle = (this.count + 1).ToString();
			this.plcProduct.Controls.Add(con);
			this.count = this.count + 1;
		}

		public void BindTitles(string[] titles)
		{
			this.ddTitle.DataSource = titles;
			this.ddTitle.DataBind();
		}

		protected void btAddAnother_Click(object sender, EventArgs e)
		{
			this.Page.Validate("ValGroupCLForm");
			if (!this.Page.IsValid)
			{
				this.Page.MaintainScrollPositionOnPostBack = false;
			}
			else
			{
				this.Page.MaintainScrollPositionOnPostBack = false;
				foreach (Control ctrl in this.plcProduct.Controls)
				{
					((CLProduct)ctrl).HidPanel();
				}
				this.AddUserControal();
				this.Page.SetFocus(this.btAddAnother);
			}
		}

		protected void btSubmitData_Click(object sender, EventArgs e)
		{
			this.Page.Validate();
			if (!this.Page.IsValid)
			{
				this.Page.MaintainScrollPositionOnPostBack = false;
			}
			else
			{
				this.Page.MaintainScrollPositionOnPostBack = false;
				if (this.SubmitData != null)
				{
					this.SubmitData(sender, e);
				}
			}
		}

		protected void cusContactDetails_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (this.rbListinvoice.SelectedIndex == -1)
			{
				args.IsValid = false;
			}
		}

		protected void cusValAddressLine1_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (string.IsNullOrEmpty(this.txtAddressLine1.Text.Trim()))
			{
				args.IsValid = false;
			}
		}

		protected void cusValAddressLine1Invoice_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (!(this.rbListinvoice.SelectedValue == "No"))
			{
				args.IsValid = true;
			}
			else if (string.IsNullOrEmpty(this.txtAddressLine1Invoice.Text.Trim()))
			{
				args.IsValid = false;
			}
		}

		protected void cusValCity_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (string.IsNullOrEmpty(this.txtCity.Text.Trim()))
			{
				args.IsValid = false;
			}
		}

		protected void cusValCityinvoice_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (!(this.rbListinvoice.SelectedValue == "No"))
			{
				args.IsValid = true;
			}
			else if (string.IsNullOrEmpty(this.txtCityInvoice.Text.Trim()))
			{
				args.IsValid = false;
			}
		}

		protected void cusValCountry_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if ((string.IsNullOrEmpty(this.ArtCountrySelector.Country) ? true : this.ArtCountrySelector.Country == "Type to select Country"))
			{
				args.IsValid = false;
			}
		}

		protected void cusValCountryInvoice_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (!(this.rbListinvoice.SelectedValue == "No"))
			{
				args.IsValid = true;
			}
			else if ((string.IsNullOrEmpty(this.CountrySelectorInvoice.Country) ? true : this.CountrySelectorInvoice.Country == "Type to select Country"))
			{
				args.IsValid = false;
			}
		}

		protected void cusValEmail_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (string.IsNullOrEmpty(this.txtEmail.Text.Trim()))
			{
				args.IsValid = false;
			}
			else
			{
				args.IsValid = Validation.ValidateEmailAddress(this.txtEmail.Text.Trim());
			}
		}

		protected void cusValfax_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (!string.IsNullOrEmpty(this.txtFax.Text.Trim()))
			{
				args.IsValid = Validation.ValidatePhoneNumber(this.txtFax.Text.Trim());
			}
		}

		protected void CusValFirstName_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
			{
				args.IsValid = false;
			}
		}

		protected void cusValLastName_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (string.IsNullOrEmpty(this.txtLastName.Text.Trim()))
			{
				args.IsValid = false;
			}
		}

		protected void cusValMobile_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (!string.IsNullOrEmpty(this.txtBoxMobile.Text.Trim()))
			{
				args.IsValid = Validation.ValidatePhoneNumber(this.txtBoxMobile.Text.Trim());
			}
		}

		protected void cusValPhone_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (string.IsNullOrEmpty(this.txtPhone.Text.Trim()))
			{
				args.IsValid = false;
			}
			else
			{
				args.IsValid = Validation.ValidatePhoneNumber(this.txtPhone.Text.Trim());
			}
		}

		protected void cusValPostCode_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (string.IsNullOrEmpty(this.txtPostCode.Text.Trim()))
			{
				args.IsValid = false;
			}
		}

		protected void cusValPostCodeInvoice_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (!(this.rbListinvoice.SelectedValue == "No"))
			{
				args.IsValid = true;
			}
			else if (string.IsNullOrEmpty(this.txtPostCodeInvoice.Text.Trim()))
			{
				args.IsValid = false;
			}
		}

		protected void cusValRegion_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (string.IsNullOrEmpty(this.txtRegion.Text.Trim()))
			{
				args.IsValid = false;
			}
		}

		protected void cusValWebSite_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (!string.IsNullOrEmpty(this.txtWebSite.Text.Trim()))
			{
				args.IsValid = Validation.ValidateWebsite(this.txtWebSite.Text.Trim());
			}
		}

		private List<CopyRightLicencingProduct> GetSalesInformation()
		{
			List<CopyRightLicencingProduct> list = new List<CopyRightLicencingProduct>();
			foreach (Control ctrl in this.plcProduct.Controls)
			{
				CLProduct objCtrl = (CLProduct)ctrl;
				CopyRightLicencingProduct obj = new CopyRightLicencingProduct()
				{
					DateLicenceNeeds = objCtrl.DateLicenceNeeds,
					launctDate = objCtrl.PlannedDateOfIssue,
					ProductDescription = objCtrl.ProductDescription,
					ProductQuantity = objCtrl.ProductQuantity,
					ProductReproductions = objCtrl.Reproductions,
					ProductSellingPrice = objCtrl.ProductSellingPrice,
					PublishDate = objCtrl.PublishDate,
					Publishlanguage = objCtrl.Publishlanguage,
					TitleOfProcuct = objCtrl.TitleOfProcuct,
					TypeOfEdition = objCtrl.TypeOfEdition,
					TypeOfProduct = objCtrl.TypeOfProduct,
					UsageRightsRequired = objCtrl.UsageRightsRequired,
					WhereItemDistributed = objCtrl.WhereItemDistributed,
					FurtherInformation = objCtrl.FurtherInformation,
					PostedFile = objCtrl.PostedFile
				};
				list.Add(obj);
			}
			return list;
		}

		private void LoadControal()
		{
			for (int i = 0; i < this.count; i++)
			{
				CLProduct con = (CLProduct)base.LoadControl("~/CMSWebParts/DacsOnlineControls/CLProduct.ascx");
				con.ID = string.Concat(i, "CLProduct");
				con.LinkTitle = (i + 1).ToString();
				this.plcProduct.Controls.Add(con);
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (base.IsPostBack)
			{
				this.LoadControal();
			}
			else
			{
				this.AddUserControal();
				if (this.LoadData != null)
				{
					this.LoadData(sender, e);
				}
			}
		}

		public void RedirectForm(string url)
		{
			base.Response.Redirect(url, true);
		}

		private void SetScrollPosition()
		{
			this.Page.MaintainScrollPositionOnPostBack = false;
			foreach (IValidator validator in this.Page.GetValidators("ValGroupCLForm"))
			{
				if ((!(validator is BaseValidator) ? false : !validator.IsValid))
				{
					BaseValidator bv = (BaseValidator)validator;
					Control target = bv.NamingContainer.FindControl(bv.ControlToValidate);
					if (target != null)
					{
						this.Page.SetFocus(target);
					}
					break;
				}
			}
		}

		public void ShowError()
		{
		}

		public event EventHandler LoadData;

		public event EventHandler SubmitData;
	}
}