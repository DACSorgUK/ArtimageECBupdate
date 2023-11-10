using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Service.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace DacsOnline.Service.Service
{
	public class DocumentListService : BaseService<IDocumentationListManager>, IDocumentListService
	{
		private IDocumentationListManager _documentListManager;

		public DocumentListService(IDocumentationListManager DocumentListManager) : base(DocumentListManager)
		{
			this._documentListManager = DocumentListManager;
		}

		public List<string> GetDocumentsInformation()
		{
			return this._documentListManager.GetDocumentsInformation();
		}
	}
}