using DacsOnline.Model.Models;
using System;

namespace DacsOnline.Service.Service.Interfaces
{
	public interface IArtistDetailsService
	{
		ArtistCombined GetArtist(int idArtist, string YearSale);
	}
}