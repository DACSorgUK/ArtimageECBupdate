using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Service.Service.Interfaces;
using DacsOnline.Model.Models;
using DacsOnline.Model.Enums;

namespace DacsOnline.Service.Service
{
    public class AllArtistSearchService : BaseService<IAllArtistDetailsManager>, IAllArtistSearchService
    {
       #region //Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ARRArtistSearchService"/> class.
        /// </summary>
        /// <param name="employeeServiceManager">The employee service manager.</param>
        public AllArtistSearchService(IAllArtistDetailsManager artistDetailsManager)
            : base(artistDetailsManager)
        {
        }

        #endregion


        #region //Public Methods



        /// <summary>
        /// Gets the artist.
        /// </summary>
        /// <param name="StartingWord">The starting word.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="TotalItems">The total items.</param>
        /// <returns></returns>
        public List<ArtistCombined> GetArtist(string StartingWord, int page, int pageSize, out int TotalItems, string dataSource)
        {
            List<ArtistCombined> model = null;
            int totalItems;
            try
            {
                List<ArtistCombined> artists = ServiceManager.SearchArtist(StartingWord, page, pageSize, out totalItems, dataSource);
                TotalItems = totalItems;
                model = artists;
            }
            catch (Exception ee)
            {
                EventLogService.LogData(MessageType.Error, "AllArtistSearchService-GetArtists", ee.Message);
                TotalItems = 1;
                return null;
            }

            return model; 
        }

        /// <summary>
        /// Gets the navigation.
        /// </summary>
        /// <returns></returns>
        public List<string> GetNavigation()
        {
            return this.ServiceManager.GetCharactors();
        }
        #endregion



    }
}
