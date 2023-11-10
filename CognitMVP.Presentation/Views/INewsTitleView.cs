using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
    public interface INewsTitleView : IView
    {
        #region properties
        /// <summary>
        /// Gets the title latest news.
        /// </summary>
        string Category { get; }
        #endregion

        #region EventHandler
        /// <summary>
        /// Occurs when [load].
        /// </summary>
        event EventHandler Load;
        #endregion

        #region public Methods
        /// <summary>
        /// Showtitles this instance.
        /// </summary>
        void Showtitle();
        #endregion
    }
}
