using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace OwinProductService
{
    public class ProductDBContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductDBContext():base()
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer(new ProductDbInitilizer());
        }
    }
}
