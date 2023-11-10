using DacsOnline.Model.Business_Objects;
using System;

namespace DacsOnline.Model.RepostioriesInterfaces
{
	public interface IArtistDetailsRepository
	{
		Artist GetArtistData(int idArtist);
	}
}