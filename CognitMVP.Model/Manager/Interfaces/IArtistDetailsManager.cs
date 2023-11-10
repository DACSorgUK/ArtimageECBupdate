using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Models;

namespace DacsOnline.Model.Manager.Interfaces
{
    public interface IArtistDetailsManager
    {
        /// <summary>
        /// Gets the artist.
        /// </summary>
        /// <param name="idArtist">The id artist.</param>
        /// <returns></returns>
        ArtistCombined GetArtist(int idArtist, string idArtistString);
    }
}
