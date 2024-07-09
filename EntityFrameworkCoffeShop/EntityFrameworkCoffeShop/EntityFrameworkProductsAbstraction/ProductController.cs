namespace EntityFrameworkCoffeeShop.EntityFrameworkProductsAbstraction;

public class ProductController
{
    public static void AddProduct(string name)
    {
        using var dataBase = new ProductsContext();
        dataBase.Add(new Product { Name = name });
        dataBase.SaveChanges();
    }

    public static void RemoveProduct(Product product)
    {
        using var dataBase = new ProductsContext();
        dataBase.Remove(product);
        dataBase.SaveChanges();
    }

    public static void UpdateProduct(Product product, string name)
    {
        using var dataBase = new ProductsContext();
        product.Name = name;
        dataBase.Update(product);
        dataBase.SaveChanges();
    }
}
