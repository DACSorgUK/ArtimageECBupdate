using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DacsOnlineWebParts.DacsOnlineControls
{
	public class CLProduct : UserControl
	{
		protected HyperLink nypEdit;

		protected HtmlGenericControl idProduct;

		protected TextBox txtTitleOFProduct;

		protected CustomValidator cusValtxtTitleOFProduct;

		protected DropDownList ddTypeOfproduct;

		protected CustomValidator cusValddTypeOfproduct;

		protected Panel panelItems;

		protected HtmlGenericControl divPublishDate;

		protected TextBox txtPublishdate;

		protected CustomValidator cusvalPublishedDate;

		protected HtmlGenericControl divProductDescription;

		protected TextBox txtProductDescription;

		protected HtmlGenericControl divUsage;

		protected TextBox txtUsage;

		protected HtmlGenericControl divProductQuantity;

		protected TextBox txtProductQuantity;

		protected CustomValidator cusvalProductQunatity;

		protected HtmlGenericControl divProductSellingPrice;

		protected TextBox txtProductSellingPrice;

		protected HtmlGenericControl divcalDateLicence;

		protected TextBox txtDateLicence;

		protected CustomValidator cusvalDateLicence;

		protected HtmlGenericControl divPlannedDateOfIssue;

		protected TextBox txtPlannedDateOfIssue;

		protected CustomValidator cusValPlanneddate;

		protected HtmlGenericControl divrbEdition;

		protected CheckBoxList rbEdition;

		protected HtmlGenericControl divrbPublished;

		protected RadioButtonList rbPublished;

		protected HtmlGenericControl divDistributed;

		protected RadioButtonList rbDistributed;

		protected TextBox txtFutherInformation;

		protected Button btOpenFileUpload;

		protected Label ltlFileName;

		protected FileUpload FileUploadProduct;

		protected CustomValidator cusValFileValidator;

		protected PlaceHolder plcProductReproductions;

		protected CLReproductions CLReproductionsFirst;

		protected Button btAddReproduction;

		protected Label lbProduct2;

		protected HiddenField hidReproductId;

		private int count
		{
			get
			{
				int num;
				num = (this.ViewState[this.ID] != null ? (int)this.ViewState[this.ID] : 0);
				return num;
			}
			set
			{
				this.ViewState[this.ID] = value;
			}
		}

		public DateTime? DateLicenceNeeds
		{
			get
			{
				DateTime? nullable;
				string val = this.txtDateLicence.Text.Replace("dd/mm/yyyy", "");
				if (!string.IsNullOrEmpty(val))
				{
					nullable = new DateTime?(Convert.ToDateTime(val));
				}
				else
				{
					nullable = null;
				}
				return nullable;
			}
		}

		public string FurtherInformation
		{
			get
			{
				return this.txtFutherInformation.Text.Trim();
			}
		}

		public string LinkTitle
		{
			set
			{
				this.nypEdit.Text = string.Concat("Product ", value, " Show/Hide");
			}
		}

		public DateTime? PlannedDateOfIssue
		{
			get
			{
				DateTime? nullable;
				string val = this.txtPlannedDateOfIssue.Text.Replace("dd/mm/yyyy", "");
				if (!string.IsNullOrEmpty(val))
				{
					nullable = new DateTime?(Convert.ToDateTime(val));
				}
				else
				{
					nullable = null;
				}
				return nullable;
			}
		}

		public HttpPostedFile PostedFile
		{
			get
			{
				HttpPostedFile postedFile;
				if (this.FileUploadProduct.PostedFile == null)
				{
					postedFile = null;
				}
				else
				{
					postedFile = this.FileUploadProduct.PostedFile;
				}
				return postedFile;
			}
		}

		public string ProductDescription
		{
			get
			{
				return this.txtProductDescription.Text.Trim();
			}
		}

		public string ProductQuantity
		{
			get
			{
				return this.txtProductQuantity.Text.Trim();
			}
		}

		public string ProductSellingPrice
		{
			get
			{
				return this.txtProductSellingPrice.Text.Trim();
			}
		}

		public DateTime? PublishDate
		{
			get
			{
				DateTime? nullable;
				string val = this.txtPublishdate.Text.Replace("dd/mm/yyyy", "");
				if (!string.IsNullOrEmpty(val))
				{
					nullable = new DateTime?(Convert.ToDateTime(val));
				}
				else
				{
					nullable = null;
				}
				return nullable;
			}
		}

		public string Publishlanguage
		{
			get
			{
				return this.rbPublished.SelectedValue;
			}
		}

		public List<CopyRightLicencingProductReproductions> Reproductions
		{
			get
			{
				return this.GetReproductions();
			}
		}

		public string TitleOfProcuct
		{
			get
			{
				return this.txtTitleOFProduct.Text.Trim();
			}
		}

		public string TypeOfEdition
		{
			get
			{
				string value = string.Empty;
				foreach (ListItem item in this.rbEdition.Items)
				{
					if (item.Selected)
					{
						value = string.Concat(value, item.Value, ",");
					}
				}
				if (value.Length > 0)
				{
					value = value.Substring(0, value.Length - 1);
				}
				return value;
			}
		}

		public string TypeOfProduct
		{
			get
			{
				return this.ddTypeOfproduct.SelectedItem.Text;
			}
		}

		public string UsageRightsRequired
		{
			get
			{
				return this.txtUsage.Text.Trim();
			}
		}

		public string WhereItemDistributed
		{
			get
			{
				return this.rbDistributed.SelectedValue;
			}
		}

		public CLProduct()
		{
		}

		private void AddUserControal()
		{
			CLReproductions con = (CLReproductions)base.LoadControl("~/CMSWebParts/DacsOnlineControls/CLReproductions.ascx");
			con.ID = string.Concat(this.count, "CLProductReproductions");
			int count2 = this.count + 1;
			con.LinkTitleReproductions = (count2 + 1).ToString();
			this.plcProductReproductions.Controls.Add(con);
			this.count = this.count + 1;
			this.hidReproductId.Value = string.Concat(this.hidReproductId.Value, ",", con.GetListId());
		}

		protected void btAddReproduction_Click(object sender, EventArgs e)
		{
			this.Page.Validate("ValGroupCLForm");
			if (this.Page.IsValid)
			{
				this.Page.MaintainScrollPositionOnPostBack = false;
				int i = 1;
				foreach (Control ctrl in this.plcProductReproductions.Controls)
				{
					CLReproductions objCtrl = (CLReproductions)ctrl;
					objCtrl.HidPanel();
					objCtrl.LinkTitleReproductions = i.ToString();
					i++;
				}
				this.AddUserControal();
				this.Page.SetFocus(this.btAddReproduction);
			}
		}

		protected void cusvalDateLicence_ServerValidate(object source, ServerValidateEventArgs args)
		{
			string val = this.txtDateLicence.Text.Replace("dd/mm/yyyy", "");
			if (string.IsNullOrEmpty(this.txtDateLicence.Text))
			{
				args.IsValid = false;
			}
			else
			{
				args.IsValid = Validation.ValidateDate(val);
			}
		}

		protected void cusValddTypeOfproduct_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (this.ddTypeOfproduct.SelectedValue == "-1")
			{
				args.IsValid = false;
			}
		}

		protected void cusValFileValidator_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (this.PostedFile.ContentLength > 10485760)
			{
				args.IsValid = false;
			}
		}

		protected void cusValPlanneddate_ServerValidate(object source, ServerValidateEventArgs args)
		{
			string valSelected = this.ddTypeOfproduct.SelectedValue;
			string val = this.txtPlannedDateOfIssue.Text.Replace("dd/mm/yyyy", "");
			if ((valSelected == "Website" || valSelected == "AGD" || valSelected == "Live Event" ? false : !(valSelected == "Advertisment")))
			{
				args.IsValid = true;
			}
			else if (string.IsNullOrEmpty(val))
			{
				args.IsValid = true;
			}
			else
			{
				args.IsValid = Validation.ValidateDate(val);
			}
		}

		protected void cusvalProductQunatity_ServerValidate(object source, ServerValidateEventArgs args)
		{
			args.IsValid = !string.IsNullOrEmpty(this.txtProductQuantity.Text.Trim());
		}

		protected void cusvalPublishedDate_ServerValidate(object source, ServerValidateEventArgs args)
		{
			string valSelected = this.ddTypeOfproduct.SelectedValue;
			string val = this.txtPublishdate.Text.Replace("dd/mm/yyyy", "");
			if ((valSelected == "Book" || valSelected == "eBook" || valSelected == "Catalogue" || valSelected == "Newspaper" || valSelected == "Magazine" ? false : !(valSelected == "MLP")))
			{
				args.IsValid = true;
			}
			else if (string.IsNullOrEmpty(val))
			{
				args.IsValid = true;
			}
			else
			{
				args.IsValid = Validation.ValidateDate(val);
			}
		}

		protected void cusValtxtTitleOFProduct_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (string.IsNullOrEmpty(this.txtTitleOFProduct.Text.Trim()))
			{
				args.IsValid = false;
			}
		}

		private List<CopyRightLicencingProductReproductions> GetReproductions()
		{
			List<CopyRightLicencingProductReproductions> list = new List<CopyRightLicencingProductReproductions>();
			foreach (Control ctrl in this.plcProductReproductions.Controls)
			{
				CLReproductions objCtrl = (CLReproductions)ctrl;
				CopyRightLicencingProductReproductions obj = new CopyRightLicencingProductReproductions()
				{
					ArtistName = objCtrl.ArtistName,
					ContextOfUse = objCtrl.ContextOfUse,
					TitleOfWork = objCtrl.TitleOfWork,
					PostedFile = objCtrl.PostedFile,
					DepictedWork = objCtrl.DepictedWork
				};
				list.Add(obj);
			}
			return list;
		}

		public void HidPanel()
		{
			this.idProduct.Style.Add(HtmlTextWriterStyle.Display, "none");
		}

		private void LoadControal()
		{
			this.hidReproductId.Value = this.CLReproductionsFirst.GetListId();
			for (int i = 0; i < this.count; i++)
			{
				CLReproductions con = (CLReproductions)base.LoadControl("~/CMSWebParts/DacsOnlineControls/CLReproductions.ascx");
				con.ID = string.Concat(i, "CLProductReproductions");
				con.LinkTitleReproductions = (i + 2).ToString();
				this.plcProductReproductions.Controls.Add(con);
				this.hidReproductId.Value = string.Concat(this.hidReproductId.Value, con.GetListId());
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			string id = this.ClientID;
			if (base.IsPostBack)
			{
				this.LoadControal();
			}
			else
			{
				this.hidReproductId.Value = this.CLReproductionsFirst.GetListId();
			}
			if (!(base.Session[id] != null ? true : !this.FileUploadProduct.HasFile))
			{
				base.Session[id] = this.FileUploadProduct;
				this.FileUploadProduct = (FileUpload)base.Session[id];
				this.ltlFileName.Text = this.FileUploadProduct.FileName;
			}
			else if (!(base.Session[id] == null ? true : this.FileUploadProduct.HasFile))
			{
				this.FileUploadProduct = (FileUpload)base.Session[id];
				this.ltlFileName.Text = this.FileUploadProduct.FileName;
			}
			else if (this.FileUploadProduct.HasFile)
			{
				base.Session[id] = this.FileUploadProduct;
				this.FileUploadProduct = (FileUpload)base.Session[id];
				this.ltlFileName.Text = this.FileUploadProduct.FileName;
			}
			string[] clientID = new string[] { "SetFileText('", this.FileUploadProduct.ClientID, "','", this.ltlFileName.ClientID, "')" };
			string ss = string.Concat(clientID);
			this.FileUploadProduct.Attributes.Add("onchange", ss);
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
	}
}