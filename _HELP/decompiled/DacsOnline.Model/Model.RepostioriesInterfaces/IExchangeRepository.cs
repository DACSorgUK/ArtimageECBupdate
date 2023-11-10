using System;

namespace DacsOnline.Model.RepostioriesInterfaces
{
	public interface IExchangeRepository
	{
		decimal GetExchangeGBP(DateTime dt);
	}
}