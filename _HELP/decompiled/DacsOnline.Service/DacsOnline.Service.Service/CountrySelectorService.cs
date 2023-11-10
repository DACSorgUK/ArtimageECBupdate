using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.RepostioriesInterfaces;
using DacsOnline.Service.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DacsOnline.Service.Service
{
	public class CountrySelectorService : ICountrySelectorService
	{
		private IARRArtistSearchRepository _SearchRepository;

		public CountrySelectorService(IARRArtistSearchRepository SearchRepository)
		{
			this._SearchRepository = SearchRepository;
		}

		public List<string> GetCountries()
		{
			List<string> list = (
				from p in this._SearchRepository.GetNationalities()
				select p.Country).ToList<string>();
			return list;
		}
	}
}