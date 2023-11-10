using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DacsOnline.Presentation.Presenters;
using WebFormsMvp;
using WebFormsMvp.Web;
using DacsOnline.Presentation.Views;
using DacsOnline.Model.Models;
using System.Configuration;
using CMS.GlobalHelper;

namespace DacsOnlineWebParts.WebParts
{
    [PresenterBinding(typeof(AllArtistSearchPresenter))]
    public partial class AllArtistSearch : MvpUserControl, IAllArtistSearchView
    {
        #region //Page Methods
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// 
        string dataSource = ConfigurationManager.AppSettings["ArtistSearchSource"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (PageOnLoad != null)
                {
                    PageOnLoad(sender, e);
                }

                if (FilterOnClick != null)
                {
                    FilterOnClick(WordSelected, CurrentPage, PageSize, dataSource);

                }
            }
        }

        #endregion

        #region //Public Properties

        /// <summary>
        /// Gets the word selected.
        /// </summary>
        public string WordSelected
        {
            get
            {
                if (Request.QueryString["Letter"] != null)
                {
                    return Request.QueryString["Letter"].ToString();
                }
                else
                {
                    return "A";
                }
            }
        }



        /// <summary>
        /// Gets the artist details URL.
        /// </summary>
        public string ArtistDetailsUrl
        {
            get
            {
                return ValidationHelper.GetString(this.GetValue("ArtistDetailsUrl"), "");
            }
        }


        /// <summary>
        /// Gets the CL calculator URL.
        /// </summary>
        public string CLCalculatorUrl
        {
            get
            {
                return ValidationHelper.GetString(this.GetValue("CLCalculatorURL"), "");

            }
        }


        /// <summary>
        /// Gets the ARR calculator URL.
        /// </summary>
        public string ARRSubmitUrl
        {
            get
            {
                return ValidationHelper.GetString(this.GetValue("ARRSubmitUrl"), "");
            }
        }

        /// <summary>
        /// Gets the CL apply URL.
        /// </summary>
        public string CLApplyURL
        {
            get
            {
                return ValidationHelper.GetString(this.GetValue("CLApplyURL"), "");
            }
        }


        /// <summary>
        /// Gets all artist search URL.
        /// </summary>
        public string AllArtistSearchUrl
        {
            get { return ValidationHelper.GetString(this.GetValue("AllArtistSearchUrl"), ""); }
        }


        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        private int CurrentPage
        {
            get
            {
                if (Request.QueryString[CURRENT_PAGE] != null)
                {
                    return int.Parse(Request.QueryString[CURRENT_PAGE].ToString());
                }
                else
                {
                    return 1;
                }
            }
        }


        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        private int PageSize
        {
            get
            {
                if (Request.QueryString[PAGE_SIZE] != null)
                {
                    return int.Parse(Request.QueryString[PAGE_SIZE].ToString());
                }
                else
                {
                    return 10;
                }
            }
        }


        #endregion

        #region //Public Methods
        /// <summary>
        /// Sets the more info message.
        /// </summary>
        /// <param name="message1">The message1.</param>
        /// <param name="message2">The message2.</param>
        /// <returns></returns>
        public bool SetMoreInfoMessage(string message1, string message2)
        {
            if (string.IsNullOrEmpty(message1) && string.IsNullOrEmpty(message2))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        protected void RepeterArtist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ArtistCombined dataItem = (ArtistCombined)e.Item.DataItem;

            //if (!string.IsNullOrWhiteSpace(dataItem.YearOfDeath))
            //{

            //}
            //else
            //{
            //    dataItem.YearOfBirth = "";
            //}

            if (!string.IsNullOrWhiteSpace(dataItem.YearOfDeath))
            {
                if (!string.IsNullOrWhiteSpace(dataItem.Nationality))
                {
                    dataItem.Nationality = dataItem.Nationality + ",";
                }

                if (!string.IsNullOrEmpty(dataItem.YearOfBirth) && !string.IsNullOrEmpty(dataItem.YearOfDeath))
                    dataItem.YearOfBirth = dataItem.YearOfBirth + "-";
            }
            else
            {
                dataItem.YearOfBirth = "";
            }

        }

        /// <summary>
        /// Displays the specified artist.
        /// </summary>
        /// <param name="artist">The artist.</param>
        public void Display(List<ArtistCombined> artist)
        {
            if (artist != null)
                if (artist.Count > 0)
                {
                    ltlConfirm.Text = "All names beginning with '" + WordSelected + "'";
                    RepeterArtist.DataSource = artist;
                    RepeterArtist.DataBind();
                }

        }

        /// <summary>
        /// Sets the paging control.
        /// </summary>
        /// <param name="totalItems">The total items.</param>
        /// <param name="recordsPerPage">The records per page.</param>
        /// <param name="currentPage">The current page.</param>
        public void SetPagingControl(string wordSelected, int totalItems, int recordsPerPage, int currentPage)
        {

            string urlParaMeter = "Letter" + "=" + wordSelected + "&PAGE_SIZE=" + recordsPerPage;
            PagingControlBottom.ItemCount = totalItems;
            PagingControlBottom.RecordsPerPage = recordsPerPage;
            PagingControlBottom.CurrentPage = currentPage;
            PagingControlBottom.QueryString = urlParaMeter;
            PagingControlBottom.URL = AllArtistSearchUrl;
            PagingControlBottom.ReCreatePagingControl();

            btTeanRecords.NavigateUrl = AllArtistSearchUrl + "?Letter=" + wordSelected + "&PAGE_SIZE=10&CURRENT_PAGE=1";
            btFiftyRecords.NavigateUrl = AllArtistSearchUrl + "?Letter=" + wordSelected + "&PAGE_SIZE=50&CURRENT_PAGE=1";
        }

        #endregion

        #region //Event Handlers
        /// <summary>
        /// Occurs when [filter on click].
        /// </summary>
        public event SearchAllArtistInvoke FilterOnClick;

        /// <summary>
        /// Occurs when [page on load].
        /// </summary>
        public event EventHandler PageOnLoad;
        #endregion

        #region //Private Methods
        ///// <summary>
        ///// Sets the event handlers.
        ///// </summary>
        //private void SetEventHandlers()
        //{
        //    PagingControlBottom.PageChange += new PageChangeEventHandler(this.CreatePagingControl);

        //}

        ///// <summary>
        ///// Creates the paging control.
        ///// </summary>
        ///// <param name="sender">The sender.</param>
        ///// <param name="page">The page.</param>
        //private void CreatePagingControl(object sender, string page)
        //{
        //    if (FilterOnClick != null)
        //    {
        //        //FilterOnClick(string.Empty, WordSelected, Convert.ToInt32(page), PageSize);
        //    }
        //}

        #endregion

        #region //Private Properties

        /// <summary>
        /// Page Size of grid
        /// </summary>
        private const string PAGE_SIZE = "PAGE_SIZE";

        /// <summary>
        /// 
        /// </summary>
        private const string CURRENT_PAGE = "CURRENT_PAGE";
        #endregion

        #region IAllArtistSearchView Members

        public void SetNavigation(List<string> array)
        {
            RepeaterSubscriptions.DataSource = array;
            RepeterArtist.DataBind();
        }

        #endregion
    }
}
