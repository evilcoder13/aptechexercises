using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Oct26thEAP.Models;
using System.Web.Caching;
namespace Oct26thEAP.Controllers
{
    public class MoviesController : ApiController
    {
        MovieStoreEntities context = new MovieStoreEntities();
        public MoviesController()
        {
            if (System.Web.HttpRuntime.Cache.Get("movies")==null)
            System.Web.HttpRuntime.Cache.Add("movies", context.Movies.ToList(), null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromHours(2), CacheItemPriority.Normal, null);
        }
        //Phuong thuc GET mac dinh
        public List<Movie> Get()
        {
            return (List<Movie>)System.Web.HttpRuntime.Cache.Get("movies");
        }

        //public Movie Get(int id)
        //{
        //    return context.Movies.Where(m=>m.MovieId==id).SingleOrDefault();
        //}
        public List<Movie> Get(string id)
        {
            return ((List<Movie>)System.Web.HttpRuntime.Cache.Get("movies")).Where(m => m.Title.Contains(id)).ToList();
        }
    }
}
