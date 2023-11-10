using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Enums;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.Models;
using DacsOnline.Model.RepostioriesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace DacsOnline.Model.Manager
{
	public class CLArtistSearchManager : BaseManager<IARRArtistSearchRepository>, ICLArtistSearchManager
	{
		private List<Nationality> _listNationlity;

		public CLArtistSearchManager(IARRArtistSearchRepository ARRSearchRepository) : base(ARRSearchRepository)
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
			List<Artist> list = artists.Take<Artist>(take).Skip<Artist>(skip).ToList<Artist>();
			return list;
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

		private string GetMessage(string key)
		{
			return HttpContext.GetGlobalResourceObject("DACSOnlineResources", key) as string;
		}

		private bool IsArtistSeventyYears(Artist obj, string SaleYear)
		{
			bool flag;
			try
			{
				if (!string.IsNullOrEmpty(obj.DateOfDeath.ToString()))
				{
					flag = (Convert.ToInt32(SaleYear) - obj.DateOfDeath.Value.Year <= 70 ? true : false);
				}
				else if (string.IsNullOrEmpty(obj.YearOfDeath))
				{
					flag = true;
				}
				else
				{
					flag = (Convert.ToInt32(SaleYear) - Convert.ToInt32(obj.YearOfDeath) <= 70 ? true : false);
				}
			}
			catch
			{
				flag = true;
			}
			return flag;
		}

		public List<ArtistCLModel> SearchArtist(string SaleYear, string ArtistFirstName, string ArtistLastName, int page, int pageSize, out int TotalItems, out int ExactMatches)
		{
			List<ArtistCLModel> artistCLModels;
			List<Artist> refinedArtists = new List<Artist>();
			List<Artist> refinedPseudonymArtists = new List<Artist>();
			List<ArtistCLModel> artistsModel = new List<ArtistCLModel>();
			List<Artist> artistsByFirstNameAndLastName = base.Repository.GetArtistsData();
			List<Artist> artistsByPseudonym = base.Repository.GetArtistsData();
			if ((ArtistFirstName != string.Empty ? false : !(ArtistLastName != string.Empty)))
			{
				TotalItems = 1;
				ExactMatches = 0;
				artistCLModels = artistsModel;
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
					ArtistCLModel objModel = new ArtistCLModel()
					{
						ArtistId = obj.ArtistId,
						FirstName = obj.FirstName,
						LastName = obj.LastName,
						Nationality = obj.GetNationality(this._listNationlity),
						YearOfBirth = this.GetBirthYear(obj),
						YearOfDeath = this.GetDeathYear(obj),
						Relevance = obj.Relevence,
						LastMaxRelevance = (releventArtist == null || !(releventArtist.ArtistId == obj.ArtistId) ? false : true)
					};
					this.SetMessages(obj, objModel, SaleYear);
					artistsModel.Add(objModel);
				}
				artistCLModels = artistsModel;
			}
			return artistCLModels;
		}

		public void SetMessages(Artist obj, ArtistCLModel modObj, string Year)
		{
			if (!this.IsArtistSeventyYears(obj, Year))
			{
				this.SetMessageWhenYearGreaterThanSeventy(obj, modObj);
			}
			else if (!obj.InCopyright)
			{
				if (obj.CLMemebershipType == CLMemebershipType.Default)
				{
					modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_2");
					modObj.MoreInfoMessage_1 = this.GetMessage("MoreInfoMessage_5");
					modObj.ShowApplyFor = false;
				}
				if (obj.CLMemebershipType == CLMemebershipType.DACS)
				{
					modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_2");
					modObj.MoreInfoMessage_1 = this.GetMessage("MoreInfoMessage_5");
					modObj.ShowApplyFor = false;
				}
				if (obj.CLMemebershipType == CLMemebershipType.SisterSociety)
				{
					modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_2");
					modObj.MoreInfoMessage_1 = this.GetMessage("MoreInfoMessage_5");
					modObj.ShowApplyFor = false;
				}
			}
			else
			{
				if (obj.CLMemebershipType == CLMemebershipType.Default)
				{
					modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_2");
					modObj.MoreInfoMessage_1 = this.GetMessage("MoreInfoMessage_4");
					modObj.ShowApplyFor = false;
				}
				if (obj.CLMemebershipType == CLMemebershipType.DACS)
				{
					this.SetMessageWhenUserMemberShip_DACS(obj, modObj);
				}
				if (obj.CLMemebershipType == CLMemebershipType.SisterSociety)
				{
					this.SetMessageWhenUserMemberShip_SisterSociety(obj, modObj);
				}
			}
		}

		private void SetMessageWhenUserMemberShip_DACS(Artist obj, ArtistCLModel modObj)
		{
			if (!obj.CLFullConsultation)
			{
				if (obj.ImageHire)
				{
					if ((obj.CLRightsAuctionHouseOnly || obj.CLRightsExcludingMerchandise || obj.CLRightsExcludingMultimedia ? false : !obj.CLRightsMultimediaOnly))
					{
						modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_1");
						modObj.ServiceDurationMessage = this.GetMessage("ServiceDurationMessage_1");
						modObj.ImageHireMessage = this.GetMessage("ImageHireMessage_1");
						modObj.ShowApplyFor = true;
						modObj.MoreInfoMessage_1 = string.Empty;
						modObj.MoreInfoMessage_2 = this.GetMessage("MoreInfoMessage_2");
					}
					else
					{
						modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_1");
						modObj.ServiceDurationMessage = this.GetMessage("ServiceDurationMessage_1");
						modObj.ImageHireMessage = this.GetMessage("ImageHireMessage_1");
						modObj.ShowApplyFor = true;
						modObj.MoreInfoMessage_1 = string.Empty;
						modObj.MoreInfoMessage_2 = this.GetMessage("MoreInfoMessage_3");
					}
				}
				else if ((obj.CLRightsAuctionHouseOnly || obj.CLRightsExcludingMerchandise || obj.CLRightsExcludingMultimedia ? false : !obj.CLRightsMultimediaOnly))
				{
					modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_1");
					modObj.ServiceDurationMessage = this.GetMessage("ServiceDurationMessage_1");
					modObj.ImageHireMessage = string.Empty;
					modObj.ShowApplyFor = true;
					modObj.MoreInfoMessage_1 = string.Empty;
					modObj.MoreInfoMessage_2 = this.GetMessage("MoreInfoMessage_2");
				}
				else
				{
					modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_1");
					modObj.ServiceDurationMessage = this.GetMessage("ServiceDurationMessage_1");
					modObj.ImageHireMessage = string.Empty;
					modObj.ShowApplyFor = true;
					modObj.MoreInfoMessage_1 = string.Empty;
					modObj.MoreInfoMessage_2 = this.GetMessage("MoreInfoMessage_3");
				}
			}
			else if (obj.ImageHire)
			{
				if ((obj.CLRightsAuctionHouseOnly || obj.CLRightsExcludingMerchandise || obj.CLRightsExcludingMultimedia ? false : !obj.CLRightsMultimediaOnly))
				{
					modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_1");
					modObj.ServiceDurationMessage = this.GetMessage("ServiceDurationMessage_1");
					modObj.ImageHireMessage = this.GetMessage("ImageHireMessage_1");
					modObj.ShowApplyFor = true;
					modObj.MoreInfoMessage_1 = this.GetMessage("MoreInfoMessage_1");
					modObj.MoreInfoMessage_2 = this.GetMessage("MoreInfoMessage_2");
				}
				else
				{
					modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_1");
					modObj.ServiceDurationMessage = this.GetMessage("ServiceDurationMessage_1");
					modObj.ImageHireMessage = this.GetMessage("ImageHireMessage_1");
					modObj.ShowApplyFor = true;
					modObj.MoreInfoMessage_1 = this.GetMessage("MoreInfoMessage_1");
					modObj.MoreInfoMessage_2 = this.GetMessage("MoreInfoMessage_2");
				}
			}
			else if ((obj.CLRightsAuctionHouseOnly || obj.CLRightsExcludingMerchandise || obj.CLRightsExcludingMultimedia ? false : !obj.CLRightsMultimediaOnly))
			{
				modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_1");
				modObj.ServiceDurationMessage = this.GetMessage("ServiceDurationMessage_2");
				modObj.ImageHireMessage = string.Empty;
				modObj.ShowApplyFor = true;
				modObj.MoreInfoMessage_1 = this.GetMessage("MoreInfoMessage_1");
				modObj.MoreInfoMessage_2 = this.GetMessage("MoreInfoMessage_2");
			}
			else
			{
				modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_1");
				modObj.ServiceDurationMessage = this.GetMessage("ServiceDurationMessage_2");
				modObj.ImageHireMessage = string.Empty;
				modObj.ShowApplyFor = true;
				modObj.MoreInfoMessage_1 = this.GetMessage("MoreInfoMessage_1");
				modObj.MoreInfoMessage_2 = this.GetMessage("MoreInfoMessage_2");
			}
		}

		private void SetMessageWhenUserMemberShip_SisterSociety(Artist obj, ArtistCLModel modObj)
		{
			if (!obj.CLFullConsultation)
			{
				if (obj.ImageHire)
				{
					if ((obj.CLRightsAuctionHouseOnly || obj.CLRightsExcludingMerchandise || obj.CLRightsExcludingMultimedia ? false : !obj.CLRightsMultimediaOnly))
					{
						modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_1");
						modObj.ServiceDurationMessage = this.GetMessage("ServiceDurationMessage_1");
						modObj.ImageHireMessage = this.GetMessage("ImageHireMessage_1");
						modObj.ShowApplyFor = true;
						modObj.MoreInfoMessage_1 = string.Empty;
						modObj.MoreInfoMessage_2 = this.GetMessage("MoreInfoMessage_2");
					}
					else
					{
						modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_1");
						modObj.ServiceDurationMessage = this.GetMessage("ServiceDurationMessage_1");
						modObj.ImageHireMessage = this.GetMessage("ImageHireMessage_1");
						modObj.ShowApplyFor = true;
						modObj.MoreInfoMessage_1 = string.Empty;
						modObj.MoreInfoMessage_2 = this.GetMessage("MoreInfoMessage_3");
					}
				}
				else if ((obj.CLRightsAuctionHouseOnly || obj.CLRightsExcludingMerchandise || obj.CLRightsExcludingMultimedia ? false : !obj.CLRightsMultimediaOnly))
				{
					modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_1");
					modObj.ServiceDurationMessage = this.GetMessage("ServiceDurationMessage_1");
					modObj.ImageHireMessage = string.Empty;
					modObj.ShowApplyFor = true;
					modObj.MoreInfoMessage_1 = string.Empty;
					modObj.MoreInfoMessage_2 = this.GetMessage("MoreInfoMessage_2");
				}
				else
				{
					modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_1");
					modObj.ServiceDurationMessage = this.GetMessage("ServiceDurationMessage_1");
					modObj.ImageHireMessage = string.Empty;
					modObj.ShowApplyFor = true;
					modObj.MoreInfoMessage_1 = string.Empty;
					modObj.MoreInfoMessage_2 = this.GetMessage("MoreInfoMessage_3");
				}
			}
			else if (obj.ImageHire)
			{
				if ((obj.CLRightsAuctionHouseOnly || obj.CLRightsExcludingMerchandise || obj.CLRightsExcludingMultimedia ? false : !obj.CLRightsMultimediaOnly))
				{
					modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_1");
					modObj.ServiceDurationMessage = this.GetMessage("ServiceDurationMessage_1");
					modObj.ImageHireMessage = this.GetMessage("ImageHireMessage_1");
					modObj.ShowApplyFor = true;
					modObj.MoreInfoMessage_1 = this.GetMessage("MoreInfoMessage_1");
					modObj.MoreInfoMessage_2 = this.GetMessage("MoreInfoMessage_2");
				}
				else
				{
					modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_1");
					modObj.ServiceDurationMessage = this.GetMessage("ServiceDurationMessage_1");
					modObj.ImageHireMessage = this.GetMessage("ImageHireMessage_1");
					modObj.ShowApplyFor = true;
					modObj.MoreInfoMessage_1 = this.GetMessage("MoreInfoMessage_1");
					modObj.MoreInfoMessage_2 = this.GetMessage("MoreInfoMessage_2");
				}
			}
			else if ((obj.CLRightsAuctionHouseOnly || obj.CLRightsExcludingMerchandise || obj.CLRightsExcludingMultimedia ? false : !obj.CLRightsMultimediaOnly))
			{
				modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_1");
				modObj.ServiceDurationMessage = this.GetMessage("ServiceDurationMessage_1");
				modObj.ImageHireMessage = string.Empty;
				modObj.ShowApplyFor = true;
				modObj.MoreInfoMessage_1 = this.GetMessage("MoreInfoMessage_1");
				modObj.MoreInfoMessage_2 = this.GetMessage("MoreInfoMessage_2");
			}
			else
			{
				modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_1");
				modObj.ServiceDurationMessage = this.GetMessage("ServiceDurationMessage_1");
				modObj.ImageHireMessage = string.Empty;
				modObj.ShowApplyFor = true;
				modObj.MoreInfoMessage_1 = this.GetMessage("MoreInfoMessage_1");
				modObj.MoreInfoMessage_2 = this.GetMessage("MoreInfoMessage_2");
			}
		}

		private void SetMessageWhenYearGreaterThanSeventy(Artist obj, ArtistCLModel modObj)
		{
			if (!obj.InCopyright)
			{
				modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_2");
				modObj.MoreInfoMessage_1 = this.GetMessage("MoreInfoMessage_6");
				modObj.ShowApplyFor = false;
			}
			else if (obj.CLMemebershipType == CLMemebershipType.DACS)
			{
				modObj.RepresentationMessage = this.GetMessage("RepresentationMessage_1");
				modObj.ServiceDurationMessage = this.GetMessage("ServiceDurationMessage_1");
				modObj.ShowApplyFor = true;
			}
		}
	}
}