using System;
using System.Data;
using System.Data.SqlClient;

namespace DataBase
{
    public class DbLink
    {
        private IDbConnection _connection;

        public DbLink(IDbConnection connection)
        {
            _connection = connection;
        }

        public IDbConnection GetConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection;
        }

        public void Close()
        {
            if (_connection.State == ConnectionState.Open)
                _connection.Close();
            _connection.Dispose();
        }
    }

    public class Fabricate
    {
        public static IDbConnection CreateConnection(string connection, ConnectionType type)
        {
            if (type == ConnectionType.SqlConnection)
            {
                SqlConnection sqlConnection = new SqlConnection(connection);
                return sqlConnection;
            }

            return null;
        }
    }

    [Flags]
    public enum ConnectionType
    {
        Deafult = 1 << 0,
        SqlConnection = 1 << 1,
    }

}
