using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
    public interface IApplicationFormRequestView : IView
    {
        #region properties
        string AdministratorEmail { get; }
        string Telephone { get; }
        string FormName { get; }
        string Address { get; }
        #endregion

        #region EventHandler
        event EventHandler Onclick;
        event EventHandler OnLoad;
        #endregion

        #region publid Methods
        void Display();
        #endregion
    }
}
