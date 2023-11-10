using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Models;
using System;
using System.Collections.Generic;

namespace DacsOnline.Model.Manager.Interfaces
{
	public interface IARRArtistSearchManager
	{
		List<string> GetSalesYears();

		List<ArtistARRModel> SearchArtist(string SaleYear, string ArtistFirstName, string ArtistLastName, int page, int pageSize, out int TotalItems, out int ExactMatches);

		void SetMessages(Artist obj, ArtistARRModel modObj, string SaleYear);
	}
}