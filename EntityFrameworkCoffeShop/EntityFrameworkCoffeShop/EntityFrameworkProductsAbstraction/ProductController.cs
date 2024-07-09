using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace EntityFrameworkCoffeeShop.EntityFrameworkProductsAbstraction;

public class ProductController
{
    public static void AddProduct()
    {
        var name = AnsiConsole.Ask<string>("Specify the product`s name to add it: ");
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

    public static void UpdateProduct()
    {
        var product = ProductService.GetProductOptionInput();
        
        using var dataBase = new ProductsContext();
        var name = AnsiConsole.Ask<string>("Specify the new product`s name: ");
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
