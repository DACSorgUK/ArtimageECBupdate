using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;

namespace SQLDataAccess
{
    public abstract class DataAccess
    {
        #region // protected properties

        private string _connectionString;

        #endregion

        public DataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region // public properties

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }

        #endregion

        #region // helper methods

        /// <summary>
        /// Gets a value from the data row.
        /// </summary>
        /// <param name="valueToSet">Property to set. Used for overloading this function</param>
        /// <param name="columnName">Column name to get value from</param>
        /// <param name="row">DataRow</param>
        /// <returns>The column value from the datarow</returns>
        public string GetValue(string valueToSet, DataRow row, params string[] columnNames)
        {
            bool colmunMatch =false;

            foreach (string columnName in columnNames)
            {
                if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                {
                    return Convert.ToString(row[columnName]);
                }
                else if (row.Table.Columns.Contains(columnName))
                {
                    colmunMatch = true;
                }
            }

            if (!colmunMatch)
            {
                throw new DataAccessException("None of the column names specified could be found");
            }

            return "";
        }

        /// <summary>
        /// Gets a value from the data row.
        /// </summary>
        /// <param name="valueToSet">Property to set. Used for overloading this function</param>
        /// <param name="row">DataRow</param>
        /// <param name="columnNames">Column names to look for in the data row. The first column matched in the data row will be returned</param>
        /// <returns>The column value from the datarow</returns>
        public int GetValue(int valueToSet, DataRow row, params string[] columnNames)
        {
            bool colmunMatch = false;

            foreach (string columnName in columnNames)
            {
                if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                {
                    if (!string.IsNullOrEmpty(row[columnName].ToString()))
                    {
                        return Convert.ToInt32(row[columnName].ToString());
                    }
                }
            }

            if (!colmunMatch)
            {
                throw new DataAccessException("None of the column names specified could be found");
            }

            return 0;
        }

        /// <summary>
        /// Gets a value from the data row.
        /// </summary>
        /// <param name="valueToSet">Property to set. Used for overloading this function</param>
        /// <param name="row">DataRow</param>
        /// <param name="columnNames">Column names to look for in the data row. The first column matched in the data row will be returned</param>
        /// <returns>The column value from the datarow</returns>
        public long GetValue(long valueToSet, DataRow row, params string[] columnNames)
        {
            bool colmunMatch = false;

            foreach (string columnName in columnNames)
            {
                if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                {
                    if (!string.IsNullOrEmpty(row[columnName].ToString()))
                    {
                        return Convert.ToInt64(row[columnName].ToString());
                    }
                }
            }

            if (!colmunMatch)
            {
                throw new DataAccessException("None of the column names specified could be found");
            }

            return 0;
        }

        /// <summary>
        /// Gets a value from the data row.
        /// </summary>
        /// <param name="valueToSet">Property to set. Used for overloading this function</param>
        /// <param name="row">DataRow</param>
        /// <param name="columnNames">Column names to look for in the data row. The first column matched in the data row will be returned</param>
        /// <returns>The column value from the datarow</returns>
        public byte[] GetValue(byte[] valueToSet, DataRow row, params string[] columnNames)
        {
            bool colmunMatch = false;

            foreach (string columnName in columnNames)
            {
                if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                {
                    if (!string.IsNullOrEmpty(row[columnName].ToString()))
                    {
                        return (byte[])row[columnName];
                    }
                }
            }

            if (!colmunMatch)
            {
                throw new DataAccessException("None of the column names specified could be found");
            }

            return null;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="valueToSet">The value to set.</param>
        /// <param name="row">The row.</param>
        /// <param name="columnNames">The column names.</param>
        /// <returns></returns>
        public int? GetValue(int? valueToSet, DataRow row, params string[] columnNames)
        {
            bool colmunMatch = false;

            foreach (string columnName in columnNames)
            {
                if (row.Table.Columns.Contains(columnName))
                {
                    if (!string.IsNullOrEmpty(row[columnName].ToString()))
                    {
                        return Convert.ToInt32(row[columnName].ToString());
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            if (!colmunMatch)
            {
                throw new DataAccessException("None of the column names specified could be found");
            }

            return null;
        }

        /// <summary>
        /// Gets a value from the data row.
        /// </summary>
        /// <param name="valueToSet">Property to set. Used for overloading this function</param>
        /// <param name="row">DataRow</param>
        /// <param name="columnNames">Column names to look for in the data row. The first column matched in the data row will be returned</param>
        /// <returns>The column value from the datarow</returns>
        public decimal GetValue(decimal valueToSet, DataRow row, params string[] columnNames)
        {
            bool colmunMatch = false;

            foreach (string columnName in columnNames)
            {
                if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                {
                    if (!string.IsNullOrEmpty(row[columnName].ToString()))
                    {
                        return Convert.ToDecimal(row[columnName].ToString());
                    }
                }
            }

            if (!colmunMatch)
            {
                throw new DataAccessException("None of the column names specified could be found");
            }

            return 0.0M;
        }

        /// <summary>
        /// Gets a value from the data row.
        /// </summary>
        /// <param name="valueToSet">Property to set. Used for overloading this function</param>
        /// <param name="row">DataRow</param>
        /// <param name="columnNames">Column names to look for in the data row. The first column matched in the data row will be returned</param>
        /// <returns>The column value from the datarow</returns>
        public decimal? GetValue(decimal? valueToSet, DataRow row, params string[] columnNames)
        {
            bool colmunMatch = false;

            foreach (string columnName in columnNames)
            {
                if (row.Table.Columns.Contains(columnName))
                {
                    if (row[columnName] == DBNull.Value)
                        return null;

                    if (!string.IsNullOrEmpty(row[columnName].ToString()))
                    {
                        return Convert.ToDecimal(row[columnName].ToString());
                    }
                }
            }

            if (!colmunMatch)
            {
                throw new DataAccessException("None of the column names specified could be found");
            }

            return 0.0M;
        }

        /// <summary>
        /// Gets a value from the data row.
        /// </summary>
        /// <param name="valueToSet">Property to set. Used for overloading this function</param>
        /// <param name="row">DataRow</param>
        /// <param name="columnNames">Column names to look for in the data row. The first column matched in the data row will be returned</param>
        /// <returns>The column value from the datarow</returns>
        public bool GetValue(bool valueToSet, DataRow row, params string[] columnNames)
        {
            bool colmunMatch = false;

            foreach (string columnName in columnNames)
            {
                if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                {
                    if (!string.IsNullOrEmpty(row[columnName].ToString()))
                    {
                        return Convert.ToBoolean(row[columnName]);
                    }
                }
            }

            if (!colmunMatch)
            {
                throw new DataAccessException("None of the column names specified could be found");
            }

            return false;
        }

        /// <summary>
        /// Gets a value from the data row.
        /// </summary>
        /// <param name="valueToSet">Property to set. Used for overloading this function</param>
        /// <param name="row">DataRow</param>
        /// <param name="columnNames">Column names to look for in the data row. The first column matched in the data row will be returned</param>
        /// <returns>The column value from the datarow</returns>
        public DateTime GetValue(DateTime valueToSet, DataRow row, params string[] columnNames)
        {
            bool colmunMatch = false;

            foreach (string columnName in columnNames)
            {
                if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                {
                    if (!string.IsNullOrEmpty(row[columnName].ToString()))
                    {
                        return Convert.ToDateTime(row[columnName].ToString());
                    }
                }
            }

            if (!colmunMatch)
            {
                throw new DataAccessException("None of the column names specified could be found");
            }

            return DateTime.MinValue;
        }

        /// <summary>
        /// Gets a value from the data row.
        /// </summary>
        /// <param name="valueToSet">Property to set. Used for overloading this function</param>
        /// <param name="row">DataRow</param>
        /// <param name="columnNames">Column names to look for in the data row. The first column matched in the data row will be returned</param>
        /// <returns>The column value from the datarow</returns>
        public Guid GetValue(Guid valueToSet, DataRow row, params string[] columnNames)
        {
            bool colmunMatch = false;

            foreach (string columnName in columnNames)
            {
                if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                {
                    if (!string.IsNullOrEmpty(row[columnName].ToString()))
                    {
                        return new Guid(row[columnName].ToString());
                    }
                }
            }

            if (!colmunMatch)
            {
                throw new DataAccessException("None of the column names specified could be found");
            }

            return Guid.Empty;
        }

        /// <summary>
        /// IMPORTANT: These methods are slow and should not be used in fast track code.
        /// 
        /// Returns a new instance of the object defined by T. If no object could be loaded from the data null is returned e.g:
        /// tariff.Handset = (MyClass)base.GetValue<MyClass>(typeof(string), row, "ID");
        /// </summary>
        /// <typeparam name="T">Type of object to create</typeparam>
        /// <param name="constructorParamType">Type of param that the object (type T) constructor requires</param>
        /// <param name="assemblyForClass">The assembly that the class is defined within</param>
        /// <param name="row">DataRow</param>
        /// <param name="columnNames">Column names to look for in the data row. The first column matched in the data row will be returned</param>
        /// <returns>New object or null</returns>
        /// 
        public T GetValue<T>(Type constructorParamType, Assembly assemblyForClass, DataRow row, params string[] columnNames) where T : class, new()
        {
            bool colmunMatch = false;
            T toReturn = null;

            foreach (string columnName in columnNames)
            {
                if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                {
                    if (!string.IsNullOrEmpty(row[columnName].ToString()))
                    {
                        toReturn = GetValue<T>(constructorParamType, assemblyForClass, row[columnName].ToString());
                    }
                }
            }

            if (!colmunMatch)
            {
                throw new DataAccessException("None of the column names specified could be found");
            }

            return toReturn;
        }

        /// <summary>
        /// IMOPRTANT: These methods are slow and should not be used in fast track code.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="constructorParamType"></param>
        /// <param name="assemblyForClass"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected T GetValue<T>(Type constructorParamType, Assembly assemblyForClass, string value) where T : class, new()
        {
            T toReturn = null;
            string typeOfObject = typeof(T).ToString();
            object objValue = value;
            ConstructorInfo[] constructors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.Public);

            //convert the value to the parameter type needed by the constructor
            if (constructorParamType == typeof(Guid))
            {
                objValue = new Guid(objValue.ToString());
            }
            else
            {
                objValue = Convert.ChangeType(objValue, constructorParamType);
            }

            //create an instance of T
            toReturn = (T)assemblyForClass.CreateInstance(typeOfObject, true, BindingFlags.Instance | BindingFlags.Public,
                null, new object[1] { objValue }, System.Globalization.CultureInfo.CurrentCulture, null);
            

            return toReturn;
        }

        /// <summary>
        /// Returns the element value casted as the type specified in T.
        /// </summary>
        /// <typeparam name="T">Type to cast to</typeparam>
        /// <param name="elementPropertyName">Element property name to extract</param>
        /// <param name="element">Linq element</param>
        /// <returns></returns>
        public T GetValue<T>(DataRow row, params string[] columnNames)
        {
            bool colmunMatch = false;
            T toReturn = default(T);

            foreach (string columnName in columnNames)
            {
                if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                {
                    return (T)Convert.ChangeType(row[columnName], typeof(T));
                }
                else if (row.Table.Columns.Contains(columnName))
                {
                    colmunMatch = true;
                }
            }

            if (!colmunMatch)
            {
                throw new DataAccessException("None of the column names specified could be found");
            }

            return toReturn;
        }

        #endregion
    }
}
