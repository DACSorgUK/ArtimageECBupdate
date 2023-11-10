using DacsOnline.Presentation.Presenters;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DacsOnlineWebParts.DacsOnlineControls
{
	public class PagingControl : UserControl
	{
		private const string ITEM_COUNT = "ITEM_COUNT";

		private const string CURRENT_PAGE = "CURRENT_PAGE";

		private const string PAGE_CURRENT_MAX = "PAGECURRENTMAX";

		private const string PAGE_CURRENT_MIN = "PAGECURRENTMIN";

		private const string RECORDS_PER_PAGE = "RECORDS_PER_PAGE";

		private const string PAGES_PER_SECTOR = "PAGES_PER_SECTOR";

		private const string CSS_CLASS = "CSS_CLASS";

		protected Literal ltlCurrentValue;

		protected Literal ltlTotalItems;

		protected HyperLink lnkPrevious;

		protected Repeater rptPaging;

		protected HyperLink lnkNext;

		public string CssClass
		{
			get;
			set;
		}

		public int CurrentPage
		{
			get;
			set;
		}

		public int CurrentTotal
		{
			get;
			private set;
		}

		public int ItemCount
		{
			get;
			set;
		}

		private decimal maxNoOfPages
		{
			get;
			set;
		}

		private int PageCurrentMax
		{
			get;
			set;
		}

		private int PageCurrentMin
		{
			get;
			set;
		}

		public int PagesPerSector
		{
			get
			{
				int num = int.Parse(ConfigurationManager.AppSettings["PageSectors"].ToString());
				return num;
			}
		}

		public string QueryString
		{
			get;
			set;
		}

		public int RecordsPerPage
		{
			get;
			set;
		}

		private decimal TotalPagesPerView
		{
			get
			{
				return (this.ItemCount / this.RecordsPerPage) / this.PagesPerSector;
			}
		}

		public string URL
		{
			get;
			set;
		}

		public PagingControl()
		{
		}

		public void CreatePagingControl()
		{
			this.SetPageMinAndMax();
			List<int> list = new List<int>();
			for (int i = this.PageCurrentMin; i <= this.PageCurrentMax; i++)
			{
				list.Add(i);
			}
			this.rptPaging.DataSource = list;
			this.rptPaging.DataBind();
			if (this.ItemCount <= 0)
			{
				this.lnkNext.Visible = false;
				this.lnkPrevious.Visible = false;
			}
			else
			{
				if (!(this.maxNoOfPages == this.CurrentPage))
				{
					this.lnkNext.Visible = true;
				}
				else
				{
					this.lnkNext.Visible = false;
				}
				if (this.CurrentPage != 1)
				{
					this.lnkPrevious.Visible = true;
				}
				else
				{
					this.lnkPrevious.Visible = false;
				}
			}
		}

		public void ReCreatePagingControl()
		{
			this.CreatePagingControl();
			this.SetCurrentPageProperties();
			int previous = (this.CurrentPage == 1 ? this.CurrentPage : this.CurrentPage - 1);
			int next = (this.CurrentPage * this.RecordsPerPage >= this.ItemCount ? this.CurrentPage : this.CurrentPage + 1);
			HyperLink hyperLink = this.lnkPrevious;
			string[] uRL = new string[] { this.URL, "?", this.QueryString, "&CURRENT_PAGE=", previous.ToString() };
			hyperLink.NavigateUrl = string.Concat(uRL);
			HyperLink hyperLink1 = this.lnkNext;
			uRL = new string[] { this.URL, "?", this.QueryString, "&CURRENT_PAGE=", next.ToString() };
			hyperLink1.NavigateUrl = string.Concat(uRL);
		}

		protected void rptPaging_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if ((e.Item.ItemType == ListItemType.Item ? true : e.Item.ItemType == ListItemType.AlternatingItem))
			{
				int page = (int)e.Item.DataItem;
				HyperLink btnPaging = (HyperLink)e.Item.FindControl("btnPaging");
				if (btnPaging != null)
				{
					btnPaging.Text = page.ToString();
					string[] uRL = new string[] { this.URL, "?", this.QueryString, "&CURRENT_PAGE=", page.ToString() };
					btnPaging.NavigateUrl = string.Concat(uRL);
					if (this.CurrentPage == page)
					{
						btnPaging.CssClass = "selected";
					}
				}
			}
		}

		public void SetCurrentPageProperties()
		{
			this.CurrentTotal = (this.CurrentPage * this.RecordsPerPage > this.ItemCount ? this.ItemCount : this.CurrentPage * this.RecordsPerPage);
			Literal literal = this.ltlTotalItems;
			int itemCount = this.ItemCount;
			literal.Text = string.Concat("&nbsp;(", itemCount.ToString(), ")&nbsp;");
			this.ltlCurrentValue.Text = this.CurrentTotal.ToString();
		}

		private void SetPageMinAndMax()
		{
			this.maxNoOfPages = Math.Ceiling(this.ItemCount / this.RecordsPerPage);
			int sectorPageBelongs = (int)Math.Ceiling(this.CurrentPage / this.PagesPerSector);
			this.PageCurrentMin = sectorPageBelongs * this.PagesPerSector - (this.PagesPerSector - 1);
			this.PageCurrentMax = sectorPageBelongs * this.PagesPerSector;
			if (this.PageCurrentMax > this.maxNoOfPages)
			{
				this.PageCurrentMax = (int)this.maxNoOfPages;
			}
		}

		public event PageChangeEventHandler PageChange;
	}
}