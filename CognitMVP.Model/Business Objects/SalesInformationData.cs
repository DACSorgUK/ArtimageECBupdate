using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacsOnline.Model.Business_Objects
{
    public class SalesInformationData
    {
        #region //Public Properties
        /// <summary>
        /// Gets the sales date.
        /// </summary>
        public DateTime? SalesDate
        {
            set;
            get;
        }

        /// <summary>
        /// Gets the refrence.
        /// </summary>
        public string Refrence
        {
            set;
            get;
        }

        /// <summary>
        /// Gets the name of the artist.
        /// </summary>
        /// <value>
        /// The name of the artist.
        /// </value>
        public string ArtistName
        {
            set;
            get;
        }

        /// <summary>
        /// Gets the date of birth.
        /// </summary>
        //public DateTime ? DateOfBirth
        //{
        //    set;
        //    get;
        //}

        ///// <summary>
        ///// Gets the date of death.
        ///// </summary>
        //public DateTime ? DateOfDeath
        //{
        //    set;
        //    get;
        //}

        public string DateOfBirth
        {
            set;
            get;
        }

        /// <summary>
        /// Gets the date of death.
        /// </summary>
        public string DateOfDeath
        {
            set;
            get;
        }

        /// <summary>
        /// Gets the nationality.
        /// </summary>
        public string Nationality
        {
            set;
            get;
        }

        /// <summary>
        /// Gets the title of work.
        /// </summary>
        public string TitleOfWork
        {
            set;
            get;
        }

        /// <summary>
        /// Gets the medium.
        /// </summary>
        public string Medium
        {
            set;
            get;
        }

        /// <summary>
        /// Gets the edition number.
        /// </summary>
        public string EditionNumber
        {
            set;
            get;
        }

        public string Dimensions
        {
            set;
            get;
        }

        /// <summary>
        /// Gets the sales price.
        /// </summary>
        public string SalesPrice
        {
            set;
            get;
        }

        /// <summary>
        /// Gets the claiming.
        /// </summary>
        public string BoughtAsStock
        {
            set;
            get;
        }
        #endregion
    }
}
