using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reciple.Module
{
    class Connection
    {
        public static string cn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DaTaDirectory|\QLMonAn.mdf;Integrated Security=True";
        DataTable dt;

        /// <summary>
        /// tạo kết nối với database
        /// </summary>
        /// <returns></returns>
        public static SqlConnection Get_Connection()
        {
            SqlConnection cn_connection = new SqlConnection(cn_string);
            if (cn_connection.State != ConnectionState.Open)
                cn_connection.Open();
            return cn_connection;
        }

        /// <summary>
        /// đóng kết nối với database
        /// </summary>
        public void Close_Connection()
        {
            SqlConnection cn_connection = new SqlConnection(cn_string);
            if (cn_connection.State != ConnectionState.Closed)
                cn_connection.Close();
        }

        /// <summary>
        /// lấy tất cả các dữ liệu trong table
        /// </summary>
        /// <param name="sql"> câu query truy vấn database</param>
        /// <returns></returns>
        public DataTable GetALL_Data(string sql)
        {
            SqlConnection cn_connection = Get_Connection();
            dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, cn_connection);
            adapter.Fill(dt);
            return dt;
        }

        /// <summary>
        /// update chỉnh sủa trong câu truy vấn
        /// </summary>
        /// <param name="sql"> câu query truy vấn vào database</param>
        public void Execute_SQL(string sql)
        {
            SqlConnection cn_connection = Get_Connection();
            SqlCommand cmd_Command = new SqlCommand(sql, cn_connection);
            cmd_Command.ExecuteNonQuery();

        }

    }
}
