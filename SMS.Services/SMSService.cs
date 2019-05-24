using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;
using SMS.TransferObjects;
using SMS.Service.Interface;
using SMS.BusinessLogic;

namespace SMS.Services
{

    public class SMSService : ISMSService
    {
        public ActionResultTO SaveStudent( string studentName, string studentSurname, string studentSex, int studentAge)
        {
            ActionResultTO result = new ActionResultTO();
            result = StudentDetails.SaveStudent(studentName, studentSurname, studentSex, studentAge);
            return result;


        }

        public List<StudentTransferObject> StudentList()
        {
            return StudentDetails.GetStudentList();
        }

        public List<StudentTransferObject> GetStudentsByMarks()
        {
            return StudentDetails.GetStudentsByMarks();
        }
        public List<StudentTransferObject> GetMoreThan5SubjectStudents()
        {
            return StudentDetails.GetMoreThan5SubjectStudents();
        }

    }
}
