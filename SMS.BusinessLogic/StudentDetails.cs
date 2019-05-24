using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.BusinesLogicModel;
using SMS.TransferObjects;

namespace SMS.BusinessLogic
{
    public class StudentDetails
    {
        public static ActionResultTO SaveStudent(string studentName, string studentSurname, string studentSex, int studentAge)
        {
            Student student = new Student(studentName, studentSurname, studentSex, studentAge);
            ActionResult result = new ActionResult();
            result = student.SaveStudent(studentName, studentSurname, studentSex, studentAge);
            ActionResultTO resultTo = result.ToActionResultTo();
            return resultTo;
        }

        public static List<StudentTransferObject> GetStudentList()
        {
            Student student = new Student();
            List<Student> result = student.GetStudents();
            List<StudentTransferObject> studentTo = null;
            studentTo = ToMapping.ToActionResultTo(result);

            return studentTo;
        }

        public static List<StudentTransferObject> GetStudentsByMarks()
        {
            Student student = new Student();
            List<Student> result = student.GetStudentsByMarks();
            List<StudentTransferObject> studentTo = null;
            studentTo = ToMapping.ToActionResultTo(result);

            return studentTo;
        }

        public static List<StudentTransferObject> GetMoreThan5SubjectStudents()
        {
            Student student = new Student();
            List<Student> result = student.GetMoreThan5SubjectStudents();
            List<StudentTransferObject> studentTo = null;
            studentTo = ToMapping.ToActionResultTo(result);

            return studentTo;
        }

    }
}

