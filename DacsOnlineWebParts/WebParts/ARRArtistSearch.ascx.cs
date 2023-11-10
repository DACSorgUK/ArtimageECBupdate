using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using DacsOnline.Presentation.Presenters;
using WebFormsMvp;
using DacsOnline.Presentation.Views;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Models;
using CMS.GlobalHelper;
using System.Configuration;

namespace DacsOnlineWebParts.WebParts
{
    [PresenterBinding(typeof(ARRArtistSearchPresenter))]
    public partial class ARRArtistSearch : MvpUserControl, IARRArtistSearchView
    {
        #region //Page Methods
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
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
                        // PnlAjaxRunTime.Visible = true;
                        FilterOnClick(YearSale, ArtistFirstName.Trim(), ArtistLastName.Trim(), CurrentPage, PageSize, dataSource);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnSubmit_Click_Modal(object sender, EventArgs e)
        {
            if (SetSearchCookie != null)
            {
                SetSearchCookie(sender, e);
            }
            string urlParaMeter = Artist_First_Name + "=" + Server.UrlEncode(txtArtistFirstName.Text.Trim()) + "&" + Artist_Last_Name + "=" + Server.UrlEncode(txtArtistLastName.Text.Trim()) + "&" + Year_Sale + "=" + DateTime.Now.Year.ToString() + "&PAGE_SIZE=" + PageSize; //this has the year param, which was removed - lance@lancetek.com 20151207
                                                                                                                                                                                                                                                                                 // string urlParaMeter = Artist_First_Name + "=" + Server.UrlEncode(txtArtistFirstName.Text.Trim()) + "&" + Artist_Last_Name + "=" + Server.UrlEncode(txtArtistLastName.Text.Trim()) + "&PAGE_SIZE=" + PageSize;
            Response.Redirect(ArrSearchUrl + "?" + urlParaMeter + "&CURRENT_PAGE=1");
        }

        /// <summary>
        /// Handles the Click1 event of the btnSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string urlParaMeter = Artist_First_Name + "=" + Server.UrlEncode(txtArtistFirstName.Text.Trim()) + "&" + Artist_Last_Name + "=" + Server.UrlEncode(txtArtistLastName.Text.Trim()) + "&" + Year_Sale + "=" + DateTime.Now.Year.ToString() + "&PAGE_SIZE=" + PageSize;
            // string urlParaMeter = Artist_First_Name + "=" + Server.UrlEncode(txtArtistFirstName.Text.Trim()) + "&" + Artist_Last_Name + "=" + Server.UrlEncode(txtArtistLastName.Text.Trim()) + "&PAGE_SIZE=" + PageSize; //see comment for year above on ln 59
            Response.Redirect(ArrSearchUrl + "?" + urlParaMeter + "&CURRENT_PAGE=1");
        }


        /// <summary>
        /// Handles the ItemDataBound event of the RepeterArtist control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterItemEventArgs"/> instance containing the event data.</param>
        protected void RepeterArtist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ArtistARRModel dataItem = (ArtistARRModel)e.Item.DataItem;
            if (string.IsNullOrEmpty(dataItem.Nationality))
                dataItem.Confirmed = "";
            else
                dataItem.Confirmed = "(" + dataItem.Confirmed + ")";

            if (!string.IsNullOrWhiteSpace(dataItem.YearOfDeath))
            {
                if (!string.IsNullOrEmpty(dataItem.YearOfBirth) && !string.IsNullOrEmpty(dataItem.YearOfDeath))
                    dataItem.YearOfBirth = dataItem.YearOfBirth + "-";
            }
            else
            {
                dataItem.YearOfBirth = "";
            }
            


            if (!string.IsNullOrEmpty(dataItem.Nationality) && !string.IsNullOrEmpty(dataItem.YearOfBirth))
                dataItem.Confirmed = dataItem.Confirmed + ",";

        }
        #endregion

        #region //Public Properties

        /// <summary>
        /// Gets the artist details URL.
        /// </summary>
        public string ArtistDetailsUrl
        {
            get { return ValidationHelper.GetString(this.GetValue("ArtistDetailsUrl"), ""); }
        }

        /// <summary>
        /// Gets the ARR calculator URL.
        /// </summary>
        public string ARRRoyaltyCalculator
        {
            get { return ValidationHelper.GetString(this.GetValue("ARRRoyaltyCalculator"), ""); }
        }

        /// <summary>
        /// Gets the AZ URL.
        /// </summary>
        public string AZUrl
        {
            get { return ValidationHelper.GetString(this.GetValue("AZUrl"), ""); }
        }

        /// <summary>
        /// Gets the nationality URL.
        /// </summary>
        public string NationalityUrl
        {
            get { return ValidationHelper.GetString(this.GetValue("NationalityUrl"), ""); }
        }


        /// <summary>
        /// Gets the arr search URL.
        /// </summary>
        public string ArrSearchUrl
        {
            get { return ValidationHelper.GetString(this.GetValue("ArrSearchUrl"), ""); }
        }



        /// <summary>
        /// Gets the year sale.
        /// </summary>
        private string YearSale
        {
            get
            {
                return DateTime.Now.Year.ToString();

                //if (Request.QueryString[this.Year_Sale] != null)
                //{

                //    return Request.QueryString[this.Year_Sale].ToString();
                //}
                //else
                //{
                //    return string.Empty;
                //}

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

                    return Server.UrlDecode(Request.QueryString[this.Artist_First_Name].ToString());
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

                    return Server.UrlDecode(Request.QueryString[this.Artist_Last_Name].ToString());
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

        public string HeaderText
        {
            get { return ValidationHelper.GetString(this.GetValue("HeaderText"), ""); }
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

        /// <summary>
        /// Displays the specified artist.
        /// </summary>
        /// <param name="artist">The artist.</param>    
        public void Display(List<ArtistARRModel> artist)
        {
            if (artist != null)
                if (artist.Count > 0)
                {
                    panlNoresult.Visible = false;
                    RepeterArtist.DataSource = artist;
                    RepeterArtist.DataBind();
                    ltlConfirm.Visible = true;
                    confirmHead.Visible = true;
                }
                else
                {
                    panlNoresult.Visible = true;
                    ltlConfirm.Visible = false;
                    confirmHead.Visible = false;
                    ltlArtistName.Text = ArtistFirstName + " " + ArtistLastName;
                }

        }

        /// <summary>
        /// Sets the paging control.
        /// </summary>
        /// <param name="totalItems">The total items.</param>
        /// <param name="recordsPerPage">The records per page.</param>
        /// <param name="currentPage">The current page.</param>
        public void SetPagingControl(int totalItems, int recordsPerPage, int currentPage, string artistFirstName, string artistLastName, string Year)
        {
            string urlParaMeter = Artist_First_Name + "=" + Server.UrlEncode(artistFirstName) + "&" + Artist_Last_Name + "=" + Server.UrlEncode(artistLastName) + "&" + Year_Sale + "=" + Year + "&PAGE_SIZE=" + recordsPerPage;
            PagingControlBottom.ItemCount = totalItems;
            PagingControlBottom.RecordsPerPage = recordsPerPage;
            PagingControlBottom.CurrentPage = currentPage;
            PagingControlBottom.QueryString = urlParaMeter;
            PagingControlBottom.URL = ArrSearchUrl;
            PagingControlBottom.ReCreatePagingControl();
            //PagingControlBottom.ClientIDMode = ClientIDMode.Static;
            //PagingControlBottom.ID = "btnPaging";
            // PagingControlBottom.CssClass += "btnPaging";
            ltlConfirm.Text = string.Format("{0} results for '{1}'", totalItems, ArtistFirstName + " " + ArtistLastName);

            btTeanRecords.NavigateUrl = ArrSearchUrl + "?" + Artist_First_Name + "=" + Server.UrlEncode(artistFirstName) + "&" + Artist_Last_Name + "=" + Server.UrlEncode(artistLastName) + "&" + Year_Sale + "=" + Year + "&PAGE_SIZE=10&CURRENT_PAGE=1";
            btFiftyRecords.NavigateUrl = ArrSearchUrl + "?" + Artist_First_Name + "=" + Server.UrlEncode(artistFirstName) + "&" + Artist_Last_Name + "=" + Server.UrlEncode(artistLastName) + "&" + Year_Sale + "=" + Year + "&PAGE_SIZE=50&CURRENT_PAGE=1";

        }

        /// <summary>
        /// Sets the controls.
        /// </summary>
        public void SetControls(bool cookieStatus)
        {
            if (!string.IsNullOrEmpty(ArtistFirstName))
            {
                txtArtistFirstName.Text = ArtistFirstName;
            }
            if (!string.IsNullOrEmpty(ArtistLastName))
            {
                txtArtistLastName.Text = ArtistLastName;
            }
            //if (!string.IsNullOrEmpty(YearSale))
            //{
            //    ddYear.SelectedValue = YearSale.Trim();
            //}
            if (PageSize == 50)
            {
                btTeanRecords.CssClass = string.Empty;
                btFiftyRecords.CssClass = "selected";
            }
            else
            {
                btFiftyRecords.CssClass = string.Empty;
                btTeanRecords.CssClass = "selected";
            }

            if (cookieStatus)
            {
                btnSubmit.CssClass = "button last-child";
            }
            else
            {
                btnSubmit.CssClass = "button show-modal";
            }

            //txtArtistFirstName.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
            //txtArtistLastName.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

        }

        /// <summary>
        /// Binds the years.
        /// </summary>
        /// <param name="Years">The years.</param>
        public void BindYears(List<string> Years)
        {
            //    ddYear.DataSource = Years;
            //    ddYear.DataBind();
        }

        #endregion

        #region //Event Handlers
        /// <summary>
        /// Occurs when [set search cookie].
        /// </summary>
        public event EventHandler SetSearchCookie;
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
        private bool ShowSearchButton
        {
            get
            {
                if (Session["ShowSearchButton"] == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }

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
