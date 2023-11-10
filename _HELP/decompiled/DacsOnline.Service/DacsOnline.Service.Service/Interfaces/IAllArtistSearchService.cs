using DacsOnline.Model.Models;
using System;
using System.Collections.Generic;

namespace DacsOnline.Service.Service.Interfaces
{
	public interface IAllArtistSearchService
	{
		List<ArtistCombined> GetArtist(string StartingWord, int page, int pageSize, out int TotalItems);

		List<string> GetNavigation();
	}
}