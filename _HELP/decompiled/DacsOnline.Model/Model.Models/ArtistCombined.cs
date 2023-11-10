using System;
using System.Runtime.CompilerServices;

namespace DacsOnline.Model.Models
{
	public class ArtistCombined
	{
		public string ARREligibilityMessage
		{
			get;
			set;
		}

		public string ARRMandateMessage
		{
			get;
			set;
		}

		public string ARRPaymentMessage
		{
			get;
			set;
		}

		public string ArtistId
		{
			get;
			set;
		}

		public string CLArtistDetailsMessage
		{
			get;
			set;
		}

		public string CLImageHireMessage
		{
			get;
			set;
		}

		public string CLMoreInfoMessage_1
		{
			get;
			set;
		}

		public string CLMoreInfoMessage_2
		{
			get;
			set;
		}

		public string CLRepresentationMessage
		{
			get;
			set;
		}

		public string CLServiceDurationMessage
		{
			get;
			set;
		}

		public bool CLShowApplyFor
		{
			get;
			set;
		}

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

		public bool DisplayArr
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

		public string WarningMesssage
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

		public ArtistCombined()
		{
			this.FirstName = string.Empty;
			this.LastName = string.Empty;
			this.Nationality = string.Empty;
			this.YearOfBirth = string.Empty;
			this.YearOfDeath = string.Empty;
			this.ARREligibilityMessage = string.Empty;
			this.ARRMandateMessage = string.Empty;
			this.ARRPaymentMessage = string.Empty;
			this.CLRepresentationMessage = string.Empty;
			this.CLServiceDurationMessage = string.Empty;
			this.CLImageHireMessage = string.Empty;
			this.CLMoreInfoMessage_1 = string.Empty;
			this.CLMoreInfoMessage_2 = string.Empty;
			this.CLShowApplyFor = false;
			this.WarningMesssage = string.Empty;
		}
	}
}