using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Presentation.Views;
using DacsOnline.Service.Service.Interfaces;
using DacsOnline.Model.Enums;
using DacsOnline.Model.Models;

namespace DacsOnline.Presentation.Presenters
{


    public class CLArtistSearchPresenter : BasePresenter<ICLArtistSearchView>, IDisposable
    {
        #region //Private Properties

        private ICLArtistSearchService _service;
        #endregion

        public CLArtistSearchPresenter(ICLArtistSearchView view, ICLArtistSearchService service)
            : base(view)
        {
            this.View.FilterOnClick += new SearchArtistInvoke(SearchArtist);
            this.View.PageOnLoad += new EventHandler(InitialisePage);
            _service = service;
        }

        #region //Public Methods

        /// <summary>
        /// Initialises the page.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void InitialisePage(object sender, EventArgs e)
        {
            try
            {
                this.View.SetControls();
            }
            catch (Exception ex)
            {
                EventLogService.LogData(MessageType.Error, "InitialisePage-presenter", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
           this.View.FilterOnClick -= new SearchArtistInvoke(SearchArtist);
            this.View.PageOnLoad -= new EventHandler(InitialisePage);
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
        private void SearchArtist(string Year, string ArtistFirstName, string ArtistLastName, int Pgae, int PageSize, string dataSource)
        {
            try
            {
                int totalItems;
                List<ArtistCLModel> list = this._service.GetArtists(Year, ArtistFirstName,ArtistLastName, Pgae, PageSize, out totalItems, dataSource);
                this.View.SetPagingControl(totalItems, PageSize, Pgae, ArtistFirstName, ArtistLastName, Year);
                this.View.Display(list);
            }
            catch (Exception ex)
            {
                EventLogService.LogData(MessageType.Error, "SearchArtist-presenter", ex.Message);
                throw;
            }
        }
        #endregion


    }
}
