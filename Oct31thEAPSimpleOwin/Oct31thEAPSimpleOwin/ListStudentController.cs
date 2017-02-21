using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Oct31thEAPSimpleOwin
{
    public class ListStudentController:ApiController
    {
        List<Student> list = new List<Student>()
        {
            new Student() { Id=1, Name="Thang", DOB=new DateTime(1986,10,10), Class="C#"},
            new Student() { Id=2, Name="Thanh", DOB=new DateTime(1987,10,10), Class="VB"},
            new Student() { Id=3, Name="Huy", DOB=new DateTime(1988,10,10), Class="MVC"},
            new Student() { Id=4, Name="Hai", DOB=new DateTime(1989,10,10), Class="EAP"},
            new Student() { Id=5, Name="Trang", DOB=new DateTime(1990,10,10), Class="WSAD"}
        };
        public List<Student> Get()
        {
            return list;
        }
        public Student Get(int id)
        {
            return list.Where(s => s.Id == id).SingleOrDefault();
        }
    }
}
