using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.RepostioriesInterfaces;

namespace DacsOnline.Model.Manager
{
    public class DocumentListManager : BaseManager<IDocumentRepository>, IDocumentationListManager
    {

        #region properties
        IDocumentRepository repository;
        #endregion

        #region contructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentListManager"/> class.
        /// </summary>
        /// <param name="DocumentRepository">The document repository.</param>
        public DocumentListManager(IDocumentRepository DocumentRepository)
            : base(DocumentRepository)
        {
            repository = DocumentRepository;

        }
        #endregion


        #region Public Methods
        /// <summary>
        /// Gets the documents which belong to the form
        /// </summary>
        /// <param name="Form">Name of the form.</param>
        /// <returns></returns>
        public List<string> GetDocumentsInformation()
        {
            //Read the documents in the media library
            return repository.GetDocumentsInformation();
        }
        #endregion
    }
}
