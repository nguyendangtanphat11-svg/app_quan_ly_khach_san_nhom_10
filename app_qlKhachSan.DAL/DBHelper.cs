using System;
using System.Data;
using System.Data.SqlClient;

namespace app_qlKhachSan.DAL
{
    public class DBHelper
    {
        private static string connectionString =
                @"Data Source=LAPTOP-B6BVDVFI\MSSQLSERVER16;Initial Catalog=HotelManager;Integrated Security=True";

        public static DataTable ExecuteQuery(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataTable table = new DataTable();

                adapter.Fill(table);

                return table;
            }
        }

        public static bool Execute(string sql, params object[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);

                for (int i = 0; i < parameters.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@p" + i, parameters[i]);
                }

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}