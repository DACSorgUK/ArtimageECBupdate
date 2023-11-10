using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacsOnline.Model.Models
{
    public class ArtistCLModel
    {
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
        /// Gets or sets the year of death.
        /// </summary>
        /// <value>
        /// The year of death.
        /// </value>
        public string YearOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the year of death.
        /// </summary>
        /// <value>
        /// The year of death.
        /// </value>
        public string YearOfDeath { get; set; }


        /// <summary>
        /// Gets or sets the eligibility message.
        /// </summary>
        /// <value>
        /// The eligibility message.
        /// </value>
        public string RepresentationMessage { get; set; }

        /// <summary>
        /// Gets or sets the mandate message.
        /// </summary>
        /// <value>
        /// The mandate message.
        /// </value>
        public string ServiceDurationMessage { get; set; }

        /// <summary>
        /// Gets or sets the payment message.
        /// </summary>
        /// <value>
        /// The payment message.
        /// </value>
        public string ImageHireMessage { get; set; }

        /// <summary>
        /// Gets or sets the more info message.
        /// </summary>
        /// <value>
        /// The more info message.
        /// </value>
        public string MoreInfoMessage_1 { get; set; }

        /// <summary>
        /// Gets or sets the more info message_2.
        /// </summary>
        /// <value>
        /// The more info message_2.
        /// </value>
        public string MoreInfoMessage_2 { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show apply for].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show apply for]; otherwise, <c>false</c>.
        /// </value>
        public  bool ShowApplyFor { get; set; }
       
        #endregion

        #region //Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistCLModel"/> class.
        /// </summary>
        public ArtistCLModel()
        {
            FirstName= string.Empty;
            LastName = string.Empty;
            Nationality = string.Empty;
            YearOfBirth = string.Empty;
            YearOfDeath = string.Empty;
            RepresentationMessage = string.Empty;
            ServiceDurationMessage = string.Empty;
            ImageHireMessage = string.Empty;
            MoreInfoMessage_1 = string.Empty;
            MoreInfoMessage_2 = string.Empty;
            ShowApplyFor =false;
        }
        #endregion
    }
}
