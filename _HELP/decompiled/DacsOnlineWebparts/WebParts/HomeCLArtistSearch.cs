using CMS.GlobalHelper;
using CMS.PortalControls;
using DacsOnline.Model.Models;
using DacsOnline.Presentation.Presenters;
using DacsOnline.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace DacsOnlineWebParts.WebParts
{
	[PresenterBinding(typeof(CLArtistSearchPresenter))]
	public class HomeCLArtistSearch : MvpUserControl, ICLArtistSearchView, IView
	{
		private const string PAGE_SIZE = "PAGE_SIZE";

		private const string CURRENT_PAGE = "CURRENT_PAGE";

		private string Artist_First_Name = "ARTIST_FIRST_NAME";

		private string Artist_Last_Name = "ARTIST_LAST_NAME";

		private string Year_Sale = "YEARSALE";

		protected Panel panelArrSearch;

		protected TextBox txtArtistFirstName;

		protected TextBox txtArtistLastName;

		protected Button btSubmitSearch;

		public string ArtistDetailsUrl
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("ArtistsDetailsURL"), "");
			}
		}

		private string ArtistFirstName
		{
			get
			{
				string str;
				str = (base.Request.QueryString[this.Artist_First_Name] == null ? string.Empty : base.Request.QueryString[this.Artist_First_Name].ToString());
				return str;
			}
		}

		private string ArtistLastName
		{
			get
			{
				string str;
				str = (base.Request.QueryString[this.Artist_Last_Name] == null ? string.Empty : base.Request.QueryString[this.Artist_Last_Name].ToString());
				return str;
			}
		}

		public string AZUrl
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("AZUrl"), "");
			}
		}

		public string CLCalculatorUrl
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("CLCalculatorURL"), "");
			}
		}

		public string CLSearchUrl
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("CLSearchUrl"), "");
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

		private string YearSale
		{
			get
			{
				return DateTime.Now.ToString();
			}
		}

		public HomeCLArtistSearch()
		{
		}

		protected void BtnSearch_Click(object sender, EventArgs e)
		{
			if (this.FilterOnClick != null)
			{
				object[] artistFirstName = new object[] { this.Artist_First_Name, "=", this.txtArtistFirstName.Text.Trim(), "&", this.Artist_Last_Name, "=", this.txtArtistLastName.Text.Trim(), "&", this.Year_Sale, "=", this.YearSale, "&PAGE_SIZE=", this.PageSize };
				string urlParaMeter = string.Concat(artistFirstName);
				base.Response.Redirect(string.Concat(this.CLSearchUrl, "?", urlParaMeter, "&CURRENT_PAGE=1"));
			}
		}

		public void Display(List<ArtistCLModel> artist)
		{
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
					if ((!string.IsNullOrEmpty(this.ArtistFirstName) ? true : !string.IsNullOrEmpty(this.ArtistLastName)))
					{
						this.FilterOnClick(this.YearSale, this.ArtistFirstName.Trim(), this.ArtistLastName.Trim(), this.CurrentPage, this.PageSize);
					}
				}
			}
		}

		public void SetControls()
		{
			if (!string.IsNullOrEmpty(this.ArtistFirstName))
			{
				this.txtArtistFirstName.Text = this.ArtistFirstName;
			}
			if (!string.IsNullOrEmpty(this.ArtistLastName))
			{
				this.txtArtistLastName.Text = this.ArtistLastName;
			}
		}

		public void SetPagingControl(int totalItems, int recordsPerPage, int currentPage, string artistFirstName, string artistLastName, string Year, int exactMatches)
		{
		}

		public event SearchArtistInvoke FilterOnClick;

		public event EventHandler PageOnLoad;
	}
}