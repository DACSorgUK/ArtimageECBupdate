using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacsOnline.Model.Business_Objects
{
    public class Nationality
    {
        #region //Public Properties
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
       public  string Country { set; get; }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        /// <value>
        /// The person.
        /// </value>
       public string Person { set; get; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Nationality"/> is EEA.
        /// </summary>
        /// <value>
        ///   <c>true</c> if EEA; otherwise, <c>false</c>.
        /// </value>
       public bool EEA { set; get; }
        #endregion


    }
}
