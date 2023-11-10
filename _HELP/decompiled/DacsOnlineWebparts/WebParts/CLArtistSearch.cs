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
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace DacsOnlineWebParts.WebParts
{
	[PresenterBinding(typeof(CLArtistSearchPresenter))]
	public class CLArtistSearch : MvpUserControl, ICLArtistSearchView, IView
	{
		private const string PAGE_SIZE = "PAGE_SIZE";

		private const string CURRENT_PAGE = "CURRENT_PAGE";

		protected Panel panelArrSearch;

		protected TextBox txtArtistFirstName;

		protected TextBox txtArtistLastName;

		protected Button btSubmitSearch;

		protected HtmlGenericControl confirmHead;

		protected Literal ltlConfirm;

		protected Repeater RepeterArtist;

		protected Panel panlNoresult;

		protected HtmlGenericControl H2;

		protected Literal Literal1;

		protected HtmlGenericControl H1;

		protected Literal ltlArtistName2;

		protected Literal ltlArtistName;

		protected PagingControl PagingControlBottom;

		protected HyperLink btTeanRecords;

		protected HyperLink btFiftyRecords;

		private string Artist_First_Name = "ARTIST_FIRST_NAME";

		private string Artist_Last_Name = "ARTIST_LAST_NAME";

		private string Year_Sale = "YEARSALE";

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

		public string CLApplyUrl
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("CLApplyUrl"), "");
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

		private string ExactMatches
		{
			get;
			set;
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

		private string YearSale
		{
			get
			{
				return DateTime.Now.Year.ToString();
			}
		}

		public CLArtistSearch()
		{
		}

		protected void BtnSearch_Click(object sender, EventArgs e)
		{
			if (this.FilterOnClick != null)
			{
				object[] artistFirstName = new object[] { this.Artist_First_Name, "=", base.Server.UrlEncode(this.txtArtistFirstName.Text.Trim()), "&", this.Artist_Last_Name, "=", base.Server.UrlEncode(this.txtArtistLastName.Text.Trim()), "&", this.Year_Sale, "=", this.YearSale, "&PAGE_SIZE=", this.PageSize };
				string urlParaMeter = string.Concat(artistFirstName);
				base.Response.Redirect(string.Concat(this.CLSearchUrl, "?", urlParaMeter, "&CURRENT_PAGE=1"));
			}
		}

		public void Display(List<ArtistCLModel> artist)
		{
			if (artist.Count <= 0)
			{
				this.H2.Visible = false;
				this.panlNoresult.Visible = true;
				this.ltlArtistName.Text = string.Concat(this.ArtistFirstName, " ", this.ArtistLastName);
				this.ltlArtistName2.Text = string.Concat(this.ArtistFirstName, " ", this.ArtistLastName);
				this.ltlConfirm.Visible = false;
				this.confirmHead.Visible = false;
			}
			else
			{
				this.H2.Visible = true;
				this.panlNoresult.Visible = false;
				this.RepeterArtist.DataSource = artist;
				this.RepeterArtist.DataBind();
				this.ltlConfirm.Visible = true;
				this.confirmHead.Visible = true;
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
			ArtistCLModel dataItem = (ArtistCLModel)e.Item.DataItem;
			if (e.Item.ItemIndex == 0)
			{
				if (!(dataItem.Relevance == "1"))
				{
					this.ltlConfirm.Text = string.Concat(this.NoExactMatches, DACSOnlineUtiles.GetMessage("ArtistSearchNoExactMatch"));
					this.confirmHead.Visible = true;
				}
				else
				{
					this.ltlConfirm.Text = string.Concat(this.ExactMatches, DACSOnlineUtiles.GetMessage("ArtistSearchExactMatch"));
					this.confirmHead.Visible = true;
				}
			}
			if ((string.IsNullOrEmpty(dataItem.Nationality) ? false : !string.IsNullOrEmpty(dataItem.YearOfBirth)))
			{
				dataItem.Nationality = string.Concat(dataItem.Nationality, ",");
			}
			if ((string.IsNullOrEmpty(dataItem.YearOfBirth) ? false : !string.IsNullOrEmpty(dataItem.YearOfDeath)))
			{
				dataItem.YearOfBirth = string.Concat("lived ", dataItem.YearOfBirth, "-");
			}
			if ((string.IsNullOrEmpty(dataItem.YearOfBirth) ? false : string.IsNullOrEmpty(dataItem.YearOfDeath)))
			{
				dataItem.YearOfBirth = string.Concat("born in ", dataItem.YearOfBirth);
			}
			if (dataItem.LastMaxRelevance)
			{
				HtmlControl divMatches = (HtmlControl)e.Item.FindControl("HeadNoMaches");
				divMatches.Attributes.Add("style", "display:block");
				Literal HeadText = (Literal)e.Item.FindControl("ltlHeader");
				HeadText.Text = string.Concat(this.NoExactMatches, DACSOnlineUtiles.GetMessage("ArtistSearchNoExactMatch"));
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
			this.PagingControlBottom.URL = this.CLSearchUrl;
			this.PagingControlBottom.ReCreatePagingControl();
			this.ExactMatches = exactMatches.ToString();
			this.NoExactMatches = (totalItems - exactMatches).ToString();
			HyperLink hyperLink = this.btTeanRecords;
			string[] cLSearchUrl = new string[] { this.CLSearchUrl, "?", this.Artist_First_Name, "=", base.Server.UrlEncode(artistFirstName), "&", this.Artist_Last_Name, "=", base.Server.UrlEncode(artistLastName), "&", this.Year_Sale, "=", Year, "&PAGE_SIZE=10&CURRENT_PAGE=1" };
			hyperLink.NavigateUrl = string.Concat(cLSearchUrl);
			HyperLink hyperLink1 = this.btFiftyRecords;
			cLSearchUrl = new string[] { this.CLSearchUrl, "?", this.Artist_First_Name, "=", base.Server.UrlEncode(artistFirstName), "&", this.Artist_Last_Name, "=", base.Server.UrlEncode(artistLastName), "&", this.Year_Sale, "=", Year, "&PAGE_SIZE=50&CURRENT_PAGE=1" };
			hyperLink1.NavigateUrl = string.Concat(cLSearchUrl);
		}

		public event SearchArtistInvoke FilterOnClick;

		public event EventHandler PageOnLoad;
	}
}