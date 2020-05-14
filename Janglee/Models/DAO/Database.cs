using Janglee.Models.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Janglee.Models.DAO
{
    public class Database
    {

        SqlConnection connect = new SqlConnection("Server=tcp:janglee.database.windows.net,1433;Initial Catalog=Janglee;Persist Security Info=False;User ID=votantai4899;Password=Tai01639505022;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        public int CheckLogin(User user)
        {
            SqlCommand command = new SqlCommand("CheckLogin", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", user.Username);
            command.Parameters.AddWithValue("@password", user.Password);
            SqlParameter login = new SqlParameter();
            login.ParameterName = "@isvalid";
            login.SqlDbType = SqlDbType.Bit;
            login.Direction = ParameterDirection.Output;
            command.Parameters.Add(login);
            connect.Open();
            command.ExecuteNonQuery();
            int res = Convert.ToInt32(login.Value);
            connect.Close();
            return res;
        }

        public int Register(User user)
        {
            SqlCommand command = new SqlCommand("Register", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", user.Username);
            command.Parameters.AddWithValue("@fullname", user.Fullname);
            command.Parameters.AddWithValue("@password", user.Password);
            connect.Open();
            try
            {
                int status = command.ExecuteNonQuery();
                return status;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                connect.Close();
            }
        }
    }
}
