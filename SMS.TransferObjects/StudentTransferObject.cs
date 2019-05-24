using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using System.Threading.Tasks;

namespace SMS.TransferObjects
{
    public class StudentTransferObject
    {
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string StudentSurname { get; set; }
        [DataMember]
        public string StudentSex { get; set; }
        [DataMember]
        public int StudentAge { get; set; }
        [DataMember]
        public string Mark { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public decimal MarkAvg { get; set; }
        [DataMember]
        public int SubjectTotal { get; set; }


    }
}
