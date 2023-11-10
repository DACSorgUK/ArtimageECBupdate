using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DacsOnline.Model.Business_Objects
{
    public class CopyRightLicencingProduct
    {
        #region //Public properties

        /// <summary>
        /// Gets the title of procuct.
        /// </summary>
        public string TitleOfProcuct
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the type of product.
        /// </summary>
        public string TypeOfProduct
        {
            get;
            set;
        }

        public string ISBN
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the date licence needs.
        /// </summary>
        public DateTime ? DateLicenceNeeds
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the further information.
        /// </summary>
        public string FurtherInformation
        {
            get;
            set;
        }

        

        /// <summary>
        /// Gets or sets the product quantity.
        /// </summary>
        /// <value>
        /// The product quantity.
        /// </value>
        public string PrintRun
        {
            get;
            set;
        }

        public string PrintRunDigital
        {
            get;
            set;
        }

        public string LicenceDuration
        {
            get;
            set;
        }

        public string Website
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the launct date.
        /// </summary>
        /// <value>
        /// The launct date.
        /// </value>
        public DateTime? launctDate
        {
            set;
            get;
        }


        /// <summary>
        /// Gets or sets the usage rights required.
        /// </summary>
        /// <value>
        /// The usage rights required.
        /// </value>
        public string UsageRightsRequired
        {
            set;
            get;
        }

        /// <summary>
        /// Gets or sets the where item distributes.
        /// </summary>
        /// <value>
        /// The where item distributes.
        /// </value>
        public string WhereItemDistributed
        {
            set;
            get;
        }

        /// <summary>
        /// Gets or sets the product reproductions.
        /// </summary>
        /// <value>
        /// The product reproductions.
        /// </value>
        public  List<CopyRightLicencingProductReproductions> ProductReproductions
        {
            get;
            set;
        }

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

        public string ContextOfUseCropped
        {
            get;
            set;
        }

        public string ContextOfUseCover
        {
            get;
            set;
        }

        public string Publishlanguage
        {
            get;
            set;
        }

        #endregion

    }
}
