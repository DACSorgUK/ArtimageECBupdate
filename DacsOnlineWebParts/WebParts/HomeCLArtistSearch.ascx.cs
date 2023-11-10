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
    [PresenterBinding(typeof(CLArtistSearchPresenter))]
    public partial class HomeCLArtistSearch : MvpUserControl, ICLArtistSearchView
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
                    if ((!string.IsNullOrEmpty(ArtistFirstName)) || (!string.IsNullOrEmpty(ArtistLastName)))
                    {
                        FilterOnClick(YearSale, ArtistFirstName.Trim(), ArtistLastName.Trim(), CurrentPage, PageSize, dataSource);
                    }

              
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the BtnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (FilterOnClick != null)
            {
                string urlParaMeter = Artist_First_Name + "=" + txtArtistFirstName.Text.Trim() + "&" + Artist_Last_Name + "=" + txtArtistLastName.Text.Trim() + "&" + Year_Sale + "=" + YearSale + "&PAGE_SIZE=" + PageSize;
                Response.Redirect(CLSearchUrl + "?" + urlParaMeter + "&CURRENT_PAGE=1");
            }
        }



        #endregion

        #region //Public Properties

        /// <summary>
        /// Gets the artist details URL.
        /// </summary>
        public string ArtistDetailsUrl
        {
            get { return ValidationHelper.GetString(this.GetValue("ArtistsDetailsURL"), ""); }
        }


        /// <summary>
        /// Gets the CL calculator URL.
        /// </summary>
        public string CLCalculatorUrl
        {
            get { return ValidationHelper.GetString(this.GetValue("CLCalculatorURL"), ""); }
        }

        /// <summary>
        /// Gets the AZ URL.
        /// </summary>
        public string AZUrl
        {
            get { return ValidationHelper.GetString(this.GetValue("AZUrl"), ""); }
        }


        /// <summary>
        /// Gets the arr search URL.
        /// </summary>
        public string CLSearchUrl
        {
            get { return ValidationHelper.GetString(this.GetValue("CLSearchUrl"), ""); }
        }



        /// <summary>
        /// Gets the year sale.
        /// </summary>
        private string YearSale
        {
            get
            {
                return DateTime.Now.ToString();

            }

        }

        /// <summary>
        /// Gets the name of the artist.
        /// </summary>
        /// <value>
        /// The name of the artist.
        /// </value>
        private string ArtistFirstName
        {
            get
            {
                if (Request.QueryString[this.Artist_First_Name] != null)
                {

                    return Request.QueryString[this.Artist_First_Name].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }

        }

        /// <summary>
        /// Gets the last name of the artist.
        /// </summary>
        /// <value>
        /// The last name of the artist.
        /// </value>
        private string ArtistLastName
        {
            get
            {
                if (Request.QueryString[this.Artist_Last_Name] != null)
                {

                    return Request.QueryString[this.Artist_Last_Name].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }

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
        /// Displays the specified artist.
        /// </summary>
        /// <param name="artist">The artist.</param>
        public void Display(List<ArtistCLModel> artist)
        {
            //if (artist.Count > 0)
            //{
            //    panlNoresult.Visible = false;
            //    RepeterArtist.DataSource = artist;
            //    RepeterArtist.DataBind();
            //    ltlConfirm.Visible = true;
            //    confirmHead.Visible = true;
            //}
            //else
            //{
            //    panlNoresult.Visible = true;
            //    ltlArtistName.Text = ArtistFirstName + " " + ArtistLastName; ;
            //    ltlConfirm.Visible = false;
            //    confirmHead.Visible = false;
            //}

        }

        /// <summary>
        /// Sets the paging control.
        /// </summary>
        /// <param name="totalItems">The total items.</param>
        /// <param name="recordsPerPage">The records per page.</param>
        /// <param name="currentPage">The current page.</param>
        /// <param name="artistFirstName">First name of the artist.</param>
        /// <param name="artistLastName">Last name of the artist.</param>
        /// <param name="Year">The year.</param>
        public void SetPagingControl(int totalItems, int recordsPerPage, int currentPage, string artistFirstName, string artistLastName, string Year)
        {
            //string urlParaMeter = Artist_First_Name + "=" + artistFirstName + "&" + Artist_Last_Name + "=" + artistLastName + "&" + Year_Sale + "=" + Year + "&PAGE_SIZE=" + recordsPerPage;
            //PagingControlBottom.ItemCount = totalItems;
            //PagingControlBottom.RecordsPerPage = recordsPerPage;
            //PagingControlBottom.CurrentPage = currentPage;
            //PagingControlBottom.QueryString = urlParaMeter;
            //PagingControlBottom.URL = CLSearchUrl;
            //PagingControlBottom.ReCreatePagingControl();
            //ltlConfirm.Text = string.Format("{0} results for '{1}'", totalItems, ArtistFirstName + " " + ArtistLastName);

            //btTeanRecords.NavigateUrl = CLSearchUrl + "?" + Artist_First_Name + "=" + artistFirstName + "&" + Artist_Last_Name + "=" + artistLastName + "&" + Year_Sale + "=" + Year + "&PAGE_SIZE=10&CURRENT_PAGE=1";
            //btFiftyRecords.NavigateUrl = CLSearchUrl + "?" + Artist_First_Name + "=" + artistFirstName + "&" + Artist_Last_Name + "=" + artistLastName + "&" + Year_Sale + "=" + Year + "&PAGE_SIZE=50&CURRENT_PAGE=1";

        }

        /// <summary>
        /// Sets the controls.
        /// </summary>
        public void SetControls()
        {
            if (!string.IsNullOrEmpty(ArtistFirstName))
            {
                txtArtistFirstName.Text = ArtistFirstName;
            }
            if (!string.IsNullOrEmpty(ArtistLastName))
            {
                txtArtistLastName.Text = ArtistLastName;
            }

            //if (PageSize == 50)
            //{
            //    btTeanRecords.CssClass = string.Empty;
            //    btFiftyRecords.CssClass = "selected";
            //}
            //else
            //{
            //    btFiftyRecords.CssClass = string.Empty;
            //    btTeanRecords.CssClass = "selected";
            //}

            //txtArtistFirstName.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
            //txtArtistLastName.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

        }

        #endregion

        #region //Event Handlers
        /// <summary>
        /// Occurs when [filter on click].
        /// </summary>
        public event SearchArtistInvoke FilterOnClick;

        /// <summary>
        /// Occurs when [page on load].
        /// </summary>
        public event EventHandler PageOnLoad;
        #endregion

        #region //Private Properties


        /// <summary>
        /// Current Page
        /// </summary>
        private string Artist_First_Name = "ARTIST_FIRST_NAME";

        /// <summary>
        /// 
        /// </summary>
        private string Artist_Last_Name = "ARTIST_LAST_NAME";


        /// <summary>
        /// 
        /// </summary>
        private string Year_Sale = "YEARSALE";


        /// <summary>
        /// Page Size of grid
        /// </summary>
        private const string PAGE_SIZE = "PAGE_SIZE";


        /// <summary>
        /// 
        /// </summary>
        private const string CURRENT_PAGE = "CURRENT_PAGE";
        #endregion




    }
}
