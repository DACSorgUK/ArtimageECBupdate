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
    public delegate void SearchAllArtistInvoke(string StartingWord, int Pgae, int PageSize, string dataSource);

    public class AllArtistSearchPresenter : BasePresenter<IAllArtistSearchView>, IDisposable
    {
        #region //Private Properties

        private IAllArtistSearchService _service;
        #endregion

        public AllArtistSearchPresenter(IAllArtistSearchView view, IAllArtistSearchService service)
            : base(view)
        {
            this.View.FilterOnClick += new SearchAllArtistInvoke(SearchArtist);
            this.View.PageOnLoad += new EventHandler(InitialisePage);
            _service = service;
        }

        #region //Public Methods

      
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.View.FilterOnClick -= new SearchAllArtistInvoke(SearchArtist);
            this.View.PageOnLoad -= new EventHandler(InitialisePage);
        }

        #endregion

        #region //Private Methods

        /// <summary>
        /// Searches the artist.
        /// </summary>
        /// <param name="Year">The year.</param>
        /// <param name="StartingWord">The starting word.</param>
        /// <param name="Pgae">The pgae.</param>
        /// <param name="PageSize">Size of the page.</param>
        private void SearchArtist(string StartingWord, int Pgae, int PageSize, string dataSource)
        {
            try
            {
                int totalItems;
                List<ArtistCombined> list = this._service.GetArtist(StartingWord, Pgae, PageSize, out totalItems, dataSource);
                this.View.SetPagingControl(StartingWord,totalItems, PageSize, Pgae);
                this.View.Display(list);
            }
            catch (Exception ex)
            {
                EventLogService.LogData(MessageType.Error, "AllArtistSearchPresenter-presenter", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Initialises the page.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void InitialisePage(object sender, EventArgs args)
        {
            List<string> array = this._service.GetNavigation();
            this.View.SetNavigation(array);
        }
        #endregion


    }
}
