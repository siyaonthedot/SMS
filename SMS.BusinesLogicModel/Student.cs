using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace SMS.BusinesLogicModel
{
        public class Student { 
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentSex { get; set; }
        public int StudentAge { get; set; }
        public string Mark { get; set; }
        public decimal MarkAvg { get; set; }
        public int SubjectTotal { get; set; }
        public string Subject { get; set; }
        string Conn = "Data Source=DEV-SERVER2008\\DEVSERVER2014EXP;" + "Initial Catalog=SchoolApp;" + "User id=sa;" + "Password=Rrrybgdts9;";


        public Student(string studentName,string studentSurname, string studentSex, int studentAge)
        {
            StudentName = studentName;
            StudentSurname = studentSurname;
            StudentSex = studentSex;
            StudentAge = studentAge;
        }
        public Student() { }

        public ActionResult SaveStudent(string studentName, string studentSurname, string studentSex , int studentAge)
        {
            string methodName = "SaveStudent";
            ActionResult result = new ActionResult();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
                {
                    const string sql = "[dbo].[Save_Student]";

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    result = connection.Query<ActionResult>(sql, new
                    {
                        @StudentName = studentName,
                        @StudentSurname = StudentSurname,
                        @StudentSex = studentSex,
                        @StudentAge =studentAge
                    }, commandType: CommandType.StoredProcedure, commandTimeout: 120).FirstOrDefault();
                }
            }
            catch (Exception exception)
            {

            }
            return result;
        }



        public List<Student> GetStudents()
        {
            string methodName = "GetStudents";
            const string sql = @"[dbo].[GetStudents]";
            List<Student> students = null;
            try
            {
                using (var connection = new SqlConnection(Conn))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    students = connection.Query<Student>(sql, commandType: CommandType.StoredProcedure, commandTimeout: 120).ToList();
                }
            }
            catch (Exception exception)
            {
            }
            return students;
        }



        public List<Student> GetStudentsByMarks()
        {
            string methodName = "GetStudentsByMarks";
            const string sql = @"[dbo].[GetStudentsByMarks]";
            List<Student> students = null;
            try
            {
                using (var connection = new SqlConnection(Conn))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    students = connection.Query<Student>(sql, commandType: CommandType.StoredProcedure, commandTimeout: 120).ToList();
                }
            }
            catch (Exception exception)
            {
            }
            return students;
        }
    

    public List<Student> GetMoreThan5SubjectStudents()
    {
        string methodName = "GetMoreThan5SubjectStudents";
        const string sql = @"[dbo].[GetMoreThan5SubjectStudents]";
        List<Student> students = null;
        try
        {
            using (var connection = new SqlConnection(Conn))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                students = connection.Query<Student>(sql, commandType: CommandType.StoredProcedure, commandTimeout: 120).ToList();
            }
        }
        catch (Exception exception)
        {
        }
        return students;
    }
}
}
