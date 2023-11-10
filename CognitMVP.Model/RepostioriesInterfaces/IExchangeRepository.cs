using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacsOnline.Model.RepostioriesInterfaces
{
    /// <summary>
    /// Get the rate
    /// </summary>
    public interface IExchangeRepository
    {
        decimal GetExchangeGBP(DateTime dt);
    }
}
