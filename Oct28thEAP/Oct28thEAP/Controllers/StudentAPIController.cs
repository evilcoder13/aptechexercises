using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Oct28thEAP.Models;
using System.Data.Entity;
namespace Oct28thEAP.Controllers
{
    public class StudentAPIController : ApiController
    {
        SchoolContext context = new SchoolContext();

        public List<Student> Get()
        {
            return context.Students.ToList();
        }

        public List<Student> Get(string id)
        {
            return context.Exams.Include(e => e.Std).Include(e => e.Cls).Where(e => e.Std.Name.Contains(id) || e.Cls.Name.Contains(id)).Select(e => e.Std).Distinct().ToList();
            //return context.Students.Where(s=>s.Name.Contains(id)).ToList();
        }

        public void Post(Student std)
        {
            context.Students.Add(std);
            context.SaveChanges();
        }
    }
}
