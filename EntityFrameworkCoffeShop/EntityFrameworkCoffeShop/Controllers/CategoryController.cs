using EntityFrameworkCoffeeShop.Models;

namespace EntityFrameworkCoffeeShop.Controllers;

public class CategoryController
{
    public static void AddCategory(Category category)
    {
        using var dataBase = new ProductsContext();
        dataBase.Add(category);
        dataBase.SaveChanges();
    }

    public static void UpdateCategory(Category category)
    {
        using var dataBase = new ProductsContext();
        dataBase.Update(category);
        dataBase.SaveChanges();
    }

    public static void RemoveCategory(Category category)
    {
        using var dataBase = new ProductsContext();
        dataBase.Remove(category);
        dataBase.SaveChanges();
    }
}

