using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Business_Objects;

namespace DacsOnline.Model.RepostioriesInterfaces
{
    public interface IARRArtistSearchRepository
    {
        #region //Public Methods
        /// <summary>
        /// Gets the artists data.
        /// </summary>
        /// <returns></returns>
        List<Artist> GetArtistsData();


        /// <summary>
        /// Gets the sales years.
        /// </summary>
        /// <returns></returns>
        List<string> GetSalesYears();

        /// <summary>
        /// Gets the nationalities.
        /// </summary>
        /// <returns></returns>
        List<Nationality> GetNationalities();
        #endregion
    }
}
