using DacsOnline.Model.Enums;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.Models;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Service.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace DacsOnline.Service.Service
{
	public class AllArtistSearchService : BaseService<IAllArtistDetailsManager>, IAllArtistSearchService
	{
		public AllArtistSearchService(IAllArtistDetailsManager artistDetailsManager) : base(artistDetailsManager)
		{
		}

		public List<ArtistCombined> GetArtist(string StartingWord, int page, int pageSize, out int TotalItems)
		{
			int totalItems;
			List<ArtistCombined> artistCombineds;
			List<ArtistCombined> model = null;
			try
			{
				List<ArtistCombined> artists = base.ServiceManager.SearchArtist(StartingWord, page, pageSize, out totalItems);
				TotalItems = totalItems;
				model = artists;
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "AllArtistSearchService-GetArtists", exception.Message);
				TotalItems = 1;
				artistCombineds = null;
				return artistCombineds;
			}
			artistCombineds = model;
			return artistCombineds;
		}

		public List<string> GetNavigation()
		{
			return base.ServiceManager.GetCharactors();
		}
	}
}