using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwinProductService
{
    public class ProductsController:ApiController
    {
        ProductDBContext db = new ProductDBContext();
        public List<Product> Get()
        {
            return db.Products.ToList();
        }
        public Product Get(int id)
        {
            return db.Products.Where(p => p.Id == id).SingleOrDefault();
        }

        public Product Post(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            return p;
        }

        public void Put(int id, Product pr)
        {
            Product p1 = db.Products.Where(p => p.Id == id).SingleOrDefault();
            p1.Name = pr.Name;
            p1.Price = pr.Price;
            p1.Category = pr.Category;
            db.Entry(p1).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Products.Remove(Get(id));
            db.SaveChanges();
        }
    }
}
