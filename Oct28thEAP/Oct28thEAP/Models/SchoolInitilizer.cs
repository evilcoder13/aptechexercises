using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Oct28thEAP.Models
{
    public class SchoolInitilizer:DropCreateDatabaseAlways<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            context.Students.AddRange(new List<Student>() {
                new Student(){ Id=1, Name="Thang", Email="Thang@mail.com", DOB=new DateTime(1986,10,10)},
                new Student(){ Id=2, Name="Thanh", Email="Thanh@mail.com", DOB=new DateTime(1987,10,10)},
                new Student(){ Id=3, Name="Huy", Email="Huy@mail.com", DOB=new DateTime(1988,10,10)},
                new Student(){ Id=4, Name="Hai", Email="Hai@mail.com", DOB=new DateTime(1989,10,10)},
                new Student(){ Id=5, Name="Hanh", Email="Hanh@mail.com", DOB=new DateTime(1985,10,10)}
            });

            context.Classes.AddRange(new List<Class>() { 
                new Class() { Id=1, Name="C#"},
                new Class() { Id=2, Name="VB"},
                new Class() { Id=3, Name="MVC"},
                new Class() { Id=4, Name="EAP"},
                new Class() { Id=5, Name="WSAD"}
            });

            context.Exams.AddRange(new List<Exam>() { 
                new Exam() { ClassId=1, StudentId=1, Mark=90},
                new Exam() { ClassId=1, StudentId=2, Mark=80},
                new Exam() { ClassId=1, StudentId=3, Mark=70},
                new Exam() { ClassId=1, StudentId=4, Mark=60},
                new Exam() { ClassId=1, StudentId=5, Mark=50},
                new Exam() { ClassId=2, StudentId=5, Mark=40},
                new Exam() { ClassId=2, StudentId=4, Mark=30},
                new Exam() { ClassId=2, StudentId=3, Mark=20},
                new Exam() { ClassId=2, StudentId=2, Mark=10},
                new Exam() { ClassId=2, StudentId=1, Mark=20},
                new Exam() { ClassId=3, StudentId=1, Mark=30},
                new Exam() { ClassId=3, StudentId=2, Mark=40},
                new Exam() { ClassId=3, StudentId=3, Mark=50},
                new Exam() { ClassId=3, StudentId=4, Mark=60},
                new Exam() { ClassId=3, StudentId=5, Mark=70},
                new Exam() { ClassId=4, StudentId=5, Mark=80},
                new Exam() { ClassId=4, StudentId=4, Mark=90},
                new Exam() { ClassId=4, StudentId=3, Mark=80},
                new Exam() { ClassId=4, StudentId=2, Mark=70},
                new Exam() { ClassId=4, StudentId=1, Mark=60}
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}