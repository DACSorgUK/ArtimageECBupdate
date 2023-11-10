using DacsOnline.Model.Business_Objects;
using System;
using System.Collections.Generic;

namespace DacsOnline.Model.RepostioriesInterfaces
{
	public interface IARRArtistSearchRepository
	{
		List<Artist> GetArtistsData();

		List<Nationality> GetNationalities();

		List<string> GetSalesYears();
	}
}