using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.TransferObjects;
using SMS.BusinesLogicModel;


namespace SMS.BusinessLogic
{
    public  static class ToMapping
    {

        public static ActionResultTO ToActionResultTo(this ActionResult result)
        {
            ActionResultTO actionResultTO = new ActionResultTO();
            actionResultTO.Success = result.Success;
            actionResultTO.Message = result.Message;

            return actionResultTO;

        }
        public static List<StudentTransferObject> ToActionResultTo(this List<Student> result)
        {
            List<StudentTransferObject> to = new List<StudentTransferObject>();
            foreach (var student in result)
            {
                StudentTransferObject studentTransferObject = new StudentTransferObject();
                studentTransferObject = student.ToStudentTo();

                to.Add(studentTransferObject);

            }
            return to;
        }


        public static StudentTransferObject ToStudentTo(this Student student)
        {
            if (student == null)
            {
                student = new Student();
            }
            StudentTransferObject to = new StudentTransferObject();
            to.StudentID = student.StudentID;
            to.StudentName = student.StudentName;
            to.StudentSurname = student.StudentSurname;
            to.StudentSex = student.StudentSex;
            to.StudentAge = student.StudentAge;
            to.Mark = student.Mark;
            to.Subject = student.Subject;
            to.MarkAvg = student.MarkAvg;
            to.SubjectTotal = student.SubjectTotal;
            //to.Subject = student.Subject;

            return to;
        }
       
    }
}
