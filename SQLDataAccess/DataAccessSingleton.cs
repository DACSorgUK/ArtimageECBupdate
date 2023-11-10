using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace SQLDataAccess
{
    /// <summary>
    /// This class can be used to create an instance of a data access class if you have a connection string defined 
    /// called "siteConnectionString"
    /// </summary>
    public static class DataAccessSingleton
    {
        #region // private properties

        private static SQLServerDataAccess _SQLServerDataAccess;

        #endregion

        #region // singletons

        public static SQLServerDataAccess SQLServerInstance
        {
            get
            {
                if (_SQLServerDataAccess == null)
                {
                    _SQLServerDataAccess = (SQLServerDataAccess)DataAccessFactory.CreateInstance(DataAccessType.SQLServer, ConfigurationManager.ConnectionStrings["siteConnectionString"].ToString());
                }

                return _SQLServerDataAccess;
            }
        }

        #endregion
    }
}
