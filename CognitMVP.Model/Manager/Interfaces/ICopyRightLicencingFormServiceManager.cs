using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Business_Objects;

namespace DacsOnline.Model.Manager.Interfaces
{
    public interface ICopyRightLicencingFormServiceManager
    {
        #region //Public Methods

        bool ProcessData(CopyrightLicencingFormdata obj, List<CopyRightLicencingProduct> SalesInformation, out int recordId);
        /// <summary>
        /// Gets the titles.
        /// </summary>
        /// <returns></returns>
        string[] GetTitles();
        #endregion
    }
}
