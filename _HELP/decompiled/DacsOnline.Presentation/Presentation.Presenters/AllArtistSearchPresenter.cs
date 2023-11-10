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
	public class AllArtistSearchPresenter : BasePresenter<IAllArtistSearchView>, IDisposable
	{
		private IAllArtistSearchService _service;

		public AllArtistSearchPresenter(IAllArtistSearchView view, IAllArtistSearchService service) : base(view)
		{
			base.View.FilterOnClick += new SearchAllArtistInvoke(this.SearchArtist);
			base.View.PageOnLoad += new EventHandler(this.InitialisePage);
			this._service = service;
		}

		public void Dispose()
		{
			base.View.FilterOnClick -= new SearchAllArtistInvoke(this.SearchArtist);
			base.View.PageOnLoad -= new EventHandler(this.InitialisePage);
		}

		private void InitialisePage(object sender, EventArgs args)
		{
			List<string> array = this._service.GetNavigation();
			base.View.SetNavigation(array);
		}

		private void SearchArtist(string StartingWord, int Pgae, int PageSize)
		{
			int totalItems;
			try
			{
				List<ArtistCombined> list = this._service.GetArtist(StartingWord, Pgae, PageSize, out totalItems);
				base.View.SetPagingControl(StartingWord, totalItems, PageSize, Pgae);
				base.View.Display(list);
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "AllArtistSearchPresenter-presenter", exception.Message);
				throw;
			}
		}
	}
}