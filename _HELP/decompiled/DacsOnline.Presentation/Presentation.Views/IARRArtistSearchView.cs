using DacsOnline.Model.Models;
using DacsOnline.Presentation.Presenters;
using System;
using System.Collections.Generic;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
	public interface IARRArtistSearchView : IView
	{
		void BindYears(List<string> Years);

		void Display(List<ArtistARRModel> artist);

		void SetControls(bool cookieStatus);

		void SetPagingControl(int totalItems, int recordsPerPage, int currentPage, string artistFirstName, string artistLastName, string Year, int exactMatches);

		event SearchArtistInvoke FilterOnClick;

		event EventHandler PageOnLoad;

		event EventHandler SetSearchCookie;
	}
}