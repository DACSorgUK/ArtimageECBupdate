using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Service.Service.Interfaces;
using DacsOnline.Model.Business_Objects;

namespace DacsOnline.Service.Service
{
    public class DocumentListService : BaseService<IDocumentationListManager>, IDocumentListService
    {
        private IDocumentationListManager _documentListManager;
        public DocumentListService(IDocumentationListManager DocumentListManager)
            : base(DocumentListManager)
        {
            _documentListManager = DocumentListManager;

        }

        /// <summary>
        /// Gets the documents that belong to the form
        /// </summary>
        /// <returns></returns>
        public List<string> GetDocumentsInformation()
        {
            return _documentListManager.GetDocumentsInformation();
        }
    }
}
