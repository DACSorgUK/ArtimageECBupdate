using DacsOnline.Model.Enums;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Presentation.Views;
using DacsOnline.Service.Service.Interfaces;
using System;
using System.Threading;
using WebFormsMvp;

namespace DacsOnline.Presentation.Presenters
{
	public class DocumentListPresenter : BasePresenter<IDocumentListView>, IDisposable
	{
		private IDocumentListService _documentListService;

		public DocumentListPresenter(IDocumentListView view, IDocumentListService service) : base(view)
		{
			base.View.LoadData += new EventHandler(this.Load);
			this._documentListService = service;
		}

		public void Dispose()
		{
			base.View.LoadData -= new EventHandler(this.Load);
		}

		private void Load(object sender, EventArgs e)
		{
			try
			{
				base.View.Display(this._documentListService.GetDocumentsInformation());
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "DocumentListPresenter", exception.Message);
			}
		}

		public event EventHandler LoadData;
	}
}