using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacsOnline.Model.Manager.Interfaces
{
    public interface ISubscribeEmail
    {
        bool SubscribeUser(string email, string emailType, string firstName, string lastName);
    }
}
