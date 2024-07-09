using System;
using System.Linq.Expressions;
using EntityFrameworkCoffeeShop;
using EntityFrameworkCoffeeShop.CoffeeShopMenu;
using EntityFrameworkCoffeeShop.EntityFrameworkProductsAbstraction;
using Spectre.Console;

namespace EntityFrameworkCoffeShop;

public class Program
{
    
    
    public static void Main()
    {
        const bool appRunning = true;

        while (appRunning)
        {
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptionsEnum>()
                    .Title("Choose the command (1-6)")
                    .AddChoices(
                        MenuOptionsEnum.AddProduct,
                        MenuOptionsEnum.RemoveProduct,
                        MenuOptionsEnum.UpdateProduct,
                        MenuOptionsEnum.ShowProduct,
                        MenuOptionsEnum.ShowAllProducts,
                        MenuOptionsEnum.Exit));

            switch (option)
            {
                case MenuOptionsEnum.AddProduct:
                {
                    var name = AnsiConsole.Ask<string>("Specify the product`s name to add it: ");
                    ProductService.AddProductService(name);
                    Console.Clear();
                    break;
                }
                case MenuOptionsEnum.RemoveProduct:
                {
                    ProductService.RemoveProductService();
                    break;
                }
                case MenuOptionsEnum.UpdateProduct:
                {
                    var name = AnsiConsole.Ask<string>("Specify the new product`s name: ");
                    ProductService.UpdateProductService(name);
                    Console.Clear();
                    break;
                }
                case MenuOptionsEnum.ShowProduct:
                {
                    ProductController.ShowProduct();
                    break;
                }
                case MenuOptionsEnum.ShowAllProducts:
                {
                    ProductController.ShowAllProducts();
                    break;
                }
                case MenuOptionsEnum.Exit:
                {
                    Console.WriteLine("Exiting the app...");
                    Environment.Exit(0);
                    break;
                }
                default:
                {
                    Console.WriteLine("Invalid choice !");
                    break;
                }
            }
        }
    }
}