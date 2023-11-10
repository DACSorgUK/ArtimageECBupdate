using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Enums;

namespace DacsOnline.Model.Business_Objects
{
    public class Artist
    {
        #region Properties


        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        /// <value>
        /// The item id.
        /// </value>
        public string ArtistId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string  FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string  LastName { get; set; }
        /// <summary>
        /// Gets or sets the authentic first names.
        /// </summary>
        /// <value>
        /// The authentic first names.
        /// </value>
        public string  AuthenticFirstNames { get; set; }
        /// <summary>
        /// Gets or sets the last name of the authentic.
        /// </summary>
        /// <value>
        /// The last name of the authentic.
        /// </value>
        public string  AuthenticLastName { get; set; }
        ///// <summary>
        ///// Gets or sets the authentic pseudonym_ CL.
        ///// </summary>
        ///// <value>
        ///// The authentic pseudonym_ CL.
        ///// </value>
        //public string  AuthenticPseudonym_CL { get; set; }
        ///// <summary>
        ///// Gets or sets the authentic pseudonym_ ARR.
        ///// </summary>
        ///// <value>
        ///// The authentic pseudonym_ ARR.
        ///// </value>
        //public string  AuthenticPseudonym_ARR { get; set; }
        /// <summary>
        /// Gets or sets the pseudonym_1.
        /// </summary>
        /// <value>
        /// The pseudonym_1.
        /// </value>
        public string  Pseudonym_1 { get; set; }
        /// <summary>
        /// Gets or sets the pseudonym_2.
        /// </summary>
        /// <value>
        /// The pseudonym_2.
        /// </value>
        public string  Pseudonym_2 { get; set; }
        /// <summary>
        /// Gets or sets the pseudonym_3.
        /// </summary>
        /// <value>
        /// The pseudonym_3.
        /// </value>
        public string  Pseudonym_3 { get; set; }
        /// <summary>
        /// Gets or sets the pseudonym_4.
        /// </summary>
        /// <value>
        /// The pseudonym_4.
        /// </value>
        public string  Pseudonym_4 { get; set; }
        /// <summary>
        /// Gets or sets the pseudonym_5.
        /// </summary>
        /// <value>
        /// The pseudonym_5.
        /// </value>
        public string  Pseudonym_5 { get; set; }
        /// <summary>
        /// Gets or sets the pseudonym_6.
        /// </summary>
        /// <value>
        /// The pseudonym_6.
        /// </value>
        public string  Pseudonym_6 { get; set; }
        /// <summary>
        /// Gets or sets the nationality_1_ ARR.
        /// </summary>
        /// <value>
        /// The nationality_1_ ARR.
        /// </value>
        public string  Nationality1 { get; set; }
        /// <summary>
        /// Gets or sets the nationality_2_ ARR.
        /// </summary>
        /// <value>
        /// The nationality_2_ ARR.
        /// </value>
        public string  Nationality2 { get; set; }


        /// <summary>
        /// Gets or sets the nationality_3_ ARR.
        /// </summary>
        /// <value>
        /// The nationality_3_ ARR.
        /// </value>
        public string Nationality3 { get; set; }
        /// <summary>
        /// Gets or sets the nationality_1_ CL.
        /// </summary>
        /// <value>
        /// The nationality_1_ CL.
        /// </value>
        public string  Nationality4 { get; set; }
        
        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        public DateTime ? DateOfBirth { get; set; }
        /// <summary>
        /// Gets or sets the date of death.
        /// </summary>
        /// <value>
        /// The date of death.
        /// </value>
        public DateTime? DateOfDeath { get; set; }
        /// <summary>
        /// Gets or sets the year of birth.
        /// </summary>
        /// <value>
        /// The year of birth.
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
        /// Gets or sets a value indicating whether [in copyright].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [in copyright]; otherwise, <c>false</c>.
        /// </value>
        public bool InCopyright { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [image hire].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [image hire]; otherwise, <c>false</c>.
        /// </value>
        public bool ImageHire { get; set; }
        /// <summary>
        /// Gets or sets the ARR membership.
        /// </summary>
        /// <value>
        /// The ARR membership.
        /// </value>
        public ARRMembershipType ARRMembership { get; set; }
        /// <summary>
        /// Gets or sets the ARR sister society.
        /// </summary>
        /// <value>
        /// The ARR sister society.
        /// </value>
        public string ARRSisterSociety { get; set; }
        /// <summary>
        /// Gets or sets the ARR paid royalties.
        /// </summary>
        /// <value>
        /// The ARR paid royalties.
        /// </value>
        public ARRPaidRoyalties ARRPaidRoyalties { get; set; }
     
        /// <summary>
        /// Gets or sets the ARR confirmed nationality.
        /// </summary>
        /// <value>
        /// The ARR confirmed nationality.
        /// </value>
        public ARRConfirmedNationalityType ARRConfirmedNationality { get; set; }
        /// <summary>
        /// Gets or sets the type of the CL memebership.
        /// </summary>
        /// <value>
        /// The type of the CL memebership.
        /// </value>
        public CLMemebershipType CLMemebershipType { get; set; }

        /// <summary>
        /// Gets or sets the CL sister society.
        /// </summary>
        /// <value>
        /// The CL sister society.
        /// </value>
        public string CLSisterSociety { get; set; }
        /// <summary>
        /// Gets or sets the CL rights multimedia only.
        /// </summary>
        /// <value>
        /// The CL rights multimedia only.
        /// </value>
        public bool CLRightsMultimediaOnly { get; set; }
        /// <summary>
        /// Gets or sets the CL rights excluding multimedia.
        /// </summary>
        /// <value>
        /// The CL rights excluding multimedia.
        /// </value>
        public bool CLRightsExcludingMultimedia { get; set; }
        /// <summary>
        /// Gets or sets the CL rights excluding merchandise.
        /// </summary>
        /// <value>
        /// The CL rights excluding merchandise.
        /// </value>
        public bool CLRightsExcludingMerchandise { get; set; }
        /// <summary>
        /// Gets or sets the CL rights auction house only.
        /// </summary>
        /// <value>
        /// The CL rights auction house only.
        /// </value>
        public bool CLRightsAuctionHouseOnly { get; set; }
        /// <summary>
        /// Gets or sets the CL full consultation.
        /// </summary>
        /// <value>
        /// The CL full consultation.
        /// </value>
        public bool CLFullConsultation { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        public string ArtistWebsite { get; set; }
        public string CardName { get; set; }

        /// <summary>
        /// Gets or sets the relevence.
        /// </summary>
        /// <value>
        /// The relevence.
        /// </value>
        public string Relevence { get; set; }

        #endregion

        #region //Public Methods
        /// <summary>
        /// Gets the nationality.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public  string GetNationality(List<Nationality> list)
        {
            string _nationality=string.Empty;
            if (!string.IsNullOrEmpty(Nationality1) && Nationality1 != "-")
            {
                _nationality = list.Where(p => p.Country.Trim().Equals(Nationality1.Trim()))
                          .Select(p => p.Person).FirstOrDefault() +", ";
            }
            if (!string.IsNullOrEmpty(Nationality2) && Nationality2 != "-")
            {
                _nationality = _nationality + list.Where(p => p.Country.Trim().Equals(Nationality2.Trim()))
                        .Select(p => p.Person).FirstOrDefault() + ", ";
            }
            if (!string.IsNullOrEmpty(Nationality3) && Nationality3 != "-")
            {
                _nationality = _nationality + list.Where(p => p.Country.Trim().Equals(Nationality3.Trim()))
                        .Select(p => p.Person).FirstOrDefault() + ", ";
            }
            if (!string.IsNullOrEmpty(Nationality4) && Nationality4 != "-")
            {
                _nationality = _nationality + list.Where(p => p.Country.Trim().Equals(Nationality4.Trim()))
                        .Select(p => p.Person).FirstOrDefault() + ", ";
            }

            if (_nationality.Length > 2)
            {
                _nationality = _nationality.Substring(0, _nationality.Length - 2);
            }

            return _nationality;

            //if (_nationality == string.Empty)
            //{
            //    return string.Empty;
            //}
            //else
            //{
            //  return  list.Where(p => p.Country.Trim().Equals(_nationality.Trim()))
            //              .Select(p => p.Person).FirstOrDefault();
            //}
        }
        #endregion

    }

    public class DistinctArtistId : IEqualityComparer<Artist>
    {

        #region //Public Methods
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type <paramref name="T"/> to compare.</param>
        /// <param name="y">The second object of type <paramref name="T"/> to compare.</param>
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        public bool Equals(Artist x, Artist y)
        {
            return x.ArtistId.Equals(y.ArtistId);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.</exception>
        public int GetHashCode(Artist obj)
        {
            return obj.ArtistId.GetHashCode();
        }

        #endregion
    }
}
