using System;

namespace DacsOnline.Model.Manager.Interfaces
{
	public interface IExchangeManager
	{
		decimal GetExchangeEuro(DateTime dt);

		decimal GetExchangeGBP(DateTime dt);
	}
}