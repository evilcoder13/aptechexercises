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
    public class ExamAPIController : ApiController
    {
        SchoolContext context = new SchoolContext();
        public List<Exam> Get()
        {
            return context.Exams.Include(e => e.Cls).Include(e => e.Std).ToList();
        }

        public List<Exam> Get(bool id)
        {
            if(id)
                return context.Exams.Include(e => e.Cls).Include(e => e.Std).Where(e=>e.Mark >= 40).ToList();
            else
                return context.Exams.Include(e => e.Cls).Include(e => e.Std).Where(e => e.Mark < 40).ToList();
        }
    }
}
