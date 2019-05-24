using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class StudentModel
    {

        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentSex { get; set; }
        public int StudentAge { get; set; }
        public string Mark { get; set; }
        public string Subject { get; set; }
        public decimal MarkAvg { get; set; }
        public int SubjectTotal { get; set; }
    }
}