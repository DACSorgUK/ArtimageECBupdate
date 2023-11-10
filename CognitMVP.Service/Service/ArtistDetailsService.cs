using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Service.Service.Interfaces;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Enums;
using DacsOnline.Model.Models;

namespace DacsOnline.Service.Service
{
    public class ArtistDetailsService : BaseService<IArtistDetailsManager>, IArtistDetailsService
    {
        #region //Constructor
        public ArtistDetailsService(IArtistDetailsManager ArtistDetailsManager)
            : base(ArtistDetailsManager)
        {
        }

        #endregion

        #region //Public Methods
        /// <summary>
        /// Gets the artist.
        /// </summary>
        /// <param name="idArtist">The id artist.</param>
        /// <returns></returns>
        public ArtistCombined GetArtist(int idArtist, string idArtistString)
        {
            ArtistCombined _artist = null;
            try
            {
                _artist = ServiceManager.GetArtist(idArtist, idArtistString);

            }
            catch (Exception ee)
            {
                EventLogService.LogData(MessageType.Error, "ArtistDetailsService-GetArtist", ee.Message);
                return null;
            }

            return _artist;
        }
        #endregion
    }
}
