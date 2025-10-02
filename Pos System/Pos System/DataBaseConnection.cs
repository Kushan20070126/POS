using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos_System
{
    public class DataBaseConnection
    {
        private string _connectionString;

        public DataBaseConnection()
        {
            _connectionString = "Server=localhost;Database=POSSystemDB;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=true;";

        }
        
        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection( _connectionString );

        }

        //Read Data For SQLDB

        public DataTable ExaecuteQuary(string sql)
        {
            var connection = GetSqlConnection();

            connection.Open();

            SqlCommand cmd = new SqlCommand(sql,connection);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;

        }

        // ADD UPDATA DELETE Data For SQLDB
        public int ExecuteNonQuary(string sql)
        {
            var connection = GetSqlConnection();
            connection.Open();

            SqlCommand cmd = new SqlCommand(sql, connection);
            return cmd.ExecuteNonQuery();

        }



    }
}
