using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormsMvp;
using DacsOnline.Model.Business_Objects;

namespace DacsOnline.Presentation.Views
{

    public interface IDocumentListView : IView
    {
     

        #region Event Handler
        /// <summary>
        /// Occurs when [load data].
        /// </summary>
        event EventHandler LoadData;
        #endregion

        #region Methods

        /// <summary>
        /// Displays the specified documents that belong to a form.
        /// </summary>
        /// <param name="list">The list.</param>
        void Display(List<string> list);
        #endregion
    }
}
