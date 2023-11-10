using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacsOnline.Model.Business_Objects
{


    public class Document
    {
        #region properties

        /// <summary>
        /// Gets the title of the document
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets the document path where the file is.
        /// </summary>
        public string DocumentPath { get; set; }
        /// <summary>
        /// Gets the form that the document belong.
        /// </summary>
        public string FormBelong { get; set; }
        /// <summary>
        /// Gets a value indicating whether this visible in the page or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if it is visible; otherwise, <c>false</c>.
        /// </value>
        public bool Visible { get; set; }
        #endregion
    }
}
