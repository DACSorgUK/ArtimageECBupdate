using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Data;
using System.Configuration.Internal;
using System.Reflection;

namespace SQLDataAccess
{
    /// <summary>
    /// Generic base class all data access class should be derived from
    /// </summary>
    /// <typeparam name="Conn">Connection Parameter</typeparam>
    /// <typeparam name="Comm">Command Parameter</typeparam>
    /// <typeparam name="Adap">DataAdapter Parameter</typeparam>
    public class GenericDataAccess<Conn, Comm, Adap, Param> : DataAccess
        where Conn : System.Data.IDbConnection, new()
        where Comm : System.Data.IDbCommand, new()
        where Adap : System.Data.IDbDataAdapter, new()
        where Param : System.Data.IDataParameter, new()
    {

        #region // delegates
        internal delegate TData LoadDelegate<TData>(Comm comm);
        internal delegate void LoadDelegate(Comm comm);
        public delegate void LoadObjectDelegate<TClass>(TClass objectToPopulate, DataRow dataRow);
        #endregion

        #region // contructors

        public GenericDataAccess(string connectionString) : base(connectionString)
        { }

        #endregion

        #region // db functions

        /// <summary>
        /// Executes a stored procedure with no return value
        /// </summary>
        /// <param name="storedProcedure">Stored procedure to execute</param>
        public void ExecuteStoredProcedure(Comm storedProcedure)
        {
            using (Conn conn = new Conn())
            {
                conn.ConnectionString = this.ConnectionString;
                storedProcedure.Connection = conn;
                try
                {
                    conn.Open();
                    storedProcedure.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Executes the stored procedure.
        /// </summary>
        /// <param name="Command">The command.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="Params">The params.</param>
        public void ExecuteStoredProcedure(string Command, CommandType commandType, params Param[] Params)
        {
            CreateCommandAndExecuteDynamicMethod(this.ExecuteStoredProcedure, Command, commandType, 60, Params);
        }

        /// <summary>
        /// Executes a stored procedure and returns a single value as a string
        /// </summary>
        /// <param name="storedProcedure">Stored procedure to execute</param>
        /// <returns></returns>
        public string ExecuteScalar(Comm storedProcedure)
        {
            string toReturn = string.Empty;
            object value;

            using (Conn conn = new Conn())
            {
                conn.ConnectionString = this.ConnectionString;
                storedProcedure.Connection = conn;
                
                try
                {
                    conn.Open();                    
                    value = storedProcedure.ExecuteScalar();
                    if (value != null)
                    {
                        toReturn = value.ToString();
                    }
                }
                finally
                {
                    conn.Close();
                }
            }

            return toReturn;
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="Command">The command.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="Params">The params.</param>
        /// <returns></returns>
        public string ExecuteScalar(string Command, CommandType commandType, params Param[] Params)
        {
            return CreateCommandAndExecuteDynamicMethod<string>(this.ExecuteScalar, Command, commandType, 60, Params);
        }

        /// <summary>
        /// Executes a stored procedure and returns data as a DataSet
        /// </summary>
        /// <param name="storedProcedure">Stored procedure to execute</param>
        /// <returns></returns>
        public DataSet ReturnDataSet(Comm storedProcedure)
        {
            DataSet dataSet = new DataSet();
            Adap adapter = new Adap();

            adapter.SelectCommand = storedProcedure;

            using (Conn conn = new Conn())
            {
                conn.ConnectionString = this.ConnectionString;

                storedProcedure.Connection = conn;

                try
                {
                    adapter.Fill(dataSet);
                }
                finally
                {
                    conn.Close();
                }
            }

            return dataSet;
        }

        /// <summary>
        /// Returns the data set.
        /// </summary>
        /// <param name="Command">The command.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="Params">The params.</param>
        /// <returns></returns>
        public DataSet ReturnDataSet(string Command, CommandType commandType, params Param[] Params)
        {
            return CreateCommandAndExecuteDynamicMethod<DataSet>(this.ReturnDataSet, Command, commandType, 60, Params);
        }

        /// <summary>
        /// Executes a stored procedure and returns data as a DataTable
        /// </summary>
        /// <param name="storedProcedure">Stored procedure to execute</param>
        /// <returns></returns>
        public DataTable ReturnDataTable(Comm storedProcedure)
        {
            DataSet dataset = new DataSet();
            dataset = ReturnDataSet(storedProcedure);
            DataTable dataTable = null;

            if (dataset.Tables.Count > 0)
            {
                dataTable = dataset.Tables[0];
            }

            return dataTable;
        }

        /// <summary>
        /// Returns the data table.
        /// </summary>
        /// <param name="Command">The command.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="Params">The params.</param>
        /// <returns></returns>
        public DataTable ReturnDataTable(string Command, CommandType commandType,params Param[] Params)
        {
            return CreateCommandAndExecuteDynamicMethod<DataTable>(this.ReturnDataTable, Command, commandType, 60, Params);
        }

        /// <summary>
        /// Returns the data table.
        /// </summary>
        /// <param name="Command">The command.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        /// <param name="Params">The params.</param>
        /// <returns></returns>
        public DataTable ReturnDataTable(string Command, CommandType commandType, int commandTimeout, params Param[] Params)
        {
            return CreateCommandAndExecuteDynamicMethod<DataTable>(this.ReturnDataTable, Command, commandType, commandTimeout, Params);
        }

        /// <summary>
        /// Executes a stored procedure and returns data as a DataRow
        /// </summary>
        /// <param name="storedProcedure">Stored procedure to execute</param>
        /// <returns>Row of data or null if no row found</returns>
        public DataRow ReturnDataRow(Comm storedProcedure)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow = null;

            dataTable = ReturnDataTable(storedProcedure);

            if (dataTable.Rows.Count > 0)
            {
                dataRow = dataTable.Rows[0];
            }

            return dataRow;
        }

        /// <summary>
        /// Returns the data row.
        /// </summary>
        /// <typeparam name="StoreProcedureParameter">The type of the tore procedure parameter.</typeparam>
        /// <param name="Command">The command.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="storeProcedureParameters">The store procedure parameters.</param>
        /// <returns>Row of data or null if no row found</returns>
        public DataRow ReturnDataRow(string Command, CommandType commandType,params Param[] Params)
        {
            return CreateCommandAndExecuteDynamicMethod<DataRow>(this.ReturnDataRow, Command, commandType, 60, Params);
        }

        /// <summary>
        /// Returns the data row.
        /// </summary>
        /// <param name="Command">The command.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        /// <param name="Params">The params.</param>
        /// <returns></returns>
        public DataRow ReturnDataRow(string Command, CommandType commandType, int commandTimeout, params Param[] Params)
        {
            return CreateCommandAndExecuteDynamicMethod<DataRow>(this.ReturnDataRow, Command, commandType, commandTimeout, Params);
        }

        /// <summary>
        /// Returns as list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="loadObjectDelegate">The load object delegate.</param>
        /// <param name="Command">The command.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="Params">The params.</param>
        /// <returns></returns>
        public List<T> ReturnAsList<T>(LoadObjectDelegate<T> loadObjectDelegate, string Command, CommandType commandType, params Param[] Params)
            where T : class, new()
        {
            List<T> newList = new List<T>();
            DataTable dataTable;

            using (Comm comm = new Comm())
            {
                comm.CommandText = Command;
                comm.CommandType = commandType;

                for (int i = 0; i < Params.Length; i++)
                {
                    comm.Parameters.Add(Params[i]);
                }

                dataTable = this.ReturnDataTable(comm);
                newList = ReturnAsList<T>(loadObjectDelegate, dataTable);
            }

            return newList;
        }

        /// <summary>
        /// Returns as list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="loadObjectDelegate">The load object delegate.</param>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public List<T> ReturnAsList<T>(LoadObjectDelegate<T> loadObjectDelegate, Comm command)
            where T : class, new()
        {
            DataTable dataTable = this.ReturnDataTable(command);

            return ReturnAsList<T>(loadObjectDelegate, dataTable);
        }

        /// <summary>
        /// Returns as list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="loadObjectDelegate">The load object delegate.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public List<T> ReturnAsList<T>(LoadObjectDelegate<T> loadObjectDelegate, DataTable data)
            where T : class, new()
        {
            List<T> listToReturn = new List<T>();

            if (data != null)
            {
                foreach (DataRow row in data.Rows)
                {
                    T listItem = new T();

                    //call delegate on data access layer to populate object
                    loadObjectDelegate.Invoke(listItem, row);

                    listToReturn.Add(listItem);
                }
            }

            return listToReturn;
        }

        /// <summary>
        /// Returns the column as list.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="command">The command.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        public List<TObject> ReturnColumnAsList<TObject>(Comm command, string columnName)
        {
            DataTable data = this.ReturnDataTable(command);

            return this.ReturnColumnAsList<TObject>(data, columnName);
        }

        /// <summary>
        /// Returns the column as list.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="data">The data.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        public List<TObject> ReturnColumnAsList<TObject>(DataTable data, string columnName)
        {
            List<TObject> listToReturn = new List<TObject>();

            if (data != null)
            {
                foreach (DataRow row in data.Rows)
                {
                    TObject listItem = this.GetValue<TObject>(row, columnName);
                    listToReturn.Add(listItem);
                }
            }

            return listToReturn;
        }


        /// <summary>
        /// Creates the command and execute dynamic method.
        /// </summary>
        /// <typeparam name="TData">The type of the data.</typeparam>
        /// <param name="dynamicMethod">The dynamic method.</param>
        /// <param name="Command">The command.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        /// <param name="Params">The params.</param>
        /// <returns></returns>
        private TData CreateCommandAndExecuteDynamicMethod<TData>
            (LoadDelegate<TData> dynamicMethod, string Command, CommandType commandType, int commandTimeout, params Param[] Params) 
            where TData : class
        {
            TData data = null;
            using (Comm comm = new Comm())
            {
                comm.CommandText = Command;
                comm.CommandType = commandType;
                comm.CommandTimeout = commandTimeout;

                for (int i = 0; i < Params.Length; i++)
                {
                    comm.Parameters.Add(Params[i]);
                }

                data = dynamicMethod.Invoke(comm) as TData;

            } 
            return data;
        }

        /// <summary>
        /// Creates the command and execute dynamic method.
        /// </summary>
        /// <param name="dynamicMethod">The dynamic method.</param>
        /// <param name="Command">The command.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        /// <param name="Params">The params.</param>
        private void CreateCommandAndExecuteDynamicMethod
            (LoadDelegate dynamicMethod, string Command, CommandType commandType, int commandTimeout, params Param[] Params)
        {
            using (Comm comm = new Comm())
            {
                comm.CommandText = Command;
                comm.CommandType = commandType;
                comm.CommandTimeout = commandTimeout;

                for (int i = 0; i < Params.Length; i++)
                {
                    comm.Parameters.Add(Params[i]);
                }

                dynamicMethod.Invoke(comm);
            }
        }

        #endregion        
    }

    //// We need framework 3.5 for this to work current framework is 2.0
    ////public static class DataParameterCollectionExtension
    ////{
    ////    public static void Consume<Param>(this IDataParameterCollection paramterCollection, params Param[] spParams)
    ////    {
    ////        for (int i = 0; i < spParams.Length; i++)
    ////        {
    ////            paramterCollection.Add(spParams[i]);
    ////        }
    ////    }
    ////}
}
