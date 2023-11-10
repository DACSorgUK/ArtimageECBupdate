using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
    public interface IJavascriptWebPartView: IView
    {
        #region properties
        /// <summary>
        /// Gets the themes.
        /// </summary>
        string themes { get; }
        #endregion

        #region EventHandler
        /// <summary>
        /// Occurs when [load form].
        /// </summary>
        event EventHandler LoadForm;
        #endregion

        #region Public Methods
        /// <summary>
        /// Loads the form.
        /// </summary>
        void Display();
        #endregion
    }
}
