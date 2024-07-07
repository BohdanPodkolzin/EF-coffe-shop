using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoffeeShop
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        
    }
}
