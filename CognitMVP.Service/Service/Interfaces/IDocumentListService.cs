using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Business_Objects;

namespace DacsOnline.Service.Service.Interfaces
{
    public interface IDocumentListService
    {
        /// <summary>
        /// Gets the documents that belong to the form
        /// </summary>
        /// <returns></returns>
        List<string> GetDocumentsInformation();
    }
}
