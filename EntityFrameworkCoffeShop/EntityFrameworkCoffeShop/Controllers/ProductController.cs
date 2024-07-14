using EntityFrameworkCoffeeShop.Models;

namespace EntityFrameworkCoffeeShop.Controllers;

public class ProductController
{
    public static void AddProduct(Product product)
    {
        using var dataBase = new ProductsContext();
        dataBase.Add(product);
        dataBase.SaveChanges();
    }

    public static void UpdateProduct(Product product)
    {
        using var dataBase = new ProductsContext();
        dataBase.Update(product);
        dataBase.SaveChanges();
    }

    public static void RemoveProduct(Product product)
    {
        using var dataBase = new ProductsContext();
        dataBase.Remove(product);
        dataBase.SaveChanges();
    }
}
