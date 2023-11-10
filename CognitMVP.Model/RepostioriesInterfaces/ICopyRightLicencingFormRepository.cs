using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Business_Objects;

namespace DacsOnline.Model.RepostioriesInterfaces
{
    public interface ICopyRightLicencingFormRepository
    {
        /// <summary>
        /// Saves the contact details.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        int SaveContactDetails(CopyrightLicencingFormdata obj, out string _referenceNumber, out List<string> fileDownloadPath);


        /// <summary>
        /// Saves the copy right licencing product information.
        /// </summary>
        /// <param name="contactId">The contact id.</param>
        /// <param name="CopyRightLicencingProductInformation">The copy right licencing product information.</param>
        /// <returns></returns>
        bool SaveCopyRightLicencingProductInformation(int contactId, List<CopyRightLicencingProduct> CopyRightLicencingProductInformation);
   
        /// <summary>
        /// Gets the title names.
        /// </summary>
        /// <returns></returns>
        string[] GetTitleNames();
    }
}
