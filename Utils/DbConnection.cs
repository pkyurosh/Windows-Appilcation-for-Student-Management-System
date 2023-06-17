using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.SqlClient;

namespace SMS.Utils
{
    internal class DbConnection
    {
        public static SqlConnection cn;

        public static SqlConnection MyConnection()
        {
            cn = new SqlConnection("Data Source=LAPTOP-SPR32F4L\\SQLEXPRESS; Initial Catalog = SMS; Integrated Security=True");
            cn.Open();
            return cn;
        }
    }
}
