using DacsOnline.Presentation.Presenters;
using DacsOnline.Presentation.Views;
using System;
using System.Collections.Specialized;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace DacsOnlineWebParts.WebParts
{
	[PresenterBinding(typeof(NewstitlePresenter))]
	public class TitleLatestNews : MvpUserControl, INewsTitleView, IView
	{
		protected HtmlGenericControl divtitle;

		protected Label lbTitle;

		public string Category
		{
			get
			{
				string str;
				str = (base.Request.QueryString["category"] == null ? HttpContext.GetGlobalResourceObject("DACSOnlineResources", "DefaultCategory") as string : base.Request.QueryString["category"].ToString());
				return str;
			}
		}

		public string TitleNews
		{
			get
			{
				string str;
				str = (base.Request.QueryString["title"] == null ? "N" : base.Request.QueryString["title"].ToString());
				return str;
			}
		}

		public TitleLatestNews()
		{
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.Load != null)
			{
				this.Load(sender, e);
			}
		}

		public void Showtitle()
		{
			if (!string.IsNullOrEmpty(this.TitleNews))
			{
				if (!(this.TitleNews == "N"))
				{
					this.divtitle.Visible = true;
					this.lbTitle.Text = this.Category;
				}
				else
				{
					this.divtitle.Visible = false;
				}
			}
			else if ((string.IsNullOrEmpty(this.TitleNews) ? false : !string.IsNullOrEmpty(this.Category)))
			{
				this.divtitle.Visible = true;
				this.lbTitle.Text = this.Category;
			}
		}

		public event EventHandler Load;
	}
}