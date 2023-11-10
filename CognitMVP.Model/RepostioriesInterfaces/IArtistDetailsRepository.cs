using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Business_Objects;

namespace DacsOnline.Model.RepostioriesInterfaces
{
    public interface IArtistDetailsRepository
    {
        #region //Public Methods
        
        /// <summary>
        /// Gets the artist data.
        /// </summary>
        /// <returns></returns>
        Artist GetArtistData(int idArtist);
        #endregion
    }
}
