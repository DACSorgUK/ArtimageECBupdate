using DacsOnline.Model.Enums;
using DacsOnline.Model.Models;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Presentation.Views;
using DacsOnline.Service.Service.Interfaces;
using System;
using System.Collections.Generic;
using WebFormsMvp;

namespace DacsOnline.Presentation.Presenters
{
	public class CLArtistSearchPresenter : BasePresenter<ICLArtistSearchView>, IDisposable
	{
		private ICLArtistSearchService _service;

		public CLArtistSearchPresenter(ICLArtistSearchView view, ICLArtistSearchService service) : base(view)
		{
			base.View.FilterOnClick += new SearchArtistInvoke(this.SearchArtist);
			base.View.PageOnLoad += new EventHandler(this.InitialisePage);
			this._service = service;
		}

		public void Dispose()
		{
			base.View.FilterOnClick -= new SearchArtistInvoke(this.SearchArtist);
			base.View.PageOnLoad -= new EventHandler(this.InitialisePage);
		}

		public void InitialisePage(object sender, EventArgs e)
		{
			try
			{
				base.View.SetControls();
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "InitialisePage-presenter", exception.Message);
				throw;
			}
		}

		private void SearchArtist(string Year, string ArtistFirstName, string ArtistLastName, int Pgae, int PageSize)
		{
			int totalItems;
			int exactMatches;
			try
			{
				List<ArtistCLModel> list = this._service.GetArtists(Year, ArtistFirstName, ArtistLastName, Pgae, PageSize, out totalItems, out exactMatches);
				base.View.SetPagingControl(totalItems, PageSize, Pgae, ArtistFirstName, ArtistLastName, Year, exactMatches);
				base.View.Display(list);
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "SearchArtist-presenter", exception.Message);
				throw;
			}
		}
	}
}