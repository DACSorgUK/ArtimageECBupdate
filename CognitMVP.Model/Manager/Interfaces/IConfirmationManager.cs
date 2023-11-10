using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacsOnline.Model.Manager.Interfaces
{
    public interface IConfirmationManager
    {
         string GetReference();
         string GetformName();
         string GetDacsEmail();
         string GetUserEmail();
        
    }
}
