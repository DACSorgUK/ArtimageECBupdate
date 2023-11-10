using System;
using System.Runtime.CompilerServices;

namespace DacsOnline.Model.Models
{
	public class ArtistCLModel
	{
		public string ArtistId
		{
			get;
			set;
		}

		public string FirstName
		{
			get;
			set;
		}

		public string ImageHireMessage
		{
			get;
			set;
		}

		public bool LastMaxRelevance
		{
			get;
			set;
		}

		public string LastName
		{
			get;
			set;
		}

		public string MoreInfoMessage_1
		{
			get;
			set;
		}

		public string MoreInfoMessage_2
		{
			get;
			set;
		}

		public string Nationality
		{
			get;
			set;
		}

		public string Relevance
		{
			get;
			set;
		}

		public string RepresentationMessage
		{
			get;
			set;
		}

		public string ServiceDurationMessage
		{
			get;
			set;
		}

		public bool ShowApplyFor
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

		public ArtistCLModel()
		{
			this.FirstName = string.Empty;
			this.LastName = string.Empty;
			this.Nationality = string.Empty;
			this.YearOfBirth = string.Empty;
			this.YearOfDeath = string.Empty;
			this.RepresentationMessage = string.Empty;
			this.ServiceDurationMessage = string.Empty;
			this.ImageHireMessage = string.Empty;
			this.MoreInfoMessage_1 = string.Empty;
			this.MoreInfoMessage_2 = string.Empty;
			this.ShowApplyFor = false;
		}
	}
}