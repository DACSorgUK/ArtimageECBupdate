using DacsOnline.Model.Enums;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.Models;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Service.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace DacsOnline.Service.Service
{
	public class CLArtistSearchService : BaseService<ICLArtistSearchManager>, ICLArtistSearchService
	{
		public CLArtistSearchService(ICLArtistSearchManager employeeServiceManager) : base(employeeServiceManager)
		{
		}

		public List<ArtistCLModel> GetArtists(string Year, string ArtistFirstName, string ArtistLastName, int Pgae, int PageSize, out int TotalItems, out int ExactMatches)
		{
			int totalItems;
			int exactMatches;
			List<ArtistCLModel> artistCLModels;
			List<ArtistCLModel> model = null;
			try
			{
				List<ArtistCLModel> artists = base.ServiceManager.SearchArtist(Year, ArtistFirstName, ArtistLastName, Pgae, PageSize, out totalItems, out exactMatches);
				TotalItems = totalItems;
				ExactMatches = exactMatches;
				model = artists;
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "ARRArtistSearchService-GetArtists", exception.Message);
				TotalItems = 1;
				ExactMatches = 0;
				artistCLModels = null;
				return artistCLModels;
			}
			artistCLModels = model;
			return artistCLModels;
		}
	}
}