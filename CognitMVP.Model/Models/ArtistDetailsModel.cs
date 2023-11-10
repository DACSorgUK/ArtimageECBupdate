using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacsOnline.Model.Models
{
    public class ArtistDetailsModel
    {
        #region //Model Prperties

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
        public string DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the year of death.
        /// </summary>
        /// <value>
        /// The year of death.
        /// </value>
        public string DateOfDeath { get; set; }


        /// <summary>
        /// Gets or sets the eligibility message.
        /// </summary>
        /// <value>
        /// The eligibility message.
        /// </value>
        public string Pseudonyms { get; set; }

        /// <summary>
        /// Gets or sets the mandate message.
        /// </summary>
        /// <value>
        /// The mandate message.
        /// </value>
        public string Website { get; set; }


       



        
       
        #endregion

        #region //Constrsuctor
        public ArtistDetailsModel()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Nationality = string.Empty;
            DateOfBirth = string.Empty;
            DateOfDeath = string.Empty;
            Pseudonyms = string.Empty;
            Website = string.Empty;
        }
        #endregion
    }
}
