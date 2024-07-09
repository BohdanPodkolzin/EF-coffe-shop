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
        var name = AnsiConsole.Ask<string>("Specify the product`s name to remove it: ");
        var id = AnsiConsole.Ask<int>("Specify the product`s name to remove it: ");
        using var dataBase = new ProductsContext();
        dataBase.Remove(new Product { Id = id, Name = name });
        dataBase.SaveChanges();
    }

    public static void UpdateProduct()
    {
        var id = AnsiConsole.Ask<int>("Specify productId to update: ");
        var name = AnsiConsole.Ask<string>("Specify product to update: ");
        using var dataBase = new ProductsContext();
        dataBase.Update(new Product { Id = id, Name = name });
        dataBase.SaveChanges();
    }

    public static void ShowProduct()
    {
        throw new NotImplementedException();
    }

    public static void ShowAllProducts()
    {
        throw new NotImplementedException();
    }
}
