using System;
using System.Collections.Generic;

namespace DacsOnline.Model.Business_Objects
{
	public class DistinctArtistId : IEqualityComparer<Artist>
	{
		public DistinctArtistId()
		{
		}

		public bool Equals(Artist x, Artist y)
		{
			return x.ArtistId.Equals(y.ArtistId);
		}

		public int GetHashCode(Artist obj)
		{
			return obj.ArtistId.GetHashCode();
		}
	}
}