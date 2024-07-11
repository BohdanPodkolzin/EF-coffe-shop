using EntityFrameworkCoffeeShop.Models;

namespace EntityFrameworkCoffeeShop.Controllers
{
    public class CategoryController
    {
        public static void AddCategory(Category category)
        {
            using var dataBase = new ProductsContext();
            dataBase.Add(category);
            dataBase.SaveChanges();
        }
    }
}
