using DacsOnline.Model.Enums;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.Models;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Service.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace DacsOnline.Service.Service
{
	public class ARRArtistSearchService : BaseService<IARRArtistSearchManager>, IARRArtistSearchService
	{
		public ARRArtistSearchService(IARRArtistSearchManager employeeServiceManager) : base(employeeServiceManager)
		{
		}

		public List<ArtistARRModel> GetArtists(string Year, string ArtistFirstName, string ArtistLastName, int Pgae, int PageSize, out int TotalItems, out int ExactMatches)
		{
			int totalItems;
			int exactMatches;
			List<ArtistARRModel> artistARRModels;
			List<ArtistARRModel> model = null;
			try
			{
				List<ArtistARRModel> artists = base.ServiceManager.SearchArtist(Year, ArtistFirstName, ArtistLastName, Pgae, PageSize, out totalItems, out exactMatches);
				TotalItems = totalItems;
				ExactMatches = exactMatches;
				model = artists;
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "ARRArtistSearchService-GetArtists", exception.Message);
				TotalItems = 1;
				ExactMatches = 0;
				artistARRModels = null;
				return artistARRModels;
			}
			artistARRModels = model;
			return artistARRModels;
		}

		public List<string> GetSalesYears()
		{
			return base.ServiceManager.GetSalesYears();
		}
	}
}