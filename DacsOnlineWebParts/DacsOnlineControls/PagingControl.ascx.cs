using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DacsOnline.Presentation.Presenters;

namespace DacsOnlineWebParts.DacsOnlineControls
{
    public partial class PagingControl : System.Web.UI.UserControl
    {
        #region // Private Properties
        /// <summary>
        /// Item count
        /// </summary>
        private const string ITEM_COUNT = "ITEM_COUNT";

        /// <summary>
        /// Current page
        /// </summary>
        private const string CURRENT_PAGE = "CURRENT_PAGE";

        /// <summary>
        /// Page current maximum
        /// </summary>
        private const string PAGE_CURRENT_MAX = "PAGECURRENTMAX";

        /// <summary>
        /// Page Current Minimum
        /// </summary>
        private const string PAGE_CURRENT_MIN = "PAGECURRENTMIN";

        /// <summary>
        /// Records per page
        /// </summary>
        private const string RECORDS_PER_PAGE = "RECORDS_PER_PAGE";

        /// <summary>
        /// Pages per sector
        /// </summary>
        private const string PAGES_PER_SECTOR = "PAGES_PER_SECTOR";

        /// <summary>
        /// CSS class name
        /// </summary>
        private const string CSS_CLASS = "CSS_CLASS";
        #endregion

        #region // Public Event Handlers
        /// <summary>
        /// Occurs when [page change].
        /// </summary>
        public event PageChangeEventHandler PageChange;
        #endregion

        #region //Public Properties

        /// <summary>
        /// Gets the current total.
        /// </summary>
        public int CurrentTotal { get; private set; }
        /// <summary>
        /// Gets or sets the CSS class.
        /// </summary>
        /// <value>The CSS class.</value>
        public string CssClass
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the pages per sector.
        /// </summary>
        /// <value>The pages per sector.</value>
        public int PagesPerSector
        {
            get
            {

                return int.Parse(ConfigurationManager.AppSettings["PageSectors"].ToString());
                
            }

            
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string URL
        {
            set;
            get;
        }

        /// <summary>
        /// Gets or sets the query string.
        /// </summary>
        /// <value>
        /// The query string.
        /// </value>
        public string QueryString
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the row count.
        /// </summary>
        /// <value>The row count.</value>
        public int ItemCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>The current page.</value>
        public int CurrentPage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the records per page.
        /// </summary>
        /// <value>The records per page.</value>
        public int RecordsPerPage
        {
            get;
            set;
        }
        #endregion

        #region //Private Properties
        /// <summary>
        /// Gets or sets the page current max.
        /// </summary>
        /// <value>The _page current max.</value>
        private int PageCurrentMax
        {
            set;
            get;
        }

        /// <summary>
        /// Gets or sets the page current min.
        /// </summary>
        /// <value>The page current min.</value>
        private int PageCurrentMin
        {
            set;
            get;
        }

        /// <summary>
        /// Gets the total pages per view.
        /// </summary>
        /// <value>The total pages per view.</value>
        private decimal TotalPagesPerView
        {
            get
            {
                return (((decimal)this.ItemCount / (decimal)this.RecordsPerPage)) / (decimal)this.PagesPerSector;
            }
        }

        /// <summary>
        /// Gets or sets the max no of pages.
        /// </summary>
        /// <value>The max no of pages.</value>
        private decimal maxNoOfPages { get; set; }
        #endregion

        #region //Helper methods
        /// <summary>
        /// Creates the paging control.
        /// </summary>
        public void CreatePagingControl()
        {
            this.SetPageMinAndMax();
            List<int> list = new List<int>();

            for (int i = this.PageCurrentMin; i <= this.PageCurrentMax; i++)
            {
                list.Add(i);
            }

            rptPaging.DataSource = list;
            rptPaging.DataBind();

            if (ItemCount > 0)
            {

                if (this.maxNoOfPages == this.CurrentPage)
                {
                    lnkNext.Visible = false;
                }
                else
                {
                    lnkNext.Visible = true;
                }
                if (this.CurrentPage == 1)
                {
                    lnkPrevious.Visible = false;
                }
                else
                {
                    lnkPrevious.Visible = true;
                }
            }
            else
            {
                lnkNext.Visible = false;
                lnkPrevious.Visible = false;
            }
        }

        /// <summary>
        /// Sets the current page properties.
        /// </summary>
        public void SetCurrentPageProperties()
        {
            CurrentTotal = (this.CurrentPage * this.RecordsPerPage) > this.ItemCount ? this.ItemCount : this.CurrentPage * this.RecordsPerPage;
            ltlTotalItems.Text = "&nbsp;(" + this.ItemCount.ToString() + ")&nbsp;";
            ltlCurrentValue.Text = CurrentTotal.ToString();
        }

        /// <summary>
        /// Creates the paging control.
        /// </summary>
        public void ReCreatePagingControl()
        {
            this.CreatePagingControl();
            this.SetCurrentPageProperties();
            int previous = this.CurrentPage == 1 ? this.CurrentPage : (this.CurrentPage - 1);
            int next = (this.CurrentPage * this.RecordsPerPage >= this.ItemCount) ? this.CurrentPage : (this.CurrentPage + 1);
            lnkPrevious.NavigateUrl = URL+"?" + QueryString + "&CURRENT_PAGE=" + previous.ToString(); ;
            lnkNext.NavigateUrl = URL + "?" + QueryString + "&CURRENT_PAGE=" + next.ToString();
        }
        #endregion

        #region // Protected Page Methods
       

        /// <summary>
        /// Handles the OnItemDataBound event of the rptPaging control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterItemEventArgs"/> instance containing the event data.</param>
        protected void rptPaging_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int page = (int)e.Item.DataItem;

                HyperLink btnPaging = (HyperLink)e.Item.FindControl("btnPaging");
                if (btnPaging != null)
                {
                    btnPaging.Text = page.ToString();
                    btnPaging.NavigateUrl = URL+"?" + QueryString + "&CURRENT_PAGE=" + page.ToString();

                    //btnPaging.CommandArgument = page.ToString();
                    //btnPaging.Click += new EventHandler(btnPaging_OnClick);
                    if (this.CurrentPage == page)
                    {
                        btnPaging.CssClass = "selected btnPaging";
                    }
                    else
                    {
                        btnPaging.CssClass = "btnPaging";
                    }
                }
            }
        }
        #endregion

        #region private methods
        /// <summary>
        /// Sets the page min and max.
        /// </summary>
        private void SetPageMinAndMax()
        {
            this.maxNoOfPages = Math.Ceiling((decimal)this.ItemCount / (decimal)this.RecordsPerPage);

            int sectorPageBelongs = (int)Math.Ceiling((decimal)this.CurrentPage / (decimal)this.PagesPerSector);

            ////if (sectorPageBelongs == 1)
            ////{
            ////    this.PageCurrentMin = sectorPageBelongs;
            ////}
            ////else
            ////{
            this.PageCurrentMin = (sectorPageBelongs * this.PagesPerSector) - (this.PagesPerSector - 1);
            ////}

            this.PageCurrentMax = sectorPageBelongs * this.PagesPerSector;

            if (this.PageCurrentMax > maxNoOfPages)
            {
                this.PageCurrentMax = (int)maxNoOfPages;
            }
        }
        #endregion
    }
}