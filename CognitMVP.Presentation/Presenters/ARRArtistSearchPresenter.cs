using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Presentation.Views;
using DacsOnline.Service.Service.Interfaces;
using DacsOnline.Model.Enums;
using DacsOnline.Model.Models;
using System.Web;
using DacsOnline.Model.Utilities;

namespace DacsOnline.Presentation.Presenters
{
    public delegate void SearchArtistInvoke(string Year, string ArtistFirstName,string ArtistLastName, int Pgae, int PageSize, string dataSource);
    public delegate void PageChangeEventHandler(object sender, string page);

    public class ARRArtistSearchPresenter : BasePresenter<IARRArtistSearchView>, IDisposable
    {
        #region //Private Properties

        private IARRArtistSearchService _service;
        #endregion

        public ARRArtistSearchPresenter(IARRArtistSearchView view, IARRArtistSearchService service)
            : base(view)
        {
            this.View.FilterOnClick += new SearchArtistInvoke(SearchArtist);
            this.View.PageOnLoad += new EventHandler(InitialisePage);
            this.View.SetSearchCookie += new EventHandler(SetConfirmCookie);
            _service = service;
        }

        #region //Public Methods

      
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.View.FilterOnClick -= new SearchArtistInvoke(SearchArtist);
            this.View.PageOnLoad -= new EventHandler(InitialisePage);
            this.View.SetSearchCookie -= new EventHandler(SetConfirmCookie);
        }

        #endregion

        #region //Private Methods
        /// <summary>
        /// Searches the artist.
        /// </summary>
        /// <param name="Year">The year.</param>
        /// <param name="ArtistName">Name of the artist.</param>
        /// <param name="Pgae">The pgae.</param>
        /// <param name="PageSize">Size of the page.</param>
        private void SearchArtist(string Year, string ArtistFirstName,string ArtistLastName, int Pgae, int PageSize, string dataSource)
        {
            try
            {
                int totalItems;
                List<ArtistARRModel> list = this._service.GetArtists(Year, ArtistFirstName,ArtistLastName, Pgae, PageSize, out totalItems,dataSource);
                this.View.SetPagingControl(totalItems, PageSize, Pgae, ArtistFirstName, ArtistLastName, Year);
                this.View.Display(list);
            }
            catch (Exception ex)
            {
                EventLogService.LogData(MessageType.Error, "SearchArtist-presenter", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Initialises the page.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="ee">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void InitialisePage(object sender, EventArgs ee)
        {
            this.View.BindYears(this._service.GetSalesYears());
            this.View.SetControls(ReadConfirmCookie());
        }

        /// <summary>
        /// Sets the confirm cookie.
        /// </summary>
        private void SetConfirmCookie(object sender, EventArgs ee)
        {
            HttpCookie dacsCookies = new HttpCookie(ConstantDataArtistSearch.ARRSearchFormCookie);
            System.Web.HttpContext.Current.Response.Cookies.Clear();
            System.Web.HttpContext.Current.Response.Cookies.Add(dacsCookies);
            dacsCookies.Values.Add(ConstantDataArtistSearch.ARRSearchFormCookie, "True");
            System.Web.HttpContext.Current.Response.Cookies[ConstantDataArtistSearch.ARRSearchFormCookie].Expires = DateTime.Now.AddDays(30); ;
        }

        /// <summary>
        /// Reads the confirm cookie.
        /// </summary>
        /// <returns></returns>
        private bool ReadConfirmCookie()
        {
            try
            {
                if (System.Web.HttpContext.Current.Request.Cookies[ConstantDataArtistSearch.ARRSearchFormCookie] != null
                    && (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Cookies[ConstantDataArtistSearch.ARRSearchFormCookie].Value)))
                {

                    string value = System.Web.HttpContext.Current.Request.Cookies[ConstantDataArtistSearch.ARRSearchFormCookie].Value.Replace(ConstantDataArtistSearch.ARRSearchFormCookie + "=", "");
                    return Convert.ToBoolean(value);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ee)
            {
                EventLogService.LogData(MessageType.Error, "Cookie Convert Error", ee.Message);
                return false;
            }
        }
        #endregion


    }
}
