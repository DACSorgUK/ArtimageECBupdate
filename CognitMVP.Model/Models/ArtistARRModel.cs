using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacsOnline.Model.Models
{
    public class ArtistARRModel
    {
        #region //Constructor
        public ArtistARRModel()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Nationality = string.Empty;
            YearOfBirth = string.Empty;
            YearOfDeath = string.Empty;
            EligibilityMessage = string.Empty;
            MandateMessage = string.Empty;
            PaymentMessage = string.Empty;
            Confirmed = string.Empty; ;
        }
        #endregion

        #region //Model Prperties

        /// <summary>
        /// Gets or sets the artist id.
        /// </summary>
        /// <value>
        /// The artist id.
        /// </value>
        public string ArtistId { set; get; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the nationality.
        /// </summary>
        /// <value>
        /// The nationality.
        /// </value>
        public string Nationality { get; set; }

        /// <summary>
        /// Gets or sets the confirmed.
        /// </summary>
        /// <value>
        /// The confirmed.
        /// </value>
        public string Confirmed { get; set; }

        /// <summary>
        /// Gets or sets the year of death.
        /// </summary>
        /// <value>
        /// The year of death.
        /// </value>
        public string YearOfDeath { get; set; }

        /// <summary>
        /// Gets or sets the year of birth.
        /// </summary>
        /// <value>
        /// The year of birth.
        /// </value>
        public string YearOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the eligibility message.
        /// </summary>
        /// <value>
        /// The eligibility message.
        /// </value>
        public string EligibilityMessage { get; set; }

        /// <summary>
        /// Gets or sets the mandate message.
        /// </summary>
        /// <value>
        /// The mandate message.
        /// </value>
        public string MandateMessage { get; set; }

        /// <summary>
        /// Gets or sets the payment message.
        /// </summary>
        /// <value>
        /// The payment message.
        /// </value>
        public string PaymentMessage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [display arr].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [display arr]; otherwise, <c>false</c>.
        /// </value>
        public bool DisplayArr { get; set; }
       
        #endregion
    }
}
