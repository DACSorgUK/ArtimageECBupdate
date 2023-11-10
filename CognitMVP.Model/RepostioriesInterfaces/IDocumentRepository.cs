using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Business_Objects;

namespace DacsOnline.Model.RepostioriesInterfaces
{

    public interface IDocumentRepository
    {

        /// <summary>
        /// Gets the documents that we want show in the form
        /// </summary>
        /// <param name="Form">The form.</param>
        /// <returns></returns>
        List<string> GetDocumentsInformation();
    }
}
