using CMS.GlobalHelper;
using CMS.PortalControls;
using DacsOnline.Model.Models;
using DacsOnline.Presentation.Presenters;
using DacsOnline.Presentation.Views;
using DacsOnlineWebParts.DacsOnlineControls;
using System;
using System.Collections.Generic;
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
	[PresenterBinding(typeof(AllArtistSearchPresenter))]
	public class AllArtistSearch : MvpUserControl, IAllArtistSearchView, IView
	{
		private const string PAGE_SIZE = "PAGE_SIZE";

		private const string CURRENT_PAGE = "CURRENT_PAGE";

		protected Repeater RepeaterSubscriptions;

		protected HtmlGenericControl confirmHead;

		protected Literal ltlConfirm;

		protected Repeater RepeterArtist;

		protected PagingControl PagingControlBottom;

		protected HyperLink btTeanRecords;

		protected HyperLink btFiftyRecords;

		public string AllArtistSearchUrl
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("AllArtistSearchUrl"), "");
			}
		}

		public string ARRSubmitUrl
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("ARRSubmitUrl"), "");
			}
		}

		public string ArtistDetailsUrl
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("ArtistDetailsUrl"), "");
			}
		}

		public string CLApplyURL
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("CLApplyURL"), "");
			}
		}

		public string CLCalculatorUrl
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("CLCalculatorURL"), "");
			}
		}

		private int CurrentPage
		{
			get
			{
				int num;
				num = (base.Request.QueryString["CURRENT_PAGE"] == null ? 1 : int.Parse(base.Request.QueryString["CURRENT_PAGE"].ToString()));
				return num;
			}
		}

		private int PageSize
		{
			get
			{
				int num;
				num = (base.Request.QueryString["PAGE_SIZE"] == null ? 10 : int.Parse(base.Request.QueryString["PAGE_SIZE"].ToString()));
				return num;
			}
		}

		public string WordSelected
		{
			get
			{
				string str;
				str = (base.Request.QueryString["Letter"] == null ? "A" : base.Request.QueryString["Letter"].ToString());
				return str;
			}
		}

		public AllArtistSearch()
		{
		}

		public void Display(List<ArtistCombined> artist)
		{
			if (artist.Count > 0)
			{
				this.ltlConfirm.Text = string.Concat("All names beginning with '", this.WordSelected, "'");
				this.RepeterArtist.DataSource = artist;
				this.RepeterArtist.DataBind();
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				if (this.PageOnLoad != null)
				{
					this.PageOnLoad(sender, e);
				}
				if (this.FilterOnClick != null)
				{
					this.FilterOnClick(this.WordSelected, this.CurrentPage, this.PageSize);
				}
			}
		}

		public bool SetMoreInfoMessage(string message1, string message2)
		{
			return ((!string.IsNullOrEmpty(message1) ? true : !string.IsNullOrEmpty(message2)) ? true : false);
		}

		public void SetNavigation(List<string> array)
		{
			this.RepeaterSubscriptions.DataSource = array;
			this.RepeterArtist.DataBind();
		}

		public void SetPagingControl(string wordSelected, int totalItems, int recordsPerPage, int currentPage)
		{
			object[] objArray = new object[] { "Letter=", wordSelected, "&PAGE_SIZE=", recordsPerPage };
			string urlParaMeter = string.Concat(objArray);
			this.PagingControlBottom.ItemCount = totalItems;
			this.PagingControlBottom.RecordsPerPage = recordsPerPage;
			this.PagingControlBottom.CurrentPage = currentPage;
			this.PagingControlBottom.QueryString = urlParaMeter;
			this.PagingControlBottom.URL = this.AllArtistSearchUrl;
			this.PagingControlBottom.ReCreatePagingControl();
			this.btTeanRecords.NavigateUrl = string.Concat(this.AllArtistSearchUrl, "?Letter=", wordSelected, "&PAGE_SIZE=10&CURRENT_PAGE=1");
			this.btFiftyRecords.NavigateUrl = string.Concat(this.AllArtistSearchUrl, "?Letter=", wordSelected, "&PAGE_SIZE=50&CURRENT_PAGE=1");
		}

		public event SearchAllArtistInvoke FilterOnClick;

		public event EventHandler PageOnLoad;
	}
}