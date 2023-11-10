using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Models;
using DacsOnline.Model.Business_Objects;

namespace DacsOnline.Service.Service.Interfaces
{
    public interface IARRArtistSearchService
    {
        /// <summary>
        /// Gets the artists.
        /// </summary>
        /// <param name="Year">The year.</param>
        /// <param name="ArtistFirstName">First name of the artist.</param>
        /// <param name="ArtistLastName">Last name of the artist.</param>
        /// <param name="Pgae">The pgae.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="TotalItems">The total items.</param>
        /// <returns></returns>
        List<ArtistARRModel> GetArtists(string Year, string ArtistFirstName, string ArtistLastName, int Pgae, int PageSize, out int TotalItems, string dataSource);

        /// <summary>
        /// Gets the sales years.
        /// </summary>
        /// <returns></returns>
        List<string> GetSalesYears();
    }
}
