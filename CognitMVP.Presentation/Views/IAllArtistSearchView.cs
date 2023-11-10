using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Models;
using WebFormsMvp;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Presentation.Presenters;

namespace DacsOnline.Presentation.Views
{
    public interface IAllArtistSearchView : IView
    {
        #region //Public Methods
        /// <summary>
        /// Displays the specified artist.
        /// </summary>
        /// <param name="artist">The artist.</param>
        void Display(List<ArtistCombined> artist);

        /// <summary>
        /// Sets the paging control.
        /// </summary>
        /// <param name="wordSelected">The word selected.</param>
        /// <param name="totalItems">The total items.</param>
        /// <param name="recordsPerPage">The records per page.</param>
        /// <param name="currentPage">The current page.</param>
        void SetPagingControl(string wordSelected, int totalItems, int recordsPerPage, int currentPage);

        /// <summary>
        /// Sets the navigation.
        /// </summary>
        /// <param name="array">The array.</param>
        void SetNavigation(List<string> array);
        #endregion

        #region //Event Handlers
        /// <summary>
        /// Occurs when [filter on click].
        /// </summary>
        event SearchAllArtistInvoke FilterOnClick;
        /// <summary>
        /// Occurs when [page on load].
        /// </summary>
        event EventHandler PageOnLoad;
        #endregion

    }
}
