using CMS.GlobalHelper;
using CMS.PortalControls;
using DacsOnline.Presentation.Presenters;
using DacsOnline.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace DacsOnlineWebParts.WebParts
{
	[PresenterBinding(typeof(DocumentListPresenter))]
	public class DocumentListCatagories : MvpUserControl, IDocumentListView, IView
	{
		protected Repeater RepeterDocument;

		public string DocumentCatogeryUrl
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("DocumentCatogeryUrl"), "");
			}
		}

		public string SelectedDocumentCatogery
		{
			get
			{
				string str;
				if (base.Request.QueryString["category"] == null)
				{
					str = "Latest News";
				}
				else
				{
					string[] arr = base.Request.QueryString["category"].ToString().Split(new char[] { '|' });
					str = (arr.Count<string>() <= 0 ? "Latest News" : arr[0]);
				}
				return str;
			}
		}

		public DocumentListCatagories()
		{
		}

		public void Display(List<string> list)
		{
			this.RepeterDocument.DataSource = list;
			this.RepeterDocument.DataBind();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.LoadData != null)
			{
				this.LoadData(sender, e);
			}
		}

		protected void RepeterDocument_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (((string)e.Item.DataItem).Trim().Contains(this.SelectedDocumentCatogery.Trim()))
			{
				HtmlGenericControl ctrl = (HtmlGenericControl)e.Item.FindControl("hrefId");
				if (ctrl != null)
				{
					ctrl.Attributes["class"] = "highlighted";
				}
			}
		}

		public event EventHandler LoadData;
	}
}