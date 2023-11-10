using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLDataAccess;

namespace DacsOnline.Repository.Repositories
{
    public  abstract class BaseDao
    {
        protected SQLServerDataAccess DataAccess { get; set; }

        protected String ConnectionString { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDao"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        protected BaseDao(String connectionString)
        {
            DataAccess = new SQLServerDataAccess(connectionString);
            ConnectionString = connectionString;
        }
    }
}
