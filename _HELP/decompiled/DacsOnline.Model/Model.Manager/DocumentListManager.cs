using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.RepostioriesInterfaces;
using System;
using System.Collections.Generic;

namespace DacsOnline.Model.Manager
{
	public class DocumentListManager : BaseManager<IDocumentRepository>, IDocumentationListManager
	{
		private IDocumentRepository repository;

		public DocumentListManager(IDocumentRepository DocumentRepository) : base(DocumentRepository)
		{
			this.repository = DocumentRepository;
		}

		public List<string> GetDocumentsInformation()
		{
			return this.repository.GetDocumentsInformation();
		}
	}
}