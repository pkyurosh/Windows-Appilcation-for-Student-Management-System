using SMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using SMS.Bll;
using SMS.Utils;

namespace SMS
{
    internal class StudentDao
    {
        private SqlConnection cn;
        public StudentDao()
        {
            cn = DbConnection.MyConnection();
        }

        public void SaveStudent(Student s)
        {
            string sql = "INSERT INTO Student(Name, Address, Course, Fee)VALUES (@Name, @Address, @Course, @Fee)";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Name", s.Name);
            cmd.Parameters.AddWithValue("@Address", s.Address);
            cmd.Parameters.AddWithValue("@Course", s.Course);
            cmd.Parameters.AddWithValue("@Fee", s.Fee);
            cmd.ExecuteNonQuery();
        }


        public void UpdateStudent(Student s)
        {
            string sql = "UPDATE Student Set Name=@Name, Address=@Address, Course=@Course, Fee=@Fee WHERE SID=@SID";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("SID", s.SID);
            cmd.Parameters.AddWithValue("@Name", s.Name);
            cmd.Parameters.AddWithValue("@Address", s.Address);
            cmd.Parameters.AddWithValue("@Course", s.Course);
            cmd.Parameters.AddWithValue("@Fee", s.Fee);
            cmd.ExecuteNonQuery();
        }


        public void DeleteStudent(int SID)
        {
            string sql = "DELETE FROM Student WHERE SID=@SID";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("SID", SID);
           
            cmd.ExecuteNonQuery();
        }
        public DataTable AllStudents()
        {
            string sql = "SELECT * FROM Student";
            SqlCommand cmd = new SqlCommand(sql, cn);
          
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}


