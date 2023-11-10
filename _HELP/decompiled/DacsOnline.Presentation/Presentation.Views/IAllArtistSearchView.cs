using DacsOnline.Model.Models;
using DacsOnline.Presentation.Presenters;
using System;
using System.Collections.Generic;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
	public interface IAllArtistSearchView : IView
	{
		void Display(List<ArtistCombined> artist);

		void SetNavigation(List<string> array);

		void SetPagingControl(string wordSelected, int totalItems, int recordsPerPage, int currentPage);

		event SearchAllArtistInvoke FilterOnClick;

		event EventHandler PageOnLoad;
	}
}