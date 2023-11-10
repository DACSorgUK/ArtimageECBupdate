using System;
using System.Collections.Generic;
using System.Text;

namespace SQLDataAccess
{
    /// <summary>
    /// Used to create an instance of a DataAccess class
    /// </summary>
    public static class DataAccessFactory
    {
        /// <summary>
        /// Creates an instance of a data access class
        /// </summary>
        /// <param name="dlType">Type of class to create</param>
        /// <param name="connectionString">DB Connection string</param>
        /// <returns>Type of class cast down to the baseAccess class</returns>
        public static DataAccess CreateInstance(DataAccessType dlType, string connectionString)
        {
            DataAccess dataAccess = null;

            switch (dlType)
            {
                case DataAccessType.SQLServer:
                    dataAccess = new SQLServerDataAccess(connectionString);

                    break;

            }

            return dataAccess;
        }
    }
}
