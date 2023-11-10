using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Presentation.Views;
using WebFormsMvp.Web;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Service.Service.Interfaces;
using DacsOnline.Model.Enums;

namespace DacsOnline.Presentation.Presenters
{
    public class DocumentListPresenter : BasePresenter<IDocumentListView>, IDisposable
    {

        #region properties

        IDocumentListService _documentListService;
   
        #endregion

        #region Constructor
        public DocumentListPresenter(IDocumentListView view, IDocumentListService service)
            : base(view)
        {
            this.View.LoadData += new EventHandler(Load);
            _documentListService = service;

        }
        #endregion


        #region private Methods
        private void Load(object sender, EventArgs e)
        {
            try
            {
                this.View.Display(_documentListService.GetDocumentsInformation());
            }
            catch (Exception ex)
            {
                this.EventLogService.LogData(MessageType.Error, "DocumentListPresenter", ex.Message);
            }

        }
        #endregion


        #region Event Handler 
        /// <summary>
        /// Occurs when [load data].
        /// </summary>
        public event EventHandler LoadData;

        #endregion

        #region Public methods
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.View.LoadData -= new EventHandler(Load);
        }
        #endregion
    }
}
