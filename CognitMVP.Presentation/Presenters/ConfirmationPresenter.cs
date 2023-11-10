using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Presentation.Views;
using DacsOnline.Service.Service.Interfaces;
using DacsOnline.Model.Enums;

namespace DacsOnline.Presentation.Presenters
{
    public class ConfirmationPresenter : BasePresenter<IConfirmationView>, IDisposable
    {
        #region Constructor
        public ConfirmationPresenter(IConfirmationView view)
            : base(view)
        {
            this.View.LoadForm += new EventHandler(LoadForm);
        }
        #endregion

        #region public methods

        public void Dispose()
        {
            this.View.LoadForm -= new EventHandler(LoadForm);

        }
        #endregion


        #region private Methods
        private void LoadForm(object sender, EventArgs e)
        {
            try
            {
                
                this.View.Display(this.View.Title, this.View.FormName + "-" + this.View.Iduser, this.View.Email, "dacs@dacs.org.uk");
            }
            catch (Exception ex)
            {
                this.EventLogService.LogData(MessageType.Error, "ConfirmationPresenter", ex.Message);
               
            }

        }

        #endregion
    }
}
