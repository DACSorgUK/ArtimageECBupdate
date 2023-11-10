using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DacsOnline.Model.Business_Objects
{
    public class CopyRightLicencingProductReproductions
    {
        #region //Public Properties
        public string Id
        {
            get;
            set;
        }


        public string ArtistName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the title of work.
        /// </summary>
        /// <value>
        /// The title of work.
        /// </value>
        public string TitleOfWork
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the context of use.
        /// </summary>
        /// <value>
        /// The context of use.
        /// </value>
        //public List<string> ContextOfUse
        //{
        //    get;
        //    set;
        //}

        //public string ContextOfUseCropped
        //{
        //    get;
        //    set;
        //}

        //public string ContextOfUseCover
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// Gets or sets the posted file.
        /// </summary>
        /// <value>
        /// The posted file.
        /// </value>
        //public HttpPostedFile PostedFile
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// Gets or sets the depicted work.
        /// </summary>
        /// <value>
        /// The depicted work.
        /// </value>
        //public string DepictedWork
        //{
        //    set;
        //    get;
        //}

        #endregion
    }
}
