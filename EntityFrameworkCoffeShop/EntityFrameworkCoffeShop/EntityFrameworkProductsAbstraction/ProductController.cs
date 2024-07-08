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
        var name = AnsiConsole.Ask<string>("Specify the product`s name: ");
        using var dataBase = new ProductsContext();
        dataBase.Add(new Product { Name = name });
        dataBase.SaveChanges();

    }

    public static void RemoveProduct()
    {
        throw new NotImplementedException();
    }

    public static void UpdateProduct()
    {
        throw new NotImplementedException();
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
