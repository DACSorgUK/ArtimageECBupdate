using System;
using System.Collections.Generic;
using System.Text;

namespace SQLDataAccess
{
    public class SQLServerDataAccess : GenericDataAccess
        <System.Data.SqlClient.SqlConnection, System.Data.SqlClient.SqlCommand, System.Data.SqlClient.SqlDataAdapter, System.Data.SqlClient.SqlParameter>
    {
        public SQLServerDataAccess(string connectionString)
            : base(connectionString)
        { }
    }
}
