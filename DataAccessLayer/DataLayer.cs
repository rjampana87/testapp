using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataLayer
    {
        public List<SqlStudent> getStudent()
        {
            //string conns = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Student;Integrated Security=SSPI;MultipleActiveResultSets=False;";
            string conns = @"Data Source=LAPTOP-P0DCV5AH;Initial Catalog=Student;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;";

            List<SqlStudent> students = new List<SqlStudent>();
            using (SqlConnection conn = new SqlConnection(conns))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetStudentList", conn);
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        students.Add(new SqlStudent
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1)
                        });
                    }
                }
            }
            return students;
        }


    }
}
