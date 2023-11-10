using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
    public interface INewsLetterSignUpView : IView
    {
        #region properties
        string FirstName { get; }
        string LastName { get; }
        string EmailAddress { get; }
        #endregion

        #region EventHandler
        event EventHandler ClickButton;
        #endregion

        #region public Methods
        void SingUp(bool result);
        #endregion
    }
}
