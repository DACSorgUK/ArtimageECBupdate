using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Business_Objects;

namespace DacsOnline.Service.Service.Interfaces
{
    public interface IArtMarketSalesFormService
    {
        #region //Public Methods
        /// <summary>
        /// Submits the specified obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        bool Submit(SalesContactDetails obj, List<SalesInformationData> SalesInformation,out int recordId);
        /// <summary>
        /// Saves the cookie.
        /// </summary>
        /// <param name="obj">The obj.</param>
        void SaveCookie(SalesContactDetails obj);

        /// <summary>
        /// Loads the cookie object.
        /// </summary>
        /// <returns></returns>
        SalesContactDetails LoadCookieObject();

        /// <summary>
        /// Loads the titles.
        /// </summary>
        /// <returns></returns>
        string[] LoadTitles();
        #endregion
    }
}
