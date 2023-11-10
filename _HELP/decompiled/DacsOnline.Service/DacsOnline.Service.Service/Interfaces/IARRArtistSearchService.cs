using DacsOnline.Model.Models;
using System;
using System.Collections.Generic;

namespace DacsOnline.Service.Service.Interfaces
{
	public interface IARRArtistSearchService
	{
		List<ArtistARRModel> GetArtists(string Year, string ArtistFirstName, string ArtistLastName, int Pgae, int PageSize, out int TotalItems, out int exactMatches);

		List<string> GetSalesYears();
	}
}