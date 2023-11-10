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
	public class CLReproductions : UserControl
	{
		protected HyperLink nypEdit;

		protected HtmlGenericControl reproductionBig;

		protected TextBox txtAtistname;

		protected CustomValidator cusValtxtAtistname;

		protected TextBox txtTitleOfWork;

		protected CustomValidator cusValtxtTitleOfWork;

		protected CheckBoxList chkContextofWork;

		protected Button btOpenFileUploadReproductions;

		protected Label ltlFileName;

		protected FileUpload FileUploadReproduction;

		protected CustomValidator cusValFileValidator;

		protected TextBox txtDepictedWork;

		protected HtmlGenericControl reproducctionsmall;

		protected Label lbArtistName;

		protected Label LbTitlework;

		public string ArtistName
		{
			get
			{
				return this.txtAtistname.Text.Trim();
			}
		}

		public List<string> ContextOfUse
		{
			get
			{
				List<string> obj = new List<string>();
				foreach (ListItem item in this.chkContextofWork.Items)
				{
					if (item.Selected)
					{
						obj.Add(item.Value);
					}
				}
				return obj;
			}
		}

		public string DepictedWork
		{
			get
			{
				return this.txtDepictedWork.Text.Trim();
			}
		}

		public string LinkTitleReproductions
		{
			set
			{
				this.nypEdit.Text = string.Concat("Reproduction ", value, " Edit");
			}
		}

		public HttpPostedFile PostedFile
		{
			get
			{
				HttpPostedFile postedFile;
				if (this.FileUploadReproduction.PostedFile == null)
				{
					postedFile = null;
				}
				else
				{
					postedFile = this.FileUploadReproduction.PostedFile;
				}
				return postedFile;
			}
		}

		public string TitleOfWork
		{
			get
			{
				return this.txtTitleOfWork.Text.Trim();
			}
		}

		public CLReproductions()
		{
		}

		protected void cusValFileValidator_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (this.PostedFile.ContentLength > 10485760)
			{
				args.IsValid = false;
			}
		}

		protected void cusValtxtAtistname_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (string.IsNullOrEmpty(this.txtAtistname.Text.Trim()))
			{
				args.IsValid = false;
			}
		}

		protected void cusValtxtTitleOfWork_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (string.IsNullOrEmpty(this.txtTitleOfWork.Text.Trim()))
			{
				args.IsValid = false;
			}
		}

		public string GetListId()
		{
			return this.chkContextofWork.ClientID;
		}

		public void HidPanel()
		{
			this.reproductionBig.Style.Add(HtmlTextWriterStyle.Display, "none");
			this.lbArtistName.Text = this.ArtistName;
			this.LbTitlework.Text = this.TitleOfWork;
			this.reproducctionsmall.Style.Add(HtmlTextWriterStyle.Display, "block");
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			string id = this.ClientID;
			string[] clientID = new string[] { "SetFileText('", this.FileUploadReproduction.ClientID, "','", this.ltlFileName.ClientID, "')" };
			string ss = string.Concat(clientID);
			this.FileUploadReproduction.Attributes.Add("onchange", ss);
			if (!(base.Session[id] != null ? true : !this.FileUploadReproduction.HasFile))
			{
				base.Session[id] = this.FileUploadReproduction;
				this.FileUploadReproduction = (FileUpload)base.Session[id];
				this.ltlFileName.Text = this.FileUploadReproduction.FileName;
			}
			else if (!(base.Session[id] == null ? true : this.FileUploadReproduction.HasFile))
			{
				this.FileUploadReproduction = (FileUpload)base.Session[id];
				this.ltlFileName.Text = this.FileUploadReproduction.FileName;
			}
			else if (this.FileUploadReproduction.HasFile)
			{
				base.Session[id] = this.FileUploadReproduction;
				this.FileUploadReproduction = (FileUpload)base.Session[id];
				this.ltlFileName.Text = this.FileUploadReproduction.FileName;
			}
		}
	}
}