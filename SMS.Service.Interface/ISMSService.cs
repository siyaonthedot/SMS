using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;
using SMS.TransferObjects;

namespace SMS.Service.Interface
{
    [ServiceContract]
    public interface ISMSService
    {
        [OperationContract]
        ActionResultTO SaveStudent(string studentName, string studentSurname, string studentSex, int studentAge);
        [OperationContract]
        List<StudentTransferObject> StudentList();
        [OperationContract]
        List<StudentTransferObject> GetStudentsByMarks();
        [OperationContract]
        List<StudentTransferObject> GetMoreThan5SubjectStudents();
    }
}
