using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.DB_Layer
{
    public class DLMain
    {
        private string connectionString = "Data Source = DESKTOP-LKP2UCO; " +
            "Initial Catalog = PlayerManagement; Integrated Security = True";
        private SqlConnection connection = null;
        private SqlDataAdapter dataAdapter = null;
        private SqlCommand command = null;

        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public SqlConnection Connection { get => connection; set => connection = value; }
        public SqlDataAdapter DataAdapter { get => dataAdapter; set => dataAdapter = value; }
        public SqlCommand Command { get => command; set => command = value; }

        public DLMain()
        {
            Connection = new SqlConnection(ConnectionString);
            Command = Connection.CreateCommand();
        }

        public DataSet executeQueryDataSet(string sqlString, CommandType type)
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
            Connection.Open();

            Command.CommandText = sqlString;
            Command.CommandType = type;

            DataAdapter = new SqlDataAdapter(Command);
            DataSet dataSet = new DataSet();
            DataAdapter.Fill(dataSet);

            return dataSet;
        }

        public bool myExecuteNonQuery(string sqlString, CommandType type)
        {
            bool canExecute;

            if (Connection.State == ConnectionState.Open)
                Connection.Close();
            Connection.Open();

            Command.CommandText = sqlString;
            Command.CommandType = type;

            try
            {
                Command.ExecuteNonQuery();
                canExecute = true;
            }
            catch
            {
                canExecute = false;
            }
            finally
            {
                Connection.Close();
            }

            return canExecute;
        }

        public bool myExecuteScalar(string sqlString, CommandType type, out int n)
        {
            bool canExecute;

            if (Connection.State == ConnectionState.Open)
                Connection.Close();
            Connection.Open();

            Command.CommandText = sqlString;
            Command.CommandType = type;

            try
            {
                n = Int32.Parse(Command.ExecuteScalar().ToString());
                canExecute = true;
            }
            catch
            {
                n = -1;
                canExecute = false;
            }
            finally
            {
                Connection.Close();
            }

            return canExecute;
        }

        public bool myOtherExecuteScalar(string sqlString, CommandType type, out string name)
        {
            bool canExecute;

            if (Connection.State == ConnectionState.Open)
                Connection.Close();
            Connection.Open();

            Command.CommandText = sqlString;
            Command.CommandType = type;

            try
            {
                name = Command.ExecuteScalar().ToString();
                canExecute = true;
            }
            catch
            {
                name = "";
                canExecute = false;
            }
            finally
            {
                Connection.Close();
            }

            return canExecute;
        }
    }
}
