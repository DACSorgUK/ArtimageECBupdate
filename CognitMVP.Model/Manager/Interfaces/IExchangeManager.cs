using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacsOnline.Model.Manager.Interfaces
{
    public interface IExchangeManager
    {
        decimal GetExchangeGBP(DateTime dt);
        decimal GetExchangeEuro(DateTime dt);
    }
}
