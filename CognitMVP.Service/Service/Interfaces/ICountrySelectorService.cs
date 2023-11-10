using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacsOnline.Service.Service.Interfaces
{
    public interface ICountrySelectorService
    {
        /// <summary>
        /// Gets the countries.
        /// </summary>
        /// <returns></returns>
        List<string> GetCountries();
    }
}
