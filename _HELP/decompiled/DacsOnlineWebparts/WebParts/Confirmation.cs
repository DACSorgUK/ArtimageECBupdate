using CMS.GlobalHelper;
using CMS.PortalControls;
using DacsOnline.Presentation.Presenters;
using DacsOnline.Presentation.Views;
using System;
using System.Collections.Specialized;
using System.Threading;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace DacsOnlineWebParts.WebParts
{
	[PresenterBinding(typeof(ConfirmationPresenter))]
	public class Confirmation : MvpUserControl, IConfirmationView, IView
	{
		protected Label LbFormName1;

		protected Label lbFormName2;

		protected Label LbemailUser;

		protected Label lbReference;

		protected Label lbFollowon;

		protected Label lbemaildacs;

		protected Label lbphone;

		public string Email
		{
			get
			{
				string str;
				str = (base.Session["emailUser"] == null ? string.Empty : base.Session["emailUser"].ToString());
				return str;
			}
		}

		public string EmailDACS
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("email"), "");
			}
		}

		public string FollowOn
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("followOn"), "");
			}
		}

		public string FormName
		{
			get
			{
				string str;
				str = (!string.IsNullOrEmpty(base.Request.QueryString["form"]) ? base.Request.QueryString["form"].ToString() : "");
				return str;
			}
		}

		public int Iduser
		{
			get
			{
				int num;
				num = (!string.IsNullOrEmpty(base.Request.QueryString["Id"]) ? int.Parse(base.Request.QueryString["Id"]) : 0);
				return num;
			}
		}

		public string Phone
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("phone"), "");
			}
		}

		public string ThanksFor
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("ThanksFor"), "");
			}
		}

		public string Title
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("Title"), "");
			}
		}

		public Confirmation()
		{
		}

		public void Display(string nameform, string refe, string useremail, string dacsemail)
		{
			this.LbFormName1.Text = this.Title;
			this.lbFormName2.Text = this.ThanksFor;
			this.lbReference.Text = refe;
			this.lbemaildacs.Text = this.EmailDACS;
			this.LbemailUser.Text = useremail;
			this.lbFollowon.Text = this.FollowOn;
			this.lbphone.Text = this.Phone;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				if (this.LoadForm != null)
				{
					this.LoadForm(sender, e);
				}
			}
		}

		public event EventHandler LoadForm;
	}
}