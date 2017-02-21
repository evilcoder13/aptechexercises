using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Oct3rdExamManagement.Models
{
    public class SchoolDbInitilizer:DropCreateDatabaseAlways<SchoolDbContext>
    {
        protected override void Seed(SchoolDbContext context)
        {
            context.Students.Add(new Student() { StudentId = 1, Name = "Thang", DOB = new DateTime(1980, 10, 10), Email = "thangdm@d3plus.com", Phone = "0989993597" });
            context.Students.Add(new Student() { StudentId = 2, Name = "Duy", DOB = new DateTime(1981, 10, 10), Email = "Duy@d3plus.com", Phone = "0989993597" });
            context.Students.Add(new Student() { StudentId = 3, Name = "Thanh", DOB = new DateTime(1982, 10, 10), Email = "Thanh@d3plus.com", Phone = "0989993597" });
            context.Students.Add(new Student() { StudentId = 4, Name = "Trang", DOB = new DateTime(1983, 10, 10), Email = "Trang@d3plus.com", Phone = "0989993597" });
            context.Students.Add(new Student() { StudentId = 5, Name = "Huyen", DOB = new DateTime(1984, 10, 10), Email = "Huyen@d3plus.com", Phone = "0989993597" });
            context.Students.Add(new Student() { StudentId = 6, Name = "Hai", DOB = new DateTime(1985, 10, 10), Email = "Hai@d3plus.com", Phone = "0989993597" });

            context.Exams.AddRange(new List<Exam>()
            {
                new Exam() { ExamId=1, Subject="C#", Mark=85, StudentId=1 },
                new Exam() { ExamId=2, Subject="VB", Mark=35, StudentId=2 },
                new Exam() { ExamId=3, Subject="C#", Mark=45, StudentId=3 },
                new Exam() { ExamId=4, Subject="VB", Mark=55, StudentId=4 },
                new Exam() { ExamId=5, Subject="VB", Mark=65, StudentId=5 },
                new Exam() { ExamId=6, Subject="C#", Mark=75, StudentId=6 },
                new Exam() { ExamId=7, Subject="VB", Mark=25, StudentId=5 },
                new Exam() { ExamId=8, Subject="VB", Mark=15, StudentId=4 }
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}