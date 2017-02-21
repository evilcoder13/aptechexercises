using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sep12MovieManagement.Models;
using System.Data.Entity;
using System.Data;
namespace Sep12MovieManagement.Controllers
{
    public class MovieController : ApiController
    {
        MovieManagementEntities context = new MovieManagementEntities();
        public List<Movie> Get()
        {
            return context.Movies.ToList();
        }

        public List<Movie> Get(string id)
        {
            return context.Movies.Where(m => m.Title.Contains(id)).ToList();
        }
        public void Post(Movie m)
        {
            context.Movies.Add(m);
            context.SaveChanges();
        }

        public void Put(int id, Movie m)
        {
            m.MovieId = id;
            context.Entry(m).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Movies.Remove(context.Movies.Where(m => m.MovieId == id).SingleOrDefault());
        }
    }
}
