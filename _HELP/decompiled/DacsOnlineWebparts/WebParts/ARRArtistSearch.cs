using CMS.GlobalHelper;
using CMS.PortalControls;
using DacsOnline.Model.Models;
using DacsOnline.Model.Utilities;
using DacsOnline.Presentation.Presenters;
using DacsOnline.Presentation.Views;
using DacsOnlineWebParts.DacsOnlineControls;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace DacsOnlineWebParts.WebParts
{
	[PresenterBinding(typeof(ARRArtistSearchPresenter))]
	public class ARRArtistSearch : MvpUserControl, IARRArtistSearchView, IView
	{
		private const string PAGE_SIZE = "PAGE_SIZE";

		private const string CURRENT_PAGE = "CURRENT_PAGE";

		private string Artist_First_Name = "ARTIST_FIRST_NAME";

		private string Artist_Last_Name = "ARTIST_LAST_NAME";

		private string Year_Sale = "YEARSALE";

		protected Panel panelArrSearch;

		protected DropDownList ddYear;

		protected TextBox txtArtistFirstName;

		protected TextBox txtArtistLastName;

		protected Button btnSubmit;

		protected HtmlGenericControl confirmHead;

		protected Literal ltlConfirm;

		protected Repeater RepeterArtist;

		protected Panel panlNoresult;

		protected Literal ltlArtistName;

		protected PagingControl PagingControlBottom;

		protected HyperLink btTeanRecords;

		protected HyperLink btFiftyRecords;

		protected DacsOnlineWebParts.DacsOnlineControls.ConformationLightbox ConformationLightbox;

		protected Button btSubmitSearch;

		public string ARRRoyaltyCalculator
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("ARRRoyaltyCalculator"), "");
			}
		}

		public string ArrSearchUrl
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("ArrSearchUrl"), "");
			}
		}

		public string ArtistDetailsUrl
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("ArtistDetailsUrl"), "");
			}
		}

		private string ArtistFirstName
		{
			get
			{
				string str;
				str = (base.Request.QueryString[this.Artist_First_Name] == null ? string.Empty : base.Server.UrlDecode(base.Request.QueryString[this.Artist_First_Name].ToString()));
				return str;
			}
		}

		private string ArtistLastName
		{
			get
			{
				string str;
				str = (base.Request.QueryString[this.Artist_Last_Name] == null ? string.Empty : base.Server.UrlDecode(base.Request.QueryString[this.Artist_Last_Name].ToString()));
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

		private int CurrentPage
		{
			get
			{
				int num;
				num = (base.Request.QueryString["CURRENT_PAGE"] == null ? 1 : int.Parse(base.Request.QueryString["CURRENT_PAGE"].ToString()));
				return num;
			}
		}

		private string ExactMatches
		{
			get;
			set;
		}

		public string NationalityUrl
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("NationalityUrl"), "");
			}
		}

		private string NoExactMatches
		{
			get;
			set;
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

		private bool ShowSearchButton
		{
			get
			{
				bool flag;
				flag = (base.Session["ShowSearchButton"] != null ? true : false);
				return flag;
			}
		}

		private string YearSale
		{
			get
			{
				string str;
				str = (base.Request.QueryString[this.Year_Sale] == null ? string.Empty : base.Request.QueryString[this.Year_Sale].ToString());
				return str;
			}
		}

		public ARRArtistSearch()
		{
		}

		public void BindYears(List<string> Years)
		{
			this.ddYear.DataSource = Years;
			this.ddYear.DataBind();
		}

		protected void btnSubmit_Click(object sender, EventArgs e)
		{
			object[] artistFirstName = new object[] { this.Artist_First_Name, "=", base.Server.UrlEncode(this.txtArtistFirstName.Text.Trim()), "&", this.Artist_Last_Name, "=", base.Server.UrlEncode(this.txtArtistLastName.Text.Trim()), "&", this.Year_Sale, "=", this.ddYear.SelectedValue, "&PAGE_SIZE=", this.PageSize };
			string urlParaMeter = string.Concat(artistFirstName);
			base.Response.Redirect(string.Concat(this.ArrSearchUrl, "?", urlParaMeter, "&CURRENT_PAGE=1"));
		}

		protected void btnSubmit_Click_Modal(object sender, EventArgs e)
		{
			if (this.SetSearchCookie != null)
			{
				this.SetSearchCookie(sender, e);
			}
			object[] artistFirstName = new object[] { this.Artist_First_Name, "=", base.Server.UrlEncode(this.txtArtistFirstName.Text.Trim()), "&", this.Artist_Last_Name, "=", base.Server.UrlEncode(this.txtArtistLastName.Text.Trim()), "&", this.Year_Sale, "=", this.ddYear.SelectedValue, "&PAGE_SIZE=", this.PageSize };
			string urlParaMeter = string.Concat(artistFirstName);
			base.Response.Redirect(string.Concat(this.ArrSearchUrl, "?", urlParaMeter, "&CURRENT_PAGE=1"));
		}

		public void Display(List<ArtistARRModel> artist)
		{
			if (artist.Count <= 0)
			{
				this.panlNoresult.Visible = true;
				this.ltlArtistName.Text = string.Concat(this.ArtistFirstName, " ", this.ArtistLastName);
			}
			else
			{
				this.panlNoresult.Visible = false;
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
					if ((!string.IsNullOrEmpty(this.ArtistFirstName) ? true : !string.IsNullOrEmpty(this.ArtistLastName)))
					{
						this.FilterOnClick(this.YearSale, this.ArtistFirstName.Trim(), this.ArtistLastName.Trim(), this.CurrentPage, this.PageSize);
					}
				}
			}
		}

		protected void RepeterArtist_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			ArtistARRModel dataItem = (ArtistARRModel)e.Item.DataItem;
			if (e.Item.ItemIndex == 0)
			{
				if (!(dataItem.Relevance == "1"))
				{
					this.ltlConfirm.Text = string.Concat(this.NoExactMatches, " ", DACSOnlineUtiles.GetMessage("ArtistSearchNoExactMatch"));
					this.confirmHead.Visible = true;
				}
				else
				{
					this.ltlConfirm.Text = string.Concat(this.ExactMatches, " ", DACSOnlineUtiles.GetMessage("ArtistSearchExactMatch"));
					this.confirmHead.Visible = true;
				}
			}
			if (!string.IsNullOrEmpty(dataItem.Nationality))
			{
				dataItem.Confirmed = string.Concat("(", dataItem.Confirmed, ")");
			}
			else
			{
				dataItem.Confirmed = "";
			}
			if ((string.IsNullOrEmpty(dataItem.YearOfBirth) ? false : !string.IsNullOrEmpty(dataItem.YearOfDeath)))
			{
				dataItem.YearOfBirth = string.Concat(dataItem.YearOfBirth, "-");
			}
			if ((string.IsNullOrEmpty(dataItem.Nationality) ? false : !string.IsNullOrEmpty(dataItem.YearOfBirth)))
			{
				dataItem.Confirmed = string.Concat(dataItem.Confirmed, ",");
			}
			if (dataItem.LastMaxRelevance)
			{
				HtmlControl divMatches = (HtmlControl)e.Item.FindControl("HeadNoMaches");
				divMatches.Attributes.Add("style", "display:block");
				Literal HeadText = (Literal)e.Item.FindControl("ltlHeader");
				HeadText.Text = string.Concat(this.NoExactMatches, " ", DACSOnlineUtiles.GetMessage("ArtistSearchNoExactMatch"));
			}
		}

		public void SetControls(bool cookieStatus)
		{
			if (!string.IsNullOrEmpty(this.ArtistFirstName))
			{
				this.txtArtistFirstName.Text = this.ArtistFirstName;
			}
			if (!string.IsNullOrEmpty(this.ArtistLastName))
			{
				this.txtArtistLastName.Text = this.ArtistLastName;
			}
			if (!string.IsNullOrEmpty(this.YearSale))
			{
				this.ddYear.SelectedValue = this.YearSale.Trim();
			}
			if (this.PageSize != 50)
			{
				this.btFiftyRecords.CssClass = string.Empty;
				this.btTeanRecords.CssClass = "selected";
			}
			else
			{
				this.btTeanRecords.CssClass = string.Empty;
				this.btFiftyRecords.CssClass = "selected";
			}
			if (!cookieStatus)
			{
				this.btnSubmit.CssClass = "button show-modal";
			}
			else
			{
				this.btnSubmit.CssClass = "button last-child";
			}
		}

		public bool SetMoreInfoMessage(string message1, string message2)
		{
			return ((!string.IsNullOrEmpty(message1) ? true : !string.IsNullOrEmpty(message2)) ? true : false);
		}

		public void SetPagingControl(int totalItems, int recordsPerPage, int currentPage, string artistFirstName, string artistLastName, string Year, int exactMatches)
		{
			object[] objArray = new object[] { this.Artist_First_Name, "=", base.Server.UrlEncode(artistFirstName), "&", this.Artist_Last_Name, "=", base.Server.UrlEncode(artistLastName), "&", this.Year_Sale, "=", Year, "&PAGE_SIZE=", recordsPerPage };
			string urlParaMeter = string.Concat(objArray);
			this.PagingControlBottom.ItemCount = totalItems;
			this.PagingControlBottom.RecordsPerPage = recordsPerPage;
			this.PagingControlBottom.CurrentPage = currentPage;
			this.PagingControlBottom.QueryString = urlParaMeter;
			this.PagingControlBottom.URL = this.ArrSearchUrl;
			this.PagingControlBottom.ReCreatePagingControl();
			this.ExactMatches = exactMatches.ToString();
			this.NoExactMatches = (totalItems - exactMatches).ToString();
			HyperLink hyperLink = this.btTeanRecords;
			string[] arrSearchUrl = new string[] { this.ArrSearchUrl, "?", this.Artist_First_Name, "=", base.Server.UrlEncode(artistFirstName), "&", this.Artist_Last_Name, "=", base.Server.UrlEncode(artistLastName), "&", this.Year_Sale, "=", Year, "&PAGE_SIZE=10&CURRENT_PAGE=1" };
			hyperLink.NavigateUrl = string.Concat(arrSearchUrl);
			HyperLink hyperLink1 = this.btFiftyRecords;
			arrSearchUrl = new string[] { this.ArrSearchUrl, "?", this.Artist_First_Name, "=", base.Server.UrlEncode(artistFirstName), "&", this.Artist_Last_Name, "=", base.Server.UrlEncode(artistLastName), "&", this.Year_Sale, "=", Year, "&PAGE_SIZE=50&CURRENT_PAGE=1" };
			hyperLink1.NavigateUrl = string.Concat(arrSearchUrl);
		}

		public event SearchArtistInvoke FilterOnClick;

		public event EventHandler PageOnLoad;

		public event EventHandler SetSearchCookie;
	}
}