using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Models;
using DacsOnline.Model.Business_Objects;

namespace DacsOnline.Model.Manager.Interfaces
{
    public interface IAllArtistSearchManager
    {


        /// <summary>
        /// Searches the artist.
        /// </summary>
        /// <param name="ArtistName">Name of the artist.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="TotalItems">The total items.</param>
        /// <returns></returns>
        List<ArtistARRModel> SearchArtist(string ArtistName, int page, int pageSize, out int TotalItems);
    }
}
