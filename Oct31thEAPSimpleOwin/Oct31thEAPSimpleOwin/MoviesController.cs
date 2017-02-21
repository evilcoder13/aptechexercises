using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Oct31thEAPSimpleOwin
{
    public class MoviesController:ApiController
    {
        MovieStoreDBEntities db = new MovieStoreDBEntities();
        public List<Movie> Get()
        {
            return db.Movies.ToList();
        }

        public List<Movie> Get(string id)
        {
            return db.Movies.Where(m=>m.Title.Contains(id)).ToList();
        }
    }
}
