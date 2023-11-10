using DacsOnline.Model.Enums;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.Models;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Service.Service.Interfaces;
using System;

namespace DacsOnline.Service.Service
{
	public class ArtistDetailsService : BaseService<IArtistDetailsManager>, IArtistDetailsService
	{
		public ArtistDetailsService(IArtistDetailsManager ArtistDetailsManager) : base(ArtistDetailsManager)
		{
		}

		public ArtistCombined GetArtist(int idArtist, string YearSale)
		{
			ArtistCombined artistCombined;
			ArtistCombined _artist = null;
			try
			{
				_artist = base.ServiceManager.GetArtist(idArtist, YearSale);
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "ArtistDetailsService-GetArtist", exception.Message);
				artistCombined = null;
				return artistCombined;
			}
			artistCombined = _artist;
			return artistCombined;
		}
	}
}