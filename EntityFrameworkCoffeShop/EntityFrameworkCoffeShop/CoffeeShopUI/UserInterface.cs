using System.Globalization;
using EntityFrameworkCoffeeShop.Models;
using EntityFrameworkCoffeeShop.Services;
using Spectre.Console;

namespace EntityFrameworkCoffeeShop.CoffeeShopUI;

public static class UserInterface
{

    public static void MainMenu()
    {
        const bool appRunning = true;

        while (appRunning)
        {
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MainMenuOptionsEnum>()
                    .Title("Choose the command (1-6)")
                    .AddChoices(
                        MainMenuOptionsEnum.ManageCategories,
                        MainMenuOptionsEnum.ManageProducts,
                        MainMenuOptionsEnum.ManageOrders,
                        MainMenuOptionsEnum.Quit
                    ));

            switch (option)
            {
                case MainMenuOptionsEnum.ManageCategories:
                    {
                        CategoriesMenu();
                        break;
                    }
                case MainMenuOptionsEnum.ManageProducts:
                    {
                        ProductsMenu();
                        break;
                    }
                case MainMenuOptionsEnum.ManageOrders:
                    {
                        OrdersMenu();
                        break;
                    }
                case MainMenuOptionsEnum.Quit:
                    
                        Console.WriteLine("Exiting the app...");
                        Environment.Exit(0);
                        break;
            }
        }
    }

    private static void CategoriesMenu()
    {
        var isCategoriesMenuRunning = true;
        while (isCategoriesMenuRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<CategoryOptionsEnum>()
                    .Title("Categories Menu")
                    .AddChoices(
                        CategoryOptionsEnum.AddCategory,
                        CategoryOptionsEnum.RemoveCategory,
                        CategoryOptionsEnum.UpdateCategory,
                        CategoryOptionsEnum.ShowAllCategories,
                        CategoryOptionsEnum.ShowCategoryProducts,
                        CategoryOptionsEnum.GoBack
                    ));

            switch (option)
            {
                case CategoryOptionsEnum.AddCategory:
                    {
                        CategoryService.AddCategoryService();
                        break;
                    }
                case CategoryOptionsEnum.RemoveCategory:
                    {
                        CategoryService.RemoveCategoryService();
                        break;
                    }
                case CategoryOptionsEnum.UpdateCategory:
                    {
                        CategoryService.UpdateCategoryService();
                        break;
                    }
                case CategoryOptionsEnum.ShowAllCategories:
                    {
                        CategoryService.ShowAllCategories();
                        break;
                    }
                case CategoryOptionsEnum.ShowCategoryProducts:
                    {
                        CategoryService.ShowCategoryProductsService();
                        break;
                    }
                case CategoryOptionsEnum.GoBack:
                    {
                        isCategoriesMenuRunning = false;
                        break;
                    }
            }
        }
    }

    private static void ProductsMenu()
    {
        var isProductsMenuRunning = true;
        while (isProductsMenuRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<ProductOptionsEnum>()
                    .Title("Products Menu")
                    .AddChoices(
                        ProductOptionsEnum.AddProduct,
                        ProductOptionsEnum.RemoveProduct,
                        ProductOptionsEnum.UpdateProduct,
                        ProductOptionsEnum.ShowProduct,
                        ProductOptionsEnum.ShowAllProducts,
                        ProductOptionsEnum.GoBack
                    ));

            switch (option)
            {
                case ProductOptionsEnum.AddProduct:
                {
                    ProductService.AddProductService();
                    break;
                }
                case ProductOptionsEnum.RemoveProduct:
                {
                    ProductService.RemoveProductService();
                    break;
                }
                case ProductOptionsEnum.UpdateProduct:
                {
                    ProductService.UpdateProductService();
                    break;
                }
                case ProductOptionsEnum.ShowProduct:
                {
                    ProductService.ShowProduct();
                    break;
                }
                case ProductOptionsEnum.ShowAllProducts:
                {
                    ProductService.ShowAllProducts();
                    break;
                }
                case ProductOptionsEnum.GoBack:
                {
                    isProductsMenuRunning = false;
                    break;
                }
            }
        }
    }

    private static void OrdersMenu()
    {
        var isOrdersMenuRunning = true;
        while (isOrdersMenuRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<OrderOptionsEnum>()
                    .Title("Products Menu")
                    .AddChoices(
                        OrderOptionsEnum.AddOrder,
                        OrderOptionsEnum.ShowOrder,
                        OrderOptionsEnum.GoBack
                    ));

            switch (option)
            {
                case OrderOptionsEnum.AddOrder:
                {
                    OrderService.AddOrderService();
                    break;
                }
                case OrderOptionsEnum.ShowOrder:
                {
                    OrderService.ShowOrderService();
                    break;
                }
                case OrderOptionsEnum.GoBack:
                {
                    isOrdersMenuRunning = false;
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
        table.AddColumn("Category");

        foreach (var product in products)
        {
            
            table.AddRow(
                product.ProductId.ToString(),
                product.Name,
                product.Price.ToString(CultureInfo.CurrentCulture),
                product.Category!.Name
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();
    }

    public static void ShowProductDetails(Product product)
    {
        var panel = new Panel($"""
                                Id: {product.ProductId} 
                                Name: {product.Name}
                                Price: {product.Price}
                                Category: {product.Category!.Name}
                                """)
        {
            Header = new PanelHeader("Product details"),
            Padding = new Padding(2, 2, 2, 2),
        };

        AnsiConsole.Write(panel);

        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();
    }

    public static void ShowCategoriesTable(List<Category> categories)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");

        foreach (var category in categories)
        {
            table.AddRow(
                category.CategoryId.ToString(),
                category.Name
            );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();
    }

    public static void ShowCategoryProducts(Category category)
    {
        var panel = new Panel($"""
                                Id: {category.CategoryId} 
                                Name: {category.Name}
                                Product count: {category.Products?.Count}
                                """)
        {
            Header = new PanelHeader($"{category.Name}"),
            Padding = new Padding(2, 2, 2, 2),
        };

        AnsiConsole.Write(panel);
        ShowProductsTable(category.Products!);
    }

    public static void ShowOrderTable(List<Order> orders)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Date");
        table.AddColumn("Count");
        table.AddColumn("Total Price");

        foreach (var order in orders)
        {

            table.AddRow(
                order.OrderId.ToString(),
                order.CreatedDate.ToString(CultureInfo.CurrentCulture),
                order.OrderProducts?
                    .Sum(x => x.Quantity).ToString() ?? string.Empty,
                order.TotalPrice.ToString(CultureInfo.CurrentCulture)
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to Return to Menu");
        Console.ReadLine();
    }
}

