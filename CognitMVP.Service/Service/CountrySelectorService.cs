using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Service.Service.Interfaces;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.RepostioriesInterfaces;


namespace DacsOnline.Service.Service
{
    public class CountrySelectorService : ICountrySelectorService
    {
        private IARRArtistSearchRepository _SearchRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountrySelectorService"/> class.
        /// </summary>
        /// <param name="SearchRepository">The search repository.</param>
        public CountrySelectorService(IARRArtistSearchRepository SearchRepository)
        {
            _SearchRepository = SearchRepository;
        }

        #region //Public Methods

        /// <summary>
        /// Gets the countries.
        /// </summary>
        /// <returns></returns>
        public List<string> GetCountries()
        {
            return _SearchRepository.GetNationalities().Select(p => p.Country).ToList<string>();
        }

        #endregion
    }
}
