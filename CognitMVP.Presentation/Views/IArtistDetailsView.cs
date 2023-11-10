using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormsMvp;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Models;

namespace DacsOnline.Presentation.Views
{
    public interface IArtistDetailsView : IView
    {
        #region //Public Methods
        /// <summary>
        /// Loads the specified artist.
        /// </summary>
        /// <param name="artist">The artist.</param>
        void Load(ArtistCombined artist);

        #endregion

        #region //Event Handlers
               /// <summary>
        /// Occurs when [page on load].
        /// </summary>
        event EventHandler PageOnLoad;
        #endregion

        #region //Properties
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string idArtist { set; get; }
        ///// <summary>
        ///// Gets or sets the name.
        ///// </summary>
        ///// <value>
        ///// The name.
        ///// </value>
        //string  Name { set; get; }
        ///// <summary>
        ///// Gets or sets the pseudonyms.
        ///// </summary>
        ///// <value>
        ///// The pseudonyms.
        ///// </value>
        //string Pseudonyms { set; get; }
        ///// <summary>
        ///// Gets or sets the nationality.
        ///// </summary>
        ///// <value>
        ///// The nationality.
        ///// </value>
        //string Nationality { set; get; }
        ///// <summary>
        ///// Gets or sets the dateof birth.
        ///// </summary>
        ///// <value>
        ///// The dateof birth.
        ///// </value>
        //DateTime DateofBirth { set; get; }
        ///// <summary>
        ///// Gets or sets the dateof death.
        ///// </summary>
        ///// <value>
        ///// The dateof death.
        ///// </value>
        //DateTime DateofDeath { set; get; }
        ///// <summary>
        ///// Gets or sets the website.
        ///// </summary>
        ///// <value>
        ///// The website.
        ///// </value>
        //string Website { get; set; }
        #endregion
    }
}
