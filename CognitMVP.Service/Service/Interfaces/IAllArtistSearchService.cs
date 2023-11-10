using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Models;
using DacsOnline.Model.Business_Objects;

namespace DacsOnline.Service.Service.Interfaces
{
    public interface IAllArtistSearchService
    {

        /// <summary>
        /// Gets the artist.
        /// </summary>
        /// <param name="StartingWord">The starting word.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="TotalItems">The total items.</param>
        /// <returns></returns>
        List<ArtistCombined> GetArtist(string StartingWord, int page, int pageSize, out int TotalItems, string dataSource);


        /// <summary>
        /// Gets the navigation.
        /// </summary>
        /// <returns></returns>
        List<string> GetNavigation();
    }
}
