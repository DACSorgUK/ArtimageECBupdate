using System;

namespace DacsOnline.Model.Manager.Interfaces
{
	public interface ISubscribeEmail
	{
		bool SubscribeUser(string email, string emailType, string firstName, string lastName);
	}
}