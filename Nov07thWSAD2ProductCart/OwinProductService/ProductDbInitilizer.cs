using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace OwinProductService
{
    public class ProductDbInitilizer:DropCreateDatabaseIfModelChanges<ProductDBContext>
    {
        protected override void Seed(ProductDBContext context)
        {
            context.Products.AddRange(new List<Product>(){
                new Product(){ Id=1, Name="Giày da", Category="Giày", Price=500000},
                new Product(){ Id=2, Name="Giày thể thao", Category="Giày", Price=300000},
                new Product(){ Id=3, Name="Giày vải", Category="Giày", Price=50000},
                new Product(){ Id=4, Name="Dép tông", Category="Dép", Price=50000},
                new Product(){ Id=5, Name="Dép nhựa", Category="Dép", Price=70000},
                new Product(){ Id=6, Name="Dép cao su", Category="Dép", Price=80000}
            });
            base.Seed(context);
        }
    }
}
