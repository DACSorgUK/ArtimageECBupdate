using System;
using System.Runtime.CompilerServices;

namespace DacsOnline.Model.Models
{
	public class ArtistARRModel
	{
		public string ArtistId
		{
			get;
			set;
		}

		public string Confirmed
		{
			get;
			set;
		}

		public bool DisplayArr
		{
			get;
			set;
		}

		public string EligibilityMessage
		{
			get;
			set;
		}

		public string FirstName
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

		public string MandateMessage
		{
			get;
			set;
		}

		public string Nationality
		{
			get;
			set;
		}

		public string PaymentMessage
		{
			get;
			set;
		}

		public string Relevance
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

		public ArtistARRModel()
		{
			this.FirstName = string.Empty;
			this.LastName = string.Empty;
			this.Nationality = string.Empty;
			this.YearOfBirth = string.Empty;
			this.YearOfDeath = string.Empty;
			this.EligibilityMessage = string.Empty;
			this.MandateMessage = string.Empty;
			this.PaymentMessage = string.Empty;
			this.Confirmed = string.Empty;
			this.Relevance = string.Empty;
			this.LastMaxRelevance = false;
		}
	}
}