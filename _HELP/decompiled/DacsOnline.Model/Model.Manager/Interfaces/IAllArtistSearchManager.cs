using DacsOnline.Model.Models;
using System;
using System.Collections.Generic;

namespace DacsOnline.Model.Manager.Interfaces
{
	public interface IAllArtistSearchManager
	{
		List<ArtistARRModel> SearchArtist(string ArtistName, int page, int pageSize, out int TotalItems);
	}
}