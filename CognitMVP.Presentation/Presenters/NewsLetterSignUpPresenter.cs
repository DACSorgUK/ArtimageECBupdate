using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Adadpters;
using DacsOnline.Model.Enums;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Presentation.Views;
using DacsOnline.Model.Enums;
using DacsOnline.Service.Service.Interfaces;

namespace DacsOnline.Presentation.Presenters
{
    public class NewsLetterSignUpPresenter : BasePresenter<INewsLetterSignUpView>, IDisposable
    {
        #region Constructor
        public NewsLetterSignUpPresenter(INewsLetterSignUpView view)
            : base(view)
        {
            this.View.ClickButton += new EventHandler(Clikbutton);
        }

        #endregion

        #region Public Methods
        public void Dispose()
        {
            this.View.ClickButton -= new EventHandler(Clikbutton);
        }
        #endregion

        #region Private Methods
        private void Clikbutton(object sender, EventArgs e)
        {
            try
            {

                this.View.SingUp(SingUp(this.View.FirstName, this.View.LastName, this.View.EmailAddress));
            }
            catch (Exception ex)
            {
                // this.EventLogService.LogData(MessageType.Error, "ConfirmationPresenter", ex.Message);

            }

        }
        private bool SingUp(string firstname, string lastname, string email)
        {
            ISubscribeEmail subscribeAdapter = new MailChimpAdapter();
            return subscribeAdapter.SubscribeUser(email, "HTML", firstname, lastname);
        }

        #endregion

    }
}
