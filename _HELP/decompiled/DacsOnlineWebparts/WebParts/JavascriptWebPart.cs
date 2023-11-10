using CMS.GlobalHelper;
using CMS.PortalControls;
using DacsOnline.Presentation.Presenters;
using DacsOnline.Presentation.Views;
using System;
using System.Threading;
using System.Web.UI;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace DacsOnlineWebParts.WebParts
{
	[PresenterBinding(typeof(JavascriptWebPartPresenter))]
	public class JavascriptWebPart : MvpUserControl, IJavascriptWebPartView, IView
	{
		private JavascriptWebPartPresenter obj;

		public string themes
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("DacsOnlineTheme"), "");
			}
		}

		public JavascriptWebPart()
		{
			this.obj = new JavascriptWebPartPresenter(this);
		}

		void DacsOnline.Presentation.Views.IJavascriptWebPartView.Display()
		{
			ClientScriptManager script = this.Page.ClientScript;
			if (!script.IsClientScriptBlockRegistered(base.GetType(), "cssClass"))
			{
				script.RegisterClientScriptBlock(base.GetType(), "cssClass", string.Concat("addClass('", this.themes, "')"), true);
			}
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