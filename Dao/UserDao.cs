using SMS.Bll;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Utils;

namespace SMS.Dao
{
    internal class UserDao
    {
        private SqlConnection cn;

        public UserDao()
        {
            cn = DbConnection.MyConnection();
        }

        public DataTable CheckUser(User u)
        {
            string sql = "SELECT * FROM USERS WHERE Username=@Username AND Password=@Password";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Username", u.Username);
            cmd.Parameters.AddWithValue("@Password", u.Password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
