using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Service.Service.Interfaces;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Models;
using DacsOnline.Model.Enums;

namespace DacsOnline.Service.Service
{
    public class ARRArtistSearchService : BaseService<IARRArtistSearchManager>, IARRArtistSearchService
    {
        #region //Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ARRArtistSearchService"/> class.
        /// </summary>
        /// <param name="employeeServiceManager">The employee service manager.</param>
        public ARRArtistSearchService(IARRArtistSearchManager employeeServiceManager)
            : base(employeeServiceManager)
        {
        }

        #endregion


        #region //Public Methods

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
        public List<ArtistARRModel> GetArtists(string Year, string ArtistFirstName, string ArtistLastName, int Pgae, int PageSize, out int TotalItems, string dataSource)
        {
            List<ArtistARRModel> model = null;
            int totalItems;
            try
            {
                List<ArtistARRModel> artists = ServiceManager.SearchArtist(Year, ArtistFirstName, ArtistLastName, Pgae, PageSize, out totalItems, dataSource);
                TotalItems = totalItems;
                model = artists;  
            }
            catch (Exception ee)
            {
                EventLogService.LogData(MessageType.Error, "ARRArtistSearchService-GetArtists", ee.Message);
                TotalItems = 1;
                return null;
            }

            return model;
        }

        /// <summary>
        /// Gets the sales years.
        /// </summary>
        /// <returns></returns>
        public List<string> GetSalesYears()
        {
            return ServiceManager.GetSalesYears();

        }
        #endregion




    }
}
