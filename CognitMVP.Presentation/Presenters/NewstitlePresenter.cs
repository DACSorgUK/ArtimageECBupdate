using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Presentation.Views;
using DacsOnline.Model.Enums;

namespace DacsOnline.Presentation.Presenters
{
   
    public class NewstitlePresenter : BasePresenter<INewsTitleView>, IDisposable
    {
        public NewstitlePresenter(INewsTitleView view)
            : base(view)
        {
            this.View.Load += new EventHandler(OnLoad);

        }

        public void Dispose()
        {
            this.View.Load -= new EventHandler(OnLoad);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            try
            {
                this.View.Showtitle();


            }
            catch (Exception ex)
            {
                this.EventLogService.LogData(MessageType.Error, "NewstitlePresenter", ex.Message);
            }

        }
    }
}
