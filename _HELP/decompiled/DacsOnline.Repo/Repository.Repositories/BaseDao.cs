using SQLDataAccess;
using System;
using System.Runtime.CompilerServices;

namespace DacsOnline.Repository.Repositories
{
	public abstract class BaseDao
	{
		protected string ConnectionString
		{
			get;
			private set;
		}

		protected SQLServerDataAccess DataAccess
		{
			get;
			set;
		}

		protected BaseDao(string connectionString)
		{
			this.DataAccess = new SQLServerDataAccess(connectionString);
			this.ConnectionString = connectionString;
		}
	}
}