using CMS.GlobalHelper;
using CMS.PortalControls;
using DacsOnline.Presentation.Presenters;
using DacsOnline.Presentation.Views;
using System;
using System.Threading;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace DacsOnlineWebParts.WebParts
{
	[PresenterBinding(typeof(ApplicationFormRequestPresenter))]
	public class ApplicationFormRequest : MvpUserControl, IApplicationFormRequestView, IView
	{
		protected Label lblEmail;

		protected Label lblTelephone;

		protected HtmlGenericControl postme;

		protected TextBox txtPost;

		protected Button btnPostForm;

		protected HtmlGenericControl confirmation;

		public string Address
		{
			get
			{
				return this.txtPost.Text;
			}
		}

		public string AdministratorEmail
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("Administrator_Email"), "");
			}
		}

		public string FormName
		{
			get
			{
				string str;
				string applicationForm = ValidationHelper.GetString(this.GetValue("FormName"), "");
				str = (!string.IsNullOrEmpty(applicationForm) ? applicationForm : string.Empty);
				return str;
			}
		}

		public string Telephone
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("Telephone"), "");
			}
		}

		public ApplicationFormRequest()
		{
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			if (this.Onclick != null)
			{
				this.Onclick(sender, e);
				this.confirmation.Visible = true;
				this.postme.Visible = false;
			}
		}

		public void Display()
		{
			this.lblEmail.Text = this.AdministratorEmail;
			this.lblTelephone.Text = this.Telephone;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.OnLoad != null)
			{
				this.OnLoad(sender, e);
			}
		}

		public event EventHandler Onclick;

		public event EventHandler OnLoad;
	}
}