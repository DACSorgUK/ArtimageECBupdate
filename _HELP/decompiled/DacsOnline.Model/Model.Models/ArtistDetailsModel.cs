using System;
using System.Runtime.CompilerServices;

namespace DacsOnline.Model.Models
{
	public class ArtistDetailsModel
	{
		public string DateOfBirth
		{
			get;
			set;
		}

		public string DateOfDeath
		{
			get;
			set;
		}

		public string FirstName
		{
			get;
			set;
		}

		public string LastName
		{
			get;
			set;
		}

		public string Nationality
		{
			get;
			set;
		}

		public string Pseudonyms
		{
			get;
			set;
		}

		public string Website
		{
			get;
			set;
		}

		public ArtistDetailsModel()
		{
			this.FirstName = string.Empty;
			this.LastName = string.Empty;
			this.Nationality = string.Empty;
			this.DateOfBirth = string.Empty;
			this.DateOfDeath = string.Empty;
			this.Pseudonyms = string.Empty;
			this.Website = string.Empty;
		}
	}
}