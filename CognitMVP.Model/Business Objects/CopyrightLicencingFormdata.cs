using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacsOnline.Model.Business_Objects
{
    public class CopyrightLicencingFormdata
    {

        #region //Public properties

        public string ReferenceNumber
        {
            get;
            set;
        }
        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the company.
        /// </summary>
        public string Company
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the address line1.
        /// </summary>
        public string AddressLine1
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the address line2.
        /// </summary>
        public string AddressLine2
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the address line3.
        /// </summary>
        public string AddressLine3
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the city.
        /// </summary>
        public string City
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the region.
        /// </summary>
        public string CountyRegion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the post code.
        /// </summary>
        public string PostCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the country.
        /// </summary>
        public string Country
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the phone.
        /// </summary>
        public string Phone
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the mobile.
        /// </summary>
        ////public string Mobile
        ////{
        ////    get;
        ////    set;
        ////}

        /// <summary>
        /// Gets the fax.
        /// </summary>
        ////public string Fax
        ////{
        ////    get;
        ////    set;
        ////}


        /// <summary>
        /// Gets the email address.
        /// </summary>
        public string EmailAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the website.
        /// </summary>
        public string Website
        {
            get;
            set;
        }

        public string VatNumber
        {
            set;
            get;
        }

        public string BillingContactName
        {
            set;
            get;
        }

        public string BillingEmailAddress
        {
            set;
            get;
        }

        /// <summary>
        /// Gets or sets the use contact details.
        /// </summary>
        /// <value>
        /// The use contact details.
        /// </value>
        public string UseContactDetails
        {
            set;
            get;
        }

        public string InvoiceCompany
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the address line1.
        /// </summary>
        public string InvoiceAddressLine1
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the address line2.
        /// </summary>
        public string InvoiceAddressLine2
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the address line3.
        /// </summary>
        public string InvoiceAddressLine3
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the city.
        /// </summary>
        public string InvoiceCity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the region.
        /// </summary>
        public string InvoiceCountyRegion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the post code.
        /// </summary>
        public string InvoicePostCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the country.
        /// </summary>
        public string InvoiceCountry
        {
            get;
            set;
        }

        public List<string> Files
        {
            get;
            set;
        }

        #endregion
    }
}
