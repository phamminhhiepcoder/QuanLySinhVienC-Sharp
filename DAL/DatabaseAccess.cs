using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
namespace DAL
{
    public class SQLConnectionData
    {
        //Tạo chuỗi kết nối CSDL
        public static SqlConnection Connect()
        {
            string str = "Data Source=WIN-CE1ADPBK2DA\\SQLEXPRESS;Initial Catalog=QuanLySinhVien;Integrated Security=True";
            SqlConnection connection = new SqlConnection(str);
            return connection;
        }
    }
   
    public class DatabaseAccess
    {
        public static string checkLoginDTO(TaiKhoan taiKhoan)
        {
            string user = null;
            SqlConnection connection = SQLConnectionData.Connect();
            connection.Open();

            SqlCommand command = new SqlCommand("proc_login", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@user", taiKhoan.sTaiKhoan);
            command.Parameters.AddWithValue("@pass", taiKhoan.sMatKhau);

            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                while (reader.Read())
                {
                    user = reader.GetString(0);
                    return user;
                }
                reader.Close();
                connection.Close();
            }
            else
            {
                return "Tài khoản và mật khẩu không chính xác!";
            }
            return user;
        }

    }
}
