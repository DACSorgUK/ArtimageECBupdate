using DacsOnline.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DacsOnline.Model.Business_Objects
{
	public class Artist
	{
		public ARRConfirmedNationalityType ARRConfirmedNationality
		{
			get;
			set;
		}

		public ARRMembershipType ARRMembership
		{
			get;
			set;
		}

		public DacsOnline.Model.Enums.ARRPaidRoyalties ARRPaidRoyalties
		{
			get;
			set;
		}

		public string ARRSisterSociety
		{
			get;
			set;
		}

		public string ArtistId
		{
			get;
			set;
		}

		public string ArtistWebsite
		{
			get;
			set;
		}

		public string AuthenticFirstNames
		{
			get;
			set;
		}

		public string AuthenticLastName
		{
			get;
			set;
		}

		public bool CLFullConsultation
		{
			get;
			set;
		}

		public DacsOnline.Model.Enums.CLMemebershipType CLMemebershipType
		{
			get;
			set;
		}

		public bool CLRightsAuctionHouseOnly
		{
			get;
			set;
		}

		public bool CLRightsExcludingMerchandise
		{
			get;
			set;
		}

		public bool CLRightsExcludingMultimedia
		{
			get;
			set;
		}

		public bool CLRightsMultimediaOnly
		{
			get;
			set;
		}

		public string CLSisterSociety
		{
			get;
			set;
		}

		public DateTime? DateOfBirth
		{
			get;
			set;
		}

		public DateTime? DateOfDeath
		{
			get;
			set;
		}

		public string FirstName
		{
			get;
			set;
		}

		public bool ImageHire
		{
			get;
			set;
		}

		public bool InCopyright
		{
			get;
			set;
		}

		public string LastName
		{
			get;
			set;
		}

		public string Nationality1
		{
			get;
			set;
		}

		public string Nationality2
		{
			get;
			set;
		}

		public string Nationality3
		{
			get;
			set;
		}

		public string Nationality4
		{
			get;
			set;
		}

		public string Pseudonym_1
		{
			get;
			set;
		}

		public string Pseudonym_2
		{
			get;
			set;
		}

		public string Pseudonym_3
		{
			get;
			set;
		}

		public string Pseudonym_4
		{
			get;
			set;
		}

		public string Pseudonym_5
		{
			get;
			set;
		}

		public string Pseudonym_6
		{
			get;
			set;
		}

		public string Relevence
		{
			get;
			set;
		}

		public string YearOfBirth
		{
			get;
			set;
		}

		public string YearOfDeath
		{
			get;
			set;
		}

		public Artist()
		{
		}

		public string GetNationality(List<Nationality> list)
		{
			string _nationality = string.Empty;
			if (!string.IsNullOrEmpty(this.Nationality1))
			{
				_nationality = string.Concat((
					from p in list
					where p.Country.Trim().Equals(this.Nationality1.Trim())
					select p.Person).FirstOrDefault<string>(), ", ");
			}
			if (!string.IsNullOrEmpty(this.Nationality2))
			{
				_nationality = string.Concat(_nationality, (
					from p in list
					where p.Country.Trim().Equals(this.Nationality2.Trim())
					select p.Person).FirstOrDefault<string>(), ", ");
			}
			if (!string.IsNullOrEmpty(this.Nationality3))
			{
				_nationality = string.Concat(_nationality, (
					from p in list
					where p.Country.Trim().Equals(this.Nationality3.Trim())
					select p.Person).FirstOrDefault<string>(), ", ");
			}
			if (!string.IsNullOrEmpty(this.Nationality4))
			{
				_nationality = string.Concat(_nationality, (
					from p in list
					where p.Country.Trim().Equals(this.Nationality4.Trim())
					select p.Person).FirstOrDefault<string>(), ", ");
			}
			if (_nationality.Length > 2)
			{
				_nationality = _nationality.Substring(0, _nationality.Length - 2);
			}
			return _nationality;
		}
	}
}