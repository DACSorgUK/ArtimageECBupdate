using DacsOnline.Model.Models;
using System;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
	public interface IArtistDetailsView : IView
	{
		string idArtist
		{
			get;
			set;
		}

		string YearSale
		{
			get;
			set;
		}

		void Load(ArtistCombined artist);

		event EventHandler PageOnLoad;
	}
}