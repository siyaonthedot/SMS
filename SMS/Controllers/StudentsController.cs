using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models;
using SMS.Services.Broker;
using SMS.TransferObjects;
using System.Configuration;
using SMS.Service.Interface;
using PagedList.Mvc;
using PagedList;

namespace SMS.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index(int? page)
        {
            List<StudentModel> students = new List<StudentModel>();
            using (var broker = new StudentServiceBroke(ConfigurationManager.AppSettings["ServiceHost"], 67))
            {
                var results = broker.Proxy.GetStudentsByMarks();
                foreach (var std in results)
                {
                    StudentModel student = new StudentModel();
                    student.StudentID = std.StudentID;
                    student.StudentName = std.StudentName;
                    student.StudentSurname = std.StudentSurname;
                    student.StudentSex = std.StudentSex;
                    student.StudentAge = std.StudentAge;
                    student.Subject = std.Subject;
                    student.Mark = std.Mark;
                    students.Add(student);
                }

            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }

        // GET: Students
        public ActionResult StudentsMoreThan5Subject()
        {
            List<StudentModel> students = new List<StudentModel>();
            using (var broker = new StudentServiceBroke(ConfigurationManager.AppSettings["ServiceHost"], 67))
            {
                var results = broker.Proxy.GetMoreThan5SubjectStudents();                             
                foreach (var std in results)
                {
                    StudentModel student = new StudentModel();
                    student.StudentID = std.StudentID;
                    student.StudentName = std.StudentName;
                    student.StudentSurname = std.StudentSurname;
                    student.StudentSex = std.StudentSex;
                    student.StudentAge = std.StudentAge;
                    student.Subject = std.Subject;
                    student.Mark = std.Mark;
                    student.SubjectTotal = std.SubjectTotal;
                    student.MarkAvg = std.MarkAvg;
                    students.Add(student);
                }
            }
            return View(students);
        }


    }
}