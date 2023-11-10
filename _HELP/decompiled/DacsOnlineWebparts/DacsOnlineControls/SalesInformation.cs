using DacsOnline.Model.Utilities;
using DacsOnlineWebParts.WebParts.DacsOnlineControls;
using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DacsOnlineWebParts.DacsOnlineControls
{
	public class SalesInformation : UserControl
	{
		protected HyperLink nypEdit;

		protected HtmlGenericControl idProduct;

		protected DacsOnlineWebParts.WebParts.DacsOnlineControls.Calendar calSaleDate;

		protected CustomValidator CusSaleDateValidator;

		protected TextBox txtRefrence;

		protected TextBox txtArtistName;

		protected CustomValidator cusValArtistName;

		protected TextBox txtDateOfBirth;

		protected CustomValidator cusValDateOfBirth;

		protected TextBox txtDateDeath;

		protected CustomValidator cusValDateOFDeath;

		protected MultiTextBox txtNationality;

		protected CustomValidator cusValNationality;

		protected TextBox txtTitleOfWork;

		protected CustomValidator cusValTitleOfWork;

		protected TextBox txtMedium;

		protected TextBox txtEditionNumber;

		protected TextBox txtSalePrice;

		protected CustomValidator cusValSalesPrice;

		protected RadioButtonList rbClaiming;

		public string ArtistName
		{
			get
			{
				return this.txtArtistName.Text.Trim();
			}
		}

		public string BoughtAsStock
		{
			get
			{
				return this.rbClaiming.SelectedValue;
			}
		}

		public string DateOfBirth
		{
			get
			{
				string str;
				str = (!string.IsNullOrEmpty(this.txtDateOfBirth.Text) ? this.txtDateOfBirth.Text : "");
				return str;
			}
		}

		public string DateOfDeath
		{
			get
			{
				string str;
				str = (!string.IsNullOrEmpty(this.txtDateDeath.Text) ? this.txtDateOfBirth.Text : "");
				return str;
			}
		}

		public string EditionNumber
		{
			get
			{
				return this.txtEditionNumber.Text;
			}
		}

		public string LinkTitle
		{
			set
			{
				this.nypEdit.Text = string.Concat("Product ", value, " Show/Hide");
			}
		}

		public string Medium
		{
			get
			{
				return this.txtMedium.Text;
			}
		}

		public string Nationality
		{
			get
			{
				return this.txtNationality.Text;
			}
		}

		public string Refrence
		{
			get
			{
				return this.txtRefrence.Text.Trim();
			}
		}

		public string SalesDate
		{
			get
			{
				return this.calSaleDate.Date;
			}
		}

		public string SalesPrice
		{
			get
			{
				return this.txtSalePrice.Text;
			}
		}

		public string TitleOfWork
		{
			get
			{
				return this.txtTitleOfWork.Text;
			}
		}

		public SalesInformation()
		{
		}

		protected void CusSaleDateValidator_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (string.IsNullOrEmpty(this.calSaleDate.Date.ToString()))
			{
				args.IsValid = false;
			}
			else
			{
				args.IsValid = Validation.ValidateDate(this.calSaleDate.Date.ToString());
			}
		}

		protected void cusValArtistName_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (string.IsNullOrEmpty(this.txtArtistName.Text.Trim()))
			{
				args.IsValid = false;
			}
		}

		protected void cusValDateOfBirth_ServerValidate(object source, ServerValidateEventArgs args)
		{
			string val = this.txtDateOfBirth.Text.Replace("yyyy", "");
			if (string.IsNullOrEmpty(val))
			{
				args.IsValid = true;
			}
			else if (!Regex.Match(val, "\\d{4}$").Success)
			{
				args.IsValid = false;
			}
			else
			{
				args.IsValid = true;
			}
		}

		protected void cusValDateOFDeath_ServerValidate(object source, ServerValidateEventArgs args)
		{
			string val = this.txtDateDeath.Text.Replace("yyyy", "");
			if (string.IsNullOrEmpty(val))
			{
				args.IsValid = true;
			}
			else if (!Regex.Match(val, "\\d{4}$").Success)
			{
				args.IsValid = false;
			}
			else
			{
				args.IsValid = true;
			}
		}

		protected void cusValNationality_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (!string.IsNullOrEmpty(this.Nationality))
			{
				args.IsValid = true;
			}
			else
			{
				args.IsValid = false;
			}
		}

		protected void cusValSalesPrice_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (!string.IsNullOrEmpty(this.txtSalePrice.Text))
			{
				args.IsValid = true;
			}
			else
			{
				args.IsValid = false;
			}
		}

		protected void cusValTitleOfWork_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (!string.IsNullOrEmpty(this.txtTitleOfWork.Text))
			{
				args.IsValid = true;
			}
			else
			{
				args.IsValid = false;
			}
		}

		public void HidPanel()
		{
			this.idProduct.Style.Add(HtmlTextWriterStyle.Display, "none");
		}
	}
}