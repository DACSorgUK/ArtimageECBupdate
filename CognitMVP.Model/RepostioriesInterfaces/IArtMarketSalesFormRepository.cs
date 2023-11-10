using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Business_Objects;

namespace DacsOnline.Model.RepostioriesInterfaces
{
    public interface IArtMarketSalesFormRepository
    {
        /// <summary>
        /// Saves the contact details.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        int SaveContactDetails(SalesContactDetails obj);
        /// <summary>
        /// Saves the sales information.
        /// </summary>
        /// <param name="contactId">The contact id.</param>
        /// <param name="SalesInformation">The sales information.</param>
        /// <returns></returns>
        bool SaveSalesInformation(int contactId, List<SalesInformationData> SalesInformation);
        /// <summary>
        /// Deletes the contact details.
        /// </summary>
        /// <param name="contactId">The contact id.</param>
        /// <returns></returns>
        bool DeleteContactDetails(int contactId);
        /// <summary>
        /// Gets the title names.
        /// </summary>
        /// <returns></returns>
        string[] GetTitleNames();
    }
}
