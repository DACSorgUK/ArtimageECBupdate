using DacsOnline.Model.Enums;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Presentation.Views;
using DacsOnline.Service.Service.Interfaces;
using System;
using WebFormsMvp;

namespace DacsOnline.Presentation.Presenters
{
	public class ArtistDetailsPresenter : BasePresenter<IArtistDetailsView>, IDisposable
	{
		private IArtistDetailsService _service;

		public ArtistDetailsPresenter(IArtistDetailsView view, IArtistDetailsService service) : base(view)
		{
			base.View.PageOnLoad += new EventHandler(this.InitialisePage);
			this._service = service;
		}

		public void Dispose()
		{
			base.View.PageOnLoad -= new EventHandler(this.InitialisePage);
		}

		public void InitialisePage(object sender, EventArgs e)
		{
			try
			{
				if (base.View.idArtist.Trim() != "")
				{
					base.View.Load(this._service.GetArtist(int.Parse(base.View.idArtist), base.View.YearSale));
				}
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "InitialisePage-ArtistDetailsPresenter", exception.Message);
				throw;
			}
		}
	}
}