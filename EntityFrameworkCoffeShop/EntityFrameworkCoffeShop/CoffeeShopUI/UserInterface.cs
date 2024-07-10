using EntityFrameworkCoffeeShop.Models;
using EntityFrameworkCoffeeShop.Services;
using Spectre.Console;

namespace EntityFrameworkCoffeeShop.CoffeeShopMenu;

public static class UserInterface
{

    public static void MainMenu()
    {
        const bool appRunning = true;

        while (appRunning)
        {
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptionsEnum>()
                    .Title("Choose the command (1-6)")
                    .AddChoices(
                        MenuOptionsEnum.AddProduct,
                        MenuOptionsEnum.AddCategory,
                        MenuOptionsEnum.RemoveProduct,
                        MenuOptionsEnum.UpdateProduct,
                        MenuOptionsEnum.ShowProduct,
                        MenuOptionsEnum.ShowAllProducts,
                        MenuOptionsEnum.Exit));

            switch (option)
            {
                case MenuOptionsEnum.AddProduct:
                    {
                        ProductService.AddProductService();
                        break;
                    }
                case MenuOptionsEnum.AddCategory:
                    {
                        CategoryService.AddCategoryService();
                        break;
                    }
                case MenuOptionsEnum.RemoveProduct:
                    {
                        ProductService.RemoveProductService();
                        break;
                    }
                case MenuOptionsEnum.UpdateProduct:
                    {
                        ProductService.UpdateProductService();
                        break;
                    }
                case MenuOptionsEnum.ShowProduct:
                    {
                        ProductService.ShowProduct();
                        break;
                    }
                case MenuOptionsEnum.ShowAllProducts:
                    {
                        ProductService.ShowAllProducts();
                        break;
                    }
                case MenuOptionsEnum.Exit:
                    {
                        Console.WriteLine("Exiting the app...");
                        Environment.Exit(0);
                        break;
                    }
            }
        }
    }

    public static void ShowProductsTable(List<Product> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Price");

        foreach (var product in products)
        {
            if (product.Name == null) return;
            table.AddRow(
                product.ProductId.ToString(),
                product.Name,
                product.Price.ToString()
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();
        Console.Clear();
    }

    public static void ShowProductDetails(Product product)
    {
        var panel = new Panel($"""
                                Id: {product.ProductId} 
                                Name: {product.Name}
                                Price: {product.Price}
                                """)
        {
            Header = new PanelHeader("Product details"),
            Padding = new Padding(2, 2, 2, 2),
        };

        AnsiConsole.Write(panel);

        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();
        Console.Clear();
    }
}

