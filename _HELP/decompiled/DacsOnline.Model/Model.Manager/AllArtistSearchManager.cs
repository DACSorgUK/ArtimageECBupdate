using DacsOnline.Model.Business_Objects;
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
	public class AllArtistSearchManager : BaseManager<IARRArtistSearchRepository>, IAllArtistDetailsManager
	{
		private IARRArtistSearchManager _arrManager;

		private ICLArtistSearchManager _clManager;

		private List<Nationality> _listNationlity;

		public AllArtistSearchManager(IARRArtistSearchRepository ARRSearchRepository, IARRArtistSearchManager arrManager, ICLArtistSearchManager clManager) : base(ARRSearchRepository)
		{
			this._arrManager = arrManager;
			this._clManager = clManager;
			this._listNationlity = base.Repository.GetNationalities();
		}

		public List<string> GetCharactors()
		{
			List<string> list = (
				from x in Enumerable.Range(65, 26)
				select string.Concat((char)x)).ToList<string>();
			return list;
		}

		private List<Artist> GetCurrentPageData(List<Artist> artists, int pageSize, int page)
		{
			int take = page * pageSize;
			int skip = (page == 1 ? 0 : take - pageSize);
			List<Artist> list = artists.Take<Artist>(take).Skip<Artist>(skip).ToList<Artist>();
			return list;
		}

		public List<ArtistCombined> SearchArtist(string StartingWord, int page, int pageSize, out int TotalItems)
		{
			List<ArtistCombined> artistsModel = new List<ArtistCombined>();
			string year = DateTime.Now.Year.ToString();
			List<Artist> artists = base.Repository.GetArtistsData();
			artists = (
				from p in artists
				where (p.AuthenticLastName.ContainsFirstCharartor(StartingWord) ? true : p.LastName.ContainsFirstCharartor(StartingWord))
				orderby p.LastName, p.FirstName
				select p).ToList<Artist>();
			TotalItems = artists.Count<Artist>();
			artists = this.GetCurrentPageData(artists, pageSize, page);
			foreach (Artist obj in artists)
			{
				ArtistARRModel objArr = new ArtistARRModel();
				this._arrManager.SetMessages(obj, objArr, year);
				ArtistCLModel objCL = new ArtistCLModel();
				this._clManager.SetMessages(obj, objCL, year);
				ArtistCombined objCombined = new ArtistCombined()
				{
					ArtistId = obj.ArtistId,
					ARREligibilityMessage = objArr.EligibilityMessage,
					ARRMandateMessage = objArr.MandateMessage,
					ARRPaymentMessage = objArr.PaymentMessage,
					CLImageHireMessage = objCL.ImageHireMessage,
					CLMoreInfoMessage_1 = objCL.MoreInfoMessage_1,
					CLMoreInfoMessage_2 = objCL.MoreInfoMessage_2,
					CLRepresentationMessage = objCL.RepresentationMessage,
					CLServiceDurationMessage = objCL.ServiceDurationMessage,
					CLShowApplyFor = objCL.ShowApplyFor,
					FirstName = obj.FirstName,
					LastName = obj.LastName,
					Nationality = obj.GetNationality(this._listNationlity),
					YearOfBirth = obj.YearOfBirth,
					YearOfDeath = obj.YearOfDeath,
					DisplayArr = objArr.DisplayArr
				};
				artistsModel.Add(objCombined);
			}
			return artistsModel;
		}
	}
}