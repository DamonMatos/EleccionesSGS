using System.Data;
using System.Data.SqlClient;

namespace WSEleccionesSSMA.Utility
{
    public static class SqlHelper
    {
        public static string ExecuteProcedureReturnString(string connString, string procName, params SqlParameter[] paramters)
        {
            string result = "";
            using (var sqlConnection = new SqlConnection(connString))
            {
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = procName;
                    if (paramters != null)
                    {
                        command.Parameters.AddRange(paramters);
                    }
                    sqlConnection.Open();
                    var ret = command.ExecuteScalar();
                    if (ret != null)
                        result = (String) ret;

                }
            }
            return result;

        }

        public static void ExecuteProcedureSinReturn(string connString, string procName, params SqlParameter[] paramters)
        {
            //string result = "";
            using (var sqlConnection = new SqlConnection(connString))
            {
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = procName;
                    if (paramters != null)
                    {
                        command.Parameters.AddRange(paramters);
                    }
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }

        }


        public static TData ExecuteProcedureReturnData<TData>(string connString, string procName, Func<SqlDataReader, TData> translator, params SqlParameter[] parameters)
        {
            using (var sqlConnection = new SqlConnection(connString))
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = procName;
                    if (parameters != null)
                    {
                        sqlCommand.Parameters.AddRange(parameters);
                    }
                    sqlConnection.Open();
                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        TData elements;
                        try
                        {
                            elements = translator(reader);
                        }
                        finally
                        {
                            while (reader.NextResult())
                            {
                            }
                        }
                        return elements;
                    }
                }
            }
        }


        public static TData ExecuteProcedureReturnDataSinParameters<TData>(string connString, string procName, Func<SqlDataReader, TData> translator)
        {
            using (var sqlConnection = new SqlConnection(connString))
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = procName;
                    sqlConnection.Open();
                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        TData elements;
                        try
                        {
                            elements = translator(reader);
                        }
                        finally
                        {
                            while (reader.NextResult())
                            {
                            }
                        }
                        return elements;
                    }
                }
            }
        }

       

        public static DataSet ExecuteProcedureReturnDataSet(string connString, string procName, params SqlParameter[] paramters)
        {
            DataSet result;
            using (var sqlConnection = new SqlConnection(connString))
            {
                using (var command = sqlConnection.CreateCommand())
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = procName;
                        if (paramters != null)
                        {
                            command.Parameters.AddRange(paramters);
                        }
                        result = new DataSet();
                        sda.Fill(result);
                    }
                }
            }
            return result;
        }


        #region Get Values from Sql Data Reader
    

        public static String? GetNullableString(SqlDataReader reader, String colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? null : (string) reader[colName];
        }

        public static String GettableString(SqlDataReader reader, String colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? "" : (string)reader[colName];
        }

        public static int GetNullableInt32(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? 0 : Convert.ToInt32(reader[colName]);
        }

        public static decimal GetNullableDecimal(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? 0 : Convert.ToDecimal(reader[colName]);
        }

        public static bool GetBoolean(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? default(bool) : Convert.ToBoolean(reader[colName]);
        }

        public static bool IsColumnExists(this System.Data.IDataRecord dr, string colName)
        {
            try
            {
                return (dr.GetOrdinal(colName) >= 0);
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

    }
}
