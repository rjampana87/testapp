using System.Data;

namespace ClassLibrary1
{
    public class Class1
    {

        public List<sqlStudents> getStudent()
        {
            //string conns = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Student;Integrated Security=SSPI;MultipleActiveResultSets=False;";
            string conns = @"Data Source=LAPTOP-P0DCV5AH;Initial Catalog=Student;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;";

            List<sqlStudents> students = new List<sqlStudents>();
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
                        students.Add(new sqlStudents
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