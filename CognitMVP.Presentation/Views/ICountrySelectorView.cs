using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
    public interface ICountrySelectorView : IView
    {
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
        void BindCountry(List<string> CountryList);
        #endregion

        #region //Public Properties
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        string Country { set; get; }
        #endregion
    }
}
