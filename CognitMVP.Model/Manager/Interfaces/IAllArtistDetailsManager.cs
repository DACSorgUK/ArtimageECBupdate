using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Models;
using DacsOnline.Model.Business_Objects;

namespace DacsOnline.Model.Manager.Interfaces
{
    public interface IAllArtistDetailsManager
    {

        /// <summary>
        /// Searches the artist.
        /// </summary>
        /// <param name="StartingWord">The starting word.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="TotalItems">The total items.</param>
        /// <returns></returns>
        List<ArtistCombined> SearchArtist(string StartingWord, int page, int pageSize, out int TotalItems, string dataSource);

        /// <summary>
        /// Gets the charactors.
        /// </summary>
        /// <returns></returns>
        List<string> GetCharactors();
    }
}
