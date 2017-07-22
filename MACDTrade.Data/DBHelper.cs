using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MACDTrade.Data
{
    public class DBHelper : IDisposable
    {
        #region private members
        private SqlConnection connection = new SqlConnection();
        private SqlCommand command = new SqlCommand();
        private string ConnectionStr = "connectionStr";
        #endregion

        # region Ctor

        public DBHelper()
        {
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[ConnectionStr].ConnectionString;
            command.Connection = connection;
        }

        #endregion

        #region parameters

        public SqlParameter AddParameter(string name, object value)
        {
            return command.Parameters.AddWithValue(name, value);
        }

        public SqlParameter AddParameter(SqlParameter parameter)
        {
            return command.Parameters.Add(parameter);
        }

        #endregion

        #region transactions

        private void BeginTransaction()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            command.Transaction = connection.BeginTransaction();
        }

        private void CommitTransaction()
        {
            command.Transaction.Commit();
            connection.Close();
        }

        private void RollbackTransaction()
        {
            command.Transaction.Rollback();
            connection.Close();
        }

        private void Clear()
        {
            command.Parameters.Clear();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                //  connection.Dispose();
            }
        }

        #endregion

        #region Execute Database Functions

        public int ExecuteNonQuery(string query, CommandType commandtype = CommandType.Text)
        {
            command.CommandText = query;
            command.CommandType = commandtype;
            int i = -1;
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                BeginTransaction();

                i = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw (ex);
            }
            finally
            {
                CommitTransaction();
                Clear();
            }
            return i;
        }

        public object ExecuteScaler(string query, CommandType commandtype = CommandType.Text)
        {
            command.CommandText = query;
            command.CommandType = commandtype;
            object obj = null;
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                BeginTransaction();
                obj = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw (ex);
            }
            finally
            {
                CommitTransaction();
                Clear();//command.Dispose();
            }

            return obj;
        }

        public SqlDataReader ExecuteReader(string query, CommandType commandtype = CommandType.Text)
        {
            command.CommandText = query;
            command.CommandType = commandtype;
            SqlDataReader reader = null;
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                command.Parameters.Clear();
            }
            return reader;
        }

        public DataSet GetDataSet(string query, CommandType commandtype = CommandType.Text)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            command.CommandText = query;
            command.CommandType = commandtype;
            adapter.SelectCommand = command;
            DataSet ds = new DataSet();
            try
            {
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Clear();//command.Dispose();
            }
            return ds;
        }

        public DataTable GetDataTable(string query, CommandType commandType = CommandType.Text)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            command.CommandText = query;
            command.CommandType = commandType;
            adapter.SelectCommand = command;
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                Clear();//command.Dispose();
            }
            return ds.Tables.Count > 0 ? ds.Tables[0] : null;
        }

        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                connection.Dispose();
                command.Dispose();
            }
        }

        ~DBHelper()
        {
            Dispose(true);
        }
    }
}