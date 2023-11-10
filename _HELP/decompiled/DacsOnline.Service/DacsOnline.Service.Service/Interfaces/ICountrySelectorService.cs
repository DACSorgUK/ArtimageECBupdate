using System;
using System.Collections.Generic;

namespace DacsOnline.Service.Service.Interfaces
{
	public interface ICountrySelectorService
	{
		List<string> GetCountries();
	}
}