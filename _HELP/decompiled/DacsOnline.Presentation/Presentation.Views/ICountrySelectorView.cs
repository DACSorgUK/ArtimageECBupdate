using System;
using System.Collections.Generic;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
	public interface ICountrySelectorView : IView
	{
		string Country
		{
			get;
			set;
		}

		void BindCountry(List<string> CountryList);

		event EventHandler LoadForm;
	}
}