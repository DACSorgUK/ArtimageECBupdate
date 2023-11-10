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
	[PresenterBinding(typeof(ArtMarketSalesFormPresenter))]
	public class ArtMarketSalesForm : MvpUserControl, IArtMarketSalesFormView, IView
	{
		protected ValidationSummary valSummaryCL;

		protected DropDownList ddTitle;

		protected TextBox txtName;

		protected TextBox txtLastName;

		protected CustomValidator cusValName;

		protected CustomValidator cusValLastName;

		protected TextBox txtCompany;

		protected CustomValidator cusValCompany;

		protected TextBox txtAddressLine1;

		protected TextBox txtAddressLine2;

		protected TextBox txtAddressLine3;

		protected CustomValidator cusValAddressLine1;

		protected CustomValidator cusValCity;

		protected TextBox txtCity;

		protected TextBox txtRegion;

		protected TextBox txtPostCode;

		protected CustomValidator cusValPostCode;

		protected CountrySelector ArtCountrySelector;

		protected CustomValidator cusValCountry;

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

		protected CheckBox chkCookie;

		protected PlaceHolder plcSales;

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

		private int count
		{
			get
			{
				int num;
				num = (this.ViewState["controlcount"] != null ? (int)this.ViewState["controlcount"] : 0);
				return num;
			}
			set
			{
				this.ViewState["controlcount"] = value;
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

		public List<SalesInformationData> SalesInformation
		{
			get
			{
				return this.GetSalesInformation();
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

		public ArtMarketSalesForm()
		{
		}

		private void AddUserControal()
		{
			DacsOnlineWebParts.DacsOnlineControls.SalesInformation txt = (DacsOnlineWebParts.DacsOnlineControls.SalesInformation)base.LoadControl("~/CMSWebParts/DacsOnlineControls/SalesInformation.ascx");
			txt.ID = string.Concat(this.count, "Sales");
			txt.LinkTitle = (this.count + 1).ToString();
			this.plcSales.Controls.Add(txt);
			this.count = this.count + 1;
		}

		public void BindTitles(string[] titles)
		{
			this.ddTitle.DataSource = titles;
			this.ddTitle.DataBind();
		}

		protected void btAddAnother_Click(object sender, EventArgs e)
		{
			this.Page.Validate();
			if (!this.Page.IsValid)
			{
				this.Page.MaintainScrollPositionOnPostBack = false;
				this.Page.SetFocus(this.ddTitle);
			}
			else
			{
				this.Page.MaintainScrollPositionOnPostBack = false;
				foreach (Control ctrl in this.plcSales.Controls)
				{
					((DacsOnlineWebParts.DacsOnlineControls.SalesInformation)ctrl).HidPanel();
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
				this.Page.SetFocus(this.ddTitle);
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

		protected void cusValAddressLine1_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (string.IsNullOrEmpty(this.txtAddressLine1.Text.Trim()))
			{
				args.IsValid = false;
			}
		}

		protected void cusValAddressLine2_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (string.IsNullOrEmpty(this.txtAddressLine2.Text.Trim()))
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

		protected void cusValCompany_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (string.IsNullOrEmpty(this.txtCompany.Text.Trim()))
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

		protected void cusValEmail_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (string.IsNullOrEmpty(this.txtEmail.Text.Trim()))
			{
				args.IsValid = false;
			}
			else
			{
				args.IsValid = Validation.ValidateEmailAddress(this.txtEmail.Text.Trim().ToLower());
			}
		}

		protected void cusValfax_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (!string.IsNullOrEmpty(this.txtFax.Text.Trim()))
			{
				args.IsValid = Validation.ValidatePhoneNumber(this.txtFax.Text.Trim());
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

		protected void cusValName_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
			{
				args.IsValid = false;
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

		protected void cusValRegion_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (string.IsNullOrEmpty(this.txtRegion.Text.Trim()))
			{
				args.IsValid = false;
			}
		}

		protected void cusValTitle_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (this.ddTitle.SelectedIndex == 0)
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

		private List<SalesInformationData> GetSalesInformation()
		{
			List<SalesInformationData> obj = new List<SalesInformationData>();
			foreach (Control ctrl in this.plcSales.Controls)
			{
				DacsOnlineWebParts.DacsOnlineControls.SalesInformation objCtrl = (DacsOnlineWebParts.DacsOnlineControls.SalesInformation)ctrl;
				SalesInformationData objData = new SalesInformationData()
				{
					ArtistName = objCtrl.ArtistName,
					BoughtAsStock = objCtrl.BoughtAsStock
				};
				if (objCtrl.DateOfBirth != null)
				{
					objData.DateOfBirth = objCtrl.DateOfBirth;
				}
				if (objCtrl.DateOfDeath != null)
				{
					objData.DateOfDeath = objCtrl.DateOfDeath;
				}
				objData.EditionNumber = objCtrl.EditionNumber;
				objData.Medium = objCtrl.Medium;
				objData.Nationality = objCtrl.Nationality;
				objData.Refrence = objCtrl.Refrence;
				if (!string.IsNullOrEmpty(objCtrl.SalesDate))
				{
					objData.SalesDate = new DateTime?(Convert.ToDateTime(objCtrl.SalesDate));
				}
				objData.SalesPrice = objCtrl.SalesPrice;
				objData.TitleOfWork = objCtrl.TitleOfWork;
				obj.Add(objData);
			}
			return obj;
		}

		private void LoadControal()
		{
			for (int i = 0; i < this.count; i++)
			{
				DacsOnlineWebParts.DacsOnlineControls.SalesInformation txt = (DacsOnlineWebParts.DacsOnlineControls.SalesInformation)base.LoadControl("~/CMSWebParts/DacsOnlineControls/SalesInformation.ascx");
				txt.ID = string.Concat(i, "Sales");
				txt.LinkTitle = (i + 1).ToString();
				this.plcSales.Controls.Add(txt);
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
			foreach (IValidator validator in this.Page.GetValidators("ValGroupArtMarketsales"))
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