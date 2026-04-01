using System;
using System.Data;
using System.Data.SqlClient;

namespace app_qlKhachSan.DAL
{
    internal class Database
    {
        private string connectionString = @"Data Source=LAPTOP-URQTM56V\SQLEXPRESS;Initial Catalog=HotelManager;Integrated Security=True";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public DataTable ExecuteQuery(string query)
        {
            SqlConnection conn = GetConnection();
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            conn.Close();
            return dt;
        }

        public int ExecuteNonQuery(string query)
        {
            SqlConnection conn = GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            int result = cmd.ExecuteNonQuery();

            conn.Close();
            return result;
        }
    }
}