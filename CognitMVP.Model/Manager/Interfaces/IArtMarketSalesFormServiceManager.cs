using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Business_Objects;

namespace DacsOnline.Model.Manager.Interfaces
{
    public interface IArtMarketSalesFormServiceManager
    {
        #region //Public Methods
        /// <summary>
        /// Processes the data.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="SalesInformation">The sales information.</param>
        /// <returns></returns>
        bool ProcessData(SalesContactDetails obj, List<SalesInformationData> SalesInformation,out int recordId);
        /// <summary>
        /// Gets the titles.
        /// </summary>
        /// <returns></returns>
        string[] GetTitles();
        #endregion
    }
}
