using DacsOnline.Model.Models;
using System;

namespace DacsOnline.Model.Manager.Interfaces
{
	public interface IArtistDetailsManager
	{
		ArtistCombined GetArtist(int idArtist, string YearSale);
	}
}