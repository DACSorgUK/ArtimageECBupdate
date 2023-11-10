using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
    public interface IJobApplicationPackView : IView
    {
        #region properties
        string EmailDacs { get; }
        string EmailUser { get; }
        string jobTitle { get; }
        string downloadjob { get; }
        #endregion
       
        #region public Methods
        void Display();
        void ShowSubmit();
        void HideSubmit();
        void ShowConfirmation();
        void HideConfirmation();
        #endregion

        #region EventHandler
        event EventHandler OnclickSubmit;
        event EventHandler OnclickLink;
        event EventHandler OnLoad;
        #endregion
    }
}
