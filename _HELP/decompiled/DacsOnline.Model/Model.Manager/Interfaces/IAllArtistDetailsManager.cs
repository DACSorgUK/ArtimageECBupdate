using DacsOnline.Model.Models;
using System;
using System.Collections.Generic;

namespace DacsOnline.Model.Manager.Interfaces
{
	public interface IAllArtistDetailsManager
	{
		List<string> GetCharactors();

		List<ArtistCombined> SearchArtist(string StartingWord, int page, int pageSize, out int TotalItems);
	}
}