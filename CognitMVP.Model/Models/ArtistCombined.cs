using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacsOnline.Model.Models
{
    public class ArtistCombined
    {
        #region //Public Properties
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
        /// Gets or sets the date of death.
        /// </summary>
        /// <value>
        /// The date of death.
        /// </value>
        public string DateOfDeath { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        public string DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the pseudonyms.
        /// </summary>
        /// <value>
        /// The pseudonyms.
        /// </value>
        public string Pseudonyms { get; set; }



        //ARR Data
        /// <summary>
        /// Gets or sets the eligibility message.
        /// </summary>
        /// <value>
        /// The eligibility message.
        /// </value>
        public string ARREligibilityMessage { get; set; }

        /// <summary>
        /// Gets or sets the mandate message.
        /// </summary>
        /// <value>
        /// The mandate message.
        /// </value>
        public string ARRMandateMessage { get; set; }

        /// <summary>
        /// Gets or sets the payment message.
        /// </summary>
        /// <value>
        /// The payment message.
        /// </value>
        public string ARRPaymentMessage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [display arr].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [display arr]; otherwise, <c>false</c>.
        /// </value>
        public bool DisplayArr { get; set; }


        //CL data

        /// <summary>
        /// Gets or sets the eligibility message.
        /// </summary>
        /// <value>
        /// The eligibility message.
        /// </value>
        public string CLRepresentationMessage { get; set; }

        /// <summary>
        /// Gets or sets the mandate message.
        /// </summary>
        /// <value>
        /// The mandate message.
        /// </value>
        public string CLServiceDurationMessage { get; set; }

        /// <summary>
        /// Gets or sets the payment message.
        /// </summary>
        /// <value>
        /// The payment message.
        /// </value>
        public string CLImageHireMessage { get; set; }

        /// <summary>
        /// Gets or sets the more info message.
        /// </summary>
        /// <value>
        /// The more info message.
        /// </value>
        public string CLMoreInfoMessage_1 { get; set; }

        /// <summary>
        /// Gets or sets the more info message_2.
        /// </summary>
        /// <value>
        /// The more info message_2.
        /// </value>
        public string CLMoreInfoMessage_2 { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show apply for].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show apply for]; otherwise, <c>false</c>.
        /// </value>
        public bool CLShowApplyFor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [CL only message].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [CL only message]; otherwise, <c>false</c>.
        /// </value>
        public string CLArtistDetailsMessage { get; set; }

        #endregion

        #region //Constrauctor
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistCombined"/> class.
        /// </summary>
        public ArtistCombined()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Nationality = string.Empty;
            YearOfBirth = string.Empty;
            YearOfDeath = string.Empty;
            ARREligibilityMessage = string.Empty;
            ARRMandateMessage = string.Empty;
            ARRPaymentMessage = string.Empty;
            CLRepresentationMessage = string.Empty;
            CLServiceDurationMessage = string.Empty;
            CLImageHireMessage = string.Empty;
            CLMoreInfoMessage_1 = string.Empty;
            CLMoreInfoMessage_2 = string.Empty;
            CLShowApplyFor = false;

        }
        #endregion
    }
}
