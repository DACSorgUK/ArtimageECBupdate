using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Business_Objects;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
    public interface IArtMarketSalesFormView : IView
    {
        #region //Public properties
        /// <summary>
        /// Gets the confirmation URL.
        /// </summary>
        string ConfirmationUrl { get; }
        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the company.
        /// </summary>
        string Company
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the address line1.
        /// </summary>
         string AddressLine1
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the address line2.
        /// </summary>
        string AddressLine2
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the address line3.
        /// </summary>
         string AddressLine3
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the city.
        /// </summary>
         string City
        {
            get;
            set;
        }

         /// <summary>
         /// Gets the region.
         /// </summary>
         string CountyRegion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the post code.
        /// </summary>
         string PostCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the country.
        /// </summary>
         string Country
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the phone.
        /// </summary>
         string Phone
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the fax.
        /// </summary>
         string Fax
        {
            get;
            set;
        }


        /// <summary>
        /// Gets the email address.
        /// </summary>
         string EmailAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the website.
        /// </summary>
         string Website
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating whether [remember details].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [remember details]; otherwise, <c>false</c>.
        /// </value>
         bool RememberDetails
        {
            get;
        }

        /// <summary>
        /// Gets the sales information.
        /// </summary>
         List<SalesInformationData> SalesInformation
        {
            get;
        }


         /// <summary>
         /// Gets the mobile.
         /// </summary>
         string Mobile
         {
             get;
             set;
         }


        #endregion

        #region //Event handlers
         /// <summary>
         /// Occurs when [submit data].
         /// </summary>
        event EventHandler SubmitData;

        /// <summary>
        /// Occurs when [load data].
        /// </summary>
        event EventHandler LoadData;
        #endregion

        #region //Public Methods
        /// <summary>
        /// Binds the titles.
        /// </summary>
        /// <param name="titles">The titles.</param>
        void BindTitles(string[] titles);

        /// <summary>
        /// Redirects the form.
        /// </summary>
        /// <param name="url">The URL.</param>
        void RedirectForm(string url);

        /// <summary>
        /// Shows the error.
        /// </summary>
        void ShowError();
        #endregion
    }
}
