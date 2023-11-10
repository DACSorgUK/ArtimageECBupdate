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
    public interface ICLArtistSearchView : IView
    {
        #region //Public Methods
        /// <summary>
        /// Sets the controls.
        /// </summary>
        void SetControls();
        /// <summary>
        /// Displays the specified artist.
        /// </summary>
        /// <param name="artist">The artist.</param>
        void Display(List<ArtistCLModel> artist);

        /// <summary>
        /// Sets the paging control.
        /// </summary>
        /// <param name="totalItems">The total items.</param>
        /// <param name="recordsPerPage">The records per page.</param>
        /// <param name="currentPage">The current page.</param>
        /// <param name="artistFirstName">First name of the artist.</param>
        /// <param name="artistLastName">Last name of the artist.</param>
        /// <param name="Year">The year.</param>
        void SetPagingControl(int totalItems, int recordsPerPage, int currentPage, string artistFirstName, string artistLastName, string Year);
        #endregion

        #region //Event Handlers
        /// <summary>
        /// Occurs when [filter on click].
        /// </summary>
        event SearchArtistInvoke FilterOnClick;
        /// <summary>
        /// Occurs when [page on load].
        /// </summary>
        event EventHandler PageOnLoad;
        #endregion

        #region //Public Properties

        ///// <summary>
        ///// Gets or sets the currnt page.
        ///// </summary>
        ///// <value>
        ///// The currnt page.
        ///// </value>
        //int CurrntPage { set; get; }

        ///// <summary>
        ///// Gets or sets the size of the page.
        ///// </summary>
        ///// <value>
        ///// The size of the page.
        ///// </value>
        //int PageSize {  get; }

        ///// <summary>
        ///// Gets the year sale.
        ///// </summary>
        //string YearSale {get; }


        #endregion

    }
}
