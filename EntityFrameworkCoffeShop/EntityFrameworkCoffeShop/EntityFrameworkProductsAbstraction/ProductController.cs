namespace EntityFrameworkCoffeeShop.EntityFrameworkProductsAbstraction;

public class ProductController
{
    public static void AddProduct(string name)
    {
        using var dataBase = new ProductsContext();
        dataBase.Add(new Product { Name = name });
        dataBase.SaveChanges();
    }

    public static void RemoveProduct()
    {
        var product = ProductService.GetProductOptionInput();

        using var dataBase = new ProductsContext();
        dataBase.Remove(product);
        dataBase.SaveChanges();
    }

    public static void UpdateProduct(string name)
    {
        var product = ProductService.GetProductOptionInput();
        
        using var dataBase = new ProductsContext();
        product.Name = name;
        dataBase.Update(product);
        dataBase.SaveChanges();
    }

    public static void ShowProduct()
        => UserInterface.ShowProductDetails(ProductService.GetProductOptionInput());

    public static void ShowAllProducts() 
        => UserInterface.ShowProductsTable(GetAllProducts());

    public static List<Product> GetAllProducts() 
        => new ProductsContext().Products.ToList();
}
