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
	[PresenterBinding(typeof(JobApplicationPackPresenter))]
	public class JobApplicationPack : MvpUserControl, IJobApplicationPackView, IView
	{
		protected HtmlGenericControl sendemail;

		protected LinkButton lnkApplication;

		protected Label lbemail;

		protected HtmlGenericControl enterEmail;

		protected TextBox txtemail;

		protected Button btnSubmit;

		protected HtmlGenericControl confirmation;

		protected HyperLink linkdownload;

		public string downloadjob
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("DownloadJobApplication"), "");
			}
		}

		public string EmailDacs
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("Email"), "");
			}
		}

		public string EmailUser
		{
			get
			{
				return this.txtemail.Text;
			}
		}

		public string jobTitle
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("Form"), "");
			}
		}

		public JobApplicationPack()
		{
		}

		protected void btnSubmit_Click(object sender, EventArgs e)
		{
			if (this.OnclickSubmit != null)
			{
				this.OnclickSubmit(sender, e);
			}
		}

		public void Display()
		{
			this.lbemail.Text = this.EmailDacs;
		}

		public void HideConfirmation()
		{
			this.confirmation.Visible = false;
		}

		public void HideSubmit()
		{
			this.enterEmail.Visible = false;
			this.linkdownload.NavigateUrl = this.downloadjob;
		}

		protected void lnkApplication_Click(object sender, EventArgs e)
		{
			if (this.OnclickLink != null)
			{
				this.OnclickLink(sender, e);
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.OnLoad != null)
			{
				this.OnLoad(sender, e);
				if (!base.IsPostBack)
				{
					this.confirmation.Visible = false;
					this.sendemail.Visible = true;
				}
			}
		}

		public void ShowConfirmation()
		{
			this.confirmation.Visible = true;
		}

		public void ShowSubmit()
		{
			this.enterEmail.Visible = true;
		}

		public event EventHandler OnclickLink;

		public event EventHandler OnclickSubmit;

		public event EventHandler OnLoad;
	}
}