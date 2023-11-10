using DacsOnline.Model.Models;
using System;
using System.Collections.Generic;

namespace DacsOnline.Service.Service.Interfaces
{
	public interface ICLArtistSearchService
	{
		List<ArtistCLModel> GetArtists(string Year, string ArtistFirstName, string ArtistLastName, int Pgae, int PageSize, out int TotalItems, out int ExactMatches);
	}
}