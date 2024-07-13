using EntityFrameworkCoffeeShop.CoffeeShopUI;
using EntityFrameworkCoffeeShop.Controllers;
using EntityFrameworkCoffeeShop.Models;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace EntityFrameworkCoffeeShop.Services;

public class ProductService
{
    public static void AddProductService()
    {
        var product = new Product()
        {
            Name = AnsiConsole.Ask<string>("Specify the product`s name: "),
            Price = AnsiConsole.Ask<decimal>("Specify the product`s price: "),
            CategoryId = CategoryService.GetCategoriesOptionInput().CategoryId
        };
        ProductController.AddProduct(product);
        Console.Clear();
    }

    public static void RemoveProductService()
        => ProductController.RemoveProduct(GetProductOptionInput());

    public static void UpdateProductService()
    {
        var product = GetProductOptionInput();

        product.Name = AnsiConsole.Confirm("Update name?")
            ? AnsiConsole.Ask<string>("Specify the new product`s name: ")
            : product.Name;

        product.Price = AnsiConsole.Confirm("Update price?")
            ? AnsiConsole.Ask<decimal>("Specify the new product`s price: ")
            : product.Price;

        product.Category = AnsiConsole.Confirm("Update category?")
            ? CategoryService.GetCategoriesOptionInput()
            : product.Category;

        ProductController.UpdateProduct(product);
    }

    public static void ShowProduct()
        => UserInterface.ShowProductDetails(GetProductOptionInput());

    public static void ShowAllProducts()
        => UserInterface.ShowProductsTable(GetAllProducts());

    public static Product GetProductById(int id)
        => new ProductsContext().Products.Include(x => x.Category).SingleOrDefault(x => x.ProductId == id)!;

    private static List<Product> GetAllProducts()
        => new ProductsContext().Products.Include(x => x.Category).ToList();

    public static Product GetProductOptionInput()
    {
        var products = GetAllProducts();
        var productsNameArray = products.Select(x => x.Name).ToArray();

        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose product")!
            .AddChoices(productsNameArray));


        var id = products.Single(x => x.Name == option).ProductId;
        var product = GetProductById(id);

        return product;
    }
}

