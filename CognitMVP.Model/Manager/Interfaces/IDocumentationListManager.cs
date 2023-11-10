using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Business_Objects;

namespace DacsOnline.Model.Manager.Interfaces
{
    public interface IDocumentationListManager
    {
        #region Public Methods
        /// <summary>
        /// Gets the documents which belong to the form
        /// </summary>
        /// <returns></returns>
        List<string> GetDocumentsInformation();
        #endregion
    }
}
