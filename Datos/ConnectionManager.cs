using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Datos
{
    public class ConnectionManager
    {
        public SqlConnection connection;

        public ConnectionManager(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public void Open()
        {
            connection.Open();
        }

        public void Close()
        {
            connection.Close();
        }


    }
}