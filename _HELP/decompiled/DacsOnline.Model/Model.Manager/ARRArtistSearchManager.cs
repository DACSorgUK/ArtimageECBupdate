using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Enums;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.Models;
using DacsOnline.Model.RepostioriesInterfaces;
using DacsOnline.Model.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DacsOnline.Model.Manager
{
	public class ARRArtistSearchManager : BaseManager<IARRArtistSearchRepository>, IARRArtistSearchManager
	{
		private List<Nationality> _listNationlity;

		public ARRArtistSearchManager(IARRArtistSearchRepository ARRSearchRepository) : base(ARRSearchRepository)
		{
			this._listNationlity = base.Repository.GetNationalities();
		}

		private string GetBirthYear(Artist obj)
		{
			string str;
			if (!obj.DateOfBirth.HasValue)
			{
				str = (obj.YearOfBirth == null ? string.Empty : obj.YearOfBirth);
			}
			else
			{
				str = obj.DateOfBirth.Value.Year.ToString();
			}
			return str;
		}

		private List<Artist> GetCurrentPageData(List<Artist> artists, int pageSize, int page)
		{
			int take = page * pageSize;
			int skip = (page == 1 ? 0 : take - pageSize);
			List<Artist> result = artists.Take<Artist>(take).Skip<Artist>(skip).ToList<Artist>();
			return result;
		}

		private string GetDeathYear(Artist obj)
		{
			string str;
			if (!obj.DateOfDeath.HasValue)
			{
				str = (obj.YearOfDeath == null ? string.Empty : obj.YearOfDeath);
			}
			else
			{
				str = obj.DateOfDeath.Value.Year.ToString();
			}
			return str;
		}

		public List<string> GetSalesYears()
		{
			return base.Repository.GetSalesYears();
		}

		private bool IsArtistSeventyYears(Artist obj, string SaleYear)
		{
			bool flag;
			try
			{
				if (!string.IsNullOrEmpty(obj.DateOfDeath.ToString()))
				{
					flag = (Convert.ToInt32(SaleYear) - obj.DateOfDeath.Value.Year < 71 ? true : false);
				}
				else if (string.IsNullOrEmpty(obj.YearOfDeath))
				{
					flag = true;
				}
				else
				{
					flag = (Convert.ToInt32(SaleYear) - Convert.ToInt32(obj.YearOfDeath) < 71 ? true : false);
				}
			}
			catch
			{
				flag = true;
			}
			return flag;
		}

		private ArtistNationality IsUserEEA(Artist obj)
		{
			ArtistNationality artistNationality;
			List<string> eeaList = (
				from p in this._listNationlity
				where p.EEA
				select p.Country.Trim()).ToList<string>();
			if ((!string.IsNullOrEmpty(obj.Nationality1.Trim()) || !string.IsNullOrEmpty(obj.Nationality2.Trim()) || !string.IsNullOrEmpty(obj.Nationality3.Trim()) ? true : !string.IsNullOrEmpty(obj.Nationality4.Trim())))
			{
				artistNationality = ((eeaList.Contains(obj.Nationality1.Trim()) || eeaList.Contains(obj.Nationality2.Trim()) || eeaList.Contains(obj.Nationality3.Trim()) ? false : !eeaList.Contains(obj.Nationality4.Trim())) ? ArtistNationality.NonEEA : ArtistNationality.EEA);
			}
			else
			{
				artistNationality = ArtistNationality.NotDefined;
			}
			return artistNationality;
		}

		public List<ArtistARRModel> SearchArtist(string SaleYear, string ArtistFirstName, string ArtistLastName, int page, int pageSize, out int TotalItems, out int ExactMatches)
		{
			List<ArtistARRModel> artistARRModels;
			List<Artist> refinedArtists = new List<Artist>();
			List<Artist> refinedPseudonymArtists = new List<Artist>();
			List<ArtistARRModel> artistsModel = new List<ArtistARRModel>();
			List<Artist> artistsByFirstNameAndLastName = base.Repository.GetArtistsData();
			List<Artist> artistsByPseudonym = base.Repository.GetArtistsData();
			if ((ArtistFirstName != string.Empty ? false : !(ArtistLastName != string.Empty)))
			{
				TotalItems = 0;
				ExactMatches = 0;
				artistARRModels = artistsModel;
			}
			else
			{
				if (!(ArtistFirstName == string.Empty ? true : !(ArtistLastName != string.Empty)))
				{
					artistsByFirstNameAndLastName = (
						from p in artistsByFirstNameAndLastName
						where (p.AuthenticFirstNames.ToUpper().Contains(ArtistFirstName.ToUpper()) ? true : p.FirstName.ToUpper().Contains(ArtistFirstName.ToUpper()))
						select p).ToList<Artist>();
					artistsByFirstNameAndLastName = (
						from p in artistsByFirstNameAndLastName
						where (p.AuthenticLastName.ToUpper().Contains(ArtistLastName.ToUpper()) ? true : p.LastName.ToUpper().Contains(ArtistLastName.ToUpper()))
						select p).ToList<Artist>();
				}
				else if (ArtistFirstName != string.Empty)
				{
					artistsByFirstNameAndLastName = (
						from p in artistsByFirstNameAndLastName
						where (p.AuthenticFirstNames.ToUpper().Contains(ArtistFirstName.ToUpper()) ? true : p.FirstName.ToUpper().Contains(ArtistFirstName.ToUpper()))
						select p).ToList<Artist>();
				}
				else if (ArtistLastName != string.Empty)
				{
					artistsByFirstNameAndLastName = (
						from p in artistsByFirstNameAndLastName
						where (p.AuthenticLastName.ToUpper().Contains(ArtistLastName.ToUpper()) ? true : p.LastName.ToUpper().Contains(ArtistLastName.ToUpper()))
						select p).ToList<Artist>();
				}
				artistsByFirstNameAndLastName = artistsByFirstNameAndLastName.Select<Artist, Artist>((Artist x) => {
					x.Relevence = "1";
					return x;
				}).ToList<Artist>();
				ExactMatches = artistsByFirstNameAndLastName.Count;
				refinedArtists.AddRange(artistsByFirstNameAndLastName);
				if (ArtistFirstName != string.Empty)
				{
					refinedPseudonymArtists.AddRange((
						from p in artistsByPseudonym
						where (p.Pseudonym_1.ToUpper().Contains(ArtistFirstName.ToUpper()) || p.Pseudonym_2.ToUpper().Contains(ArtistFirstName.ToUpper()) || p.Pseudonym_3.ToUpper().Contains(ArtistFirstName.ToUpper()) || p.Pseudonym_4.ToUpper().Contains(ArtistFirstName.ToUpper()) || p.Pseudonym_5.ToUpper().Contains(ArtistFirstName.ToUpper()) ? true : p.Pseudonym_6.ToUpper().Contains(ArtistFirstName.ToUpper()))
						select p).ToList<Artist>());
				}
				if (ArtistLastName != string.Empty)
				{
					refinedPseudonymArtists.AddRange((
						from p in artistsByPseudonym
						where (p.Pseudonym_1.ToUpper().Contains(ArtistLastName.ToUpper()) || p.Pseudonym_2.ToUpper().Contains(ArtistLastName.ToUpper()) || p.Pseudonym_3.ToUpper().Contains(ArtistLastName.ToUpper()) || p.Pseudonym_4.ToUpper().Contains(ArtistLastName.ToUpper()) || p.Pseudonym_5.ToUpper().Contains(ArtistLastName.ToUpper()) ? true : p.Pseudonym_6.ToUpper().Contains(ArtistLastName.ToUpper()))
						select p).ToList<Artist>());
				}
				refinedPseudonymArtists = refinedPseudonymArtists.Distinct<Artist>(new DistinctArtistId()).ToList<Artist>();
				foreach (Artist artistsDatum in artistsByFirstNameAndLastName)
				{
					Artist remove = (
						from p in refinedPseudonymArtists
						where p.ArtistId == artistsDatum.ArtistId
						select p).FirstOrDefault<Artist>();
					if (remove != null)
					{
						refinedPseudonymArtists.Remove(remove);
					}
				}
				refinedPseudonymArtists = refinedPseudonymArtists.Select<Artist, Artist>((Artist x) => {
					x.Relevence = "2";
					return x;
				}).ToList<Artist>();
				refinedArtists.AddRange(refinedPseudonymArtists);
				refinedArtists = (
					from p in refinedArtists
					orderby p.Relevence, p.LastName, p.FirstName
					select p).ToList<Artist>();
				TotalItems = refinedArtists.Count<Artist>();
				Artist releventArtist = (
					from p in refinedArtists
					where p.Relevence == "1"
					select p).LastOrDefault<Artist>();
				refinedArtists = this.GetCurrentPageData(refinedArtists, pageSize, page);
				foreach (Artist obj in refinedArtists)
				{
					ArtistARRModel objModel = new ArtistARRModel()
					{
						ArtistId = obj.ArtistId,
						FirstName = obj.FirstName,
						LastName = obj.LastName,
						Nationality = obj.GetNationality(this._listNationlity),
						YearOfBirth = this.GetBirthYear(obj),
						YearOfDeath = this.GetDeathYear(obj),
						Confirmed = (obj.ARRConfirmedNationality == ARRConfirmedNationalityType.Confirmed ? ARRConfirmedNationalityType.Confirmed.ToString() : ARRConfirmedNationalityType.Unconfirmed.ToString()),
						Relevance = obj.Relevence,
						LastMaxRelevance = (releventArtist == null || !(releventArtist.ArtistId == obj.ArtistId) ? false : true)
					};
					this.SetMessages(obj, objModel, SaleYear);
					artistsModel.Add(objModel);
				}
				artistARRModels = artistsModel;
			}
			return artistARRModels;
		}

		public void SetMessages(Artist obj, ArtistARRModel modObj, string SaleYear)
		{
			if (!this.IsArtistSeventyYears(obj, SaleYear))
			{
				modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_6");
				modObj.DisplayArr = false;
			}
			else if (obj.ARRMembership == ARRMembershipType.DACS)
			{
				this.SetMessageWhenUserMemberShip_DACS(obj, modObj);
			}
			else if (obj.ARRMembership == ARRMembershipType.SisterSociety)
			{
				this.SetMessageWhenUserMemberShip_SisterSociety(obj, modObj);
			}
			else if ((obj.ARRMembership == ARRMembershipType.ACS || obj.ARRMembership == ARRMembershipType.ARA ? false : obj.ARRMembership != ARRMembershipType.ACS))
			{
				this.SetMessageWhenUserMemberShip_Blank(obj, modObj);
			}
			else
			{
				this.SetMessageWhenUserMemberShip_ACS_ARA_ARA(obj, modObj);
			}
		}

		private void SetMessageWhenUserMemberShip_ACS_ARA_ARA(Artist obj, ArtistARRModel modObj)
		{
			if (this.IsUserEEA(obj) == ArtistNationality.EEA)
			{
				if (obj.ARRConfirmedNationality != ARRConfirmedNationalityType.Confirmed)
				{
					modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_4");
					modObj.MandateMessage = string.Empty;
					modObj.PaymentMessage = string.Concat(DACSOnlineUtiles.GetMessage("PaymentMessage_3"), " ", obj.ARRMembership.ToString());
					modObj.DisplayArr = true;
				}
				else
				{
					modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_4");
					modObj.MandateMessage = string.Empty;
					modObj.PaymentMessage = string.Concat(DACSOnlineUtiles.GetMessage("PaymentMessage_3"), " ", obj.ARRMembership.ToString());
					modObj.DisplayArr = true;
				}
			}
			else if (obj.ARRConfirmedNationality != ARRConfirmedNationalityType.Confirmed)
			{
				modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_4");
				modObj.MandateMessage = string.Empty;
				modObj.PaymentMessage = string.Concat(DACSOnlineUtiles.GetMessage("PaymentMessage_3"), " ", obj.ARRMembership.ToString());
				modObj.DisplayArr = true;
			}
			else
			{
				modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_4");
				modObj.MandateMessage = string.Empty;
				modObj.PaymentMessage = string.Concat(DACSOnlineUtiles.GetMessage("PaymentMessage_3"), " ", obj.ARRMembership.ToString());
				modObj.DisplayArr = true;
			}
		}

		private void SetMessageWhenUserMemberShip_Blank(Artist obj, ArtistARRModel modObj)
		{
			ArtistNationality isEEA = this.IsUserEEA(obj);
			if (isEEA == ArtistNationality.EEA)
			{
				if (obj.ARRConfirmedNationality == ARRConfirmedNationalityType.Confirmed)
				{
					if (obj.ARRPaidRoyalties != ARRPaidRoyalties.Yes)
					{
						modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_1");
						modObj.MandateMessage = string.Empty;
						modObj.PaymentMessage = DACSOnlineUtiles.GetMessage("PaymentMessage_4");
						modObj.DisplayArr = true;
					}
					else
					{
						modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_1");
						modObj.MandateMessage = string.Empty;
						modObj.PaymentMessage = DACSOnlineUtiles.GetMessage("PaymentMessage_4");
						modObj.DisplayArr = true;
					}
				}
				else if (obj.ARRPaidRoyalties != ARRPaidRoyalties.Yes)
				{
					modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_4");
					modObj.MandateMessage = DACSOnlineUtiles.GetMessage("MandateMessage_2");
					modObj.PaymentMessage = string.Empty;
					modObj.WarningMesssage = DACSOnlineUtiles.GetMessage("WarnningMessage_1");
					modObj.DisplayArr = true;
				}
				else
				{
					modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_4");
					modObj.MandateMessage = DACSOnlineUtiles.GetMessage("MandateMessage_2");
					modObj.PaymentMessage = string.Empty;
					modObj.WarningMesssage = DACSOnlineUtiles.GetMessage("WarnningMessage_1");
					modObj.DisplayArr = true;
				}
			}
			else if (isEEA != ArtistNationality.NonEEA)
			{
				modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_4");
				modObj.MandateMessage = DACSOnlineUtiles.GetMessage("MandateMessage_3");
				modObj.PaymentMessage = string.Empty;
				modObj.WarningMesssage = DACSOnlineUtiles.GetMessage("WarnningMessage_1");
				modObj.DisplayArr = true;
			}
			else if (obj.ARRConfirmedNationality == ARRConfirmedNationalityType.Confirmed)
			{
				if (obj.ARRPaidRoyalties != ARRPaidRoyalties.Yes)
				{
					modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_2");
					modObj.MandateMessage = string.Empty;
					modObj.PaymentMessage = string.Empty;
					modObj.DisplayArr = false;
				}
				else
				{
					modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_2");
					modObj.MandateMessage = string.Empty;
					modObj.PaymentMessage = string.Empty;
					modObj.DisplayArr = false;
				}
			}
			else if (obj.ARRPaidRoyalties != ARRPaidRoyalties.Yes)
			{
				modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_5");
				modObj.MandateMessage = DACSOnlineUtiles.GetMessage("MandateMessage_2");
				modObj.WarningMesssage = DACSOnlineUtiles.GetMessage("WarnningMessage_1");
				modObj.PaymentMessage = string.Empty;
				modObj.DisplayArr = true;
			}
			else
			{
				modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_5");
				modObj.MandateMessage = DACSOnlineUtiles.GetMessage("MandateMessage_2");
				modObj.WarningMesssage = DACSOnlineUtiles.GetMessage("WarnningMessage_1");
				modObj.PaymentMessage = string.Empty;
				modObj.DisplayArr = true;
			}
		}

		private void SetMessageWhenUserMemberShip_DACS(Artist obj, ArtistARRModel modObj)
		{
			if (this.IsUserEEA(obj) == ArtistNationality.EEA)
			{
				if (obj.ARRConfirmedNationality != ARRConfirmedNationalityType.Confirmed)
				{
					modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_4");
					modObj.MandateMessage = string.Empty;
					modObj.PaymentMessage = DACSOnlineUtiles.GetMessage("PaymentMessage_1");
					modObj.DisplayArr = true;
				}
				else
				{
					modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_1");
					modObj.MandateMessage = DACSOnlineUtiles.GetMessage("MandateMessage_1");
					modObj.PaymentMessage = DACSOnlineUtiles.GetMessage("PaymentMessage_1");
					modObj.DisplayArr = true;
				}
			}
			else if (obj.ARRConfirmedNationality != ARRConfirmedNationalityType.Confirmed)
			{
				modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_2");
				modObj.MandateMessage = string.Empty;
				modObj.PaymentMessage = string.Empty;
				modObj.DisplayArr = false;
			}
			else
			{
				modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_2");
				modObj.MandateMessage = string.Empty;
				modObj.PaymentMessage = string.Empty;
				modObj.DisplayArr = false;
			}
		}

		private void SetMessageWhenUserMemberShip_SisterSociety(Artist obj, ArtistARRModel modObj)
		{
			if (this.IsUserEEA(obj) == ArtistNationality.EEA)
			{
				if (obj.ARRConfirmedNationality != ARRConfirmedNationalityType.Confirmed)
				{
					modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_4");
					modObj.MandateMessage = DACSOnlineUtiles.GetMessage("MandateMessage_22");
					modObj.PaymentMessage = DACSOnlineUtiles.GetMessage("PaymentMessage_5");
					modObj.DisplayArr = true;
				}
				else
				{
					modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_1");
					modObj.MandateMessage = DACSOnlineUtiles.GetMessage("MandateMessage_1");
					modObj.PaymentMessage = DACSOnlineUtiles.GetMessage("PaymentMessage_2");
					modObj.DisplayArr = true;
				}
			}
			else if (obj.ARRConfirmedNationality != ARRConfirmedNationalityType.Confirmed)
			{
				modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_5");
				modObj.MandateMessage = DACSOnlineUtiles.GetMessage("MandateMessage_22");
				modObj.PaymentMessage = DACSOnlineUtiles.GetMessage("PaymentMessage_5");
				modObj.DisplayArr = true;
			}
			else
			{
				modObj.EligibilityMessage = DACSOnlineUtiles.GetMessage("EligibilityMessage_2");
				modObj.MandateMessage = string.Empty;
				modObj.PaymentMessage = DACSOnlineUtiles.GetMessage("PaymentMessage_2");
				modObj.DisplayArr = false;
			}
		}
	}
}