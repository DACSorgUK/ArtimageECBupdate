using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Manager.Interfaces;

namespace DacsOnline.Model.Manager
{
    public class ConfirmationManager: IConfirmationManager
    {
        public string GetReference()
        {
            return "0123456";
        }

        public string GetformName()
        {
            return "Copyright licensing";
        }

        public string GetDacsEmail()
        {
            return "arr@dacs.com";
        }

        public string GetUserEmail()
        {
            return "user@email.com";
        }
    }
}
