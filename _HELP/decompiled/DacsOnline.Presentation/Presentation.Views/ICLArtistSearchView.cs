using DacsOnline.Model.Models;
using DacsOnline.Presentation.Presenters;
using System;
using System.Collections.Generic;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
	public interface ICLArtistSearchView : IView
	{
		void Display(List<ArtistCLModel> artist);

		void SetControls();

		void SetPagingControl(int totalItems, int recordsPerPage, int currentPage, string artistFirstName, string artistLastName, string Year, int exactMatches);

		event SearchArtistInvoke FilterOnClick;

		event EventHandler PageOnLoad;
	}
}