using System;
using System.Linq.Expressions;
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
                    ProductController.AddProduct();
                    break;
                case MenuOptionsEnum.RemoveProduct:
                    ProductController.RemoveProduct();
                    break;
                case MenuOptionsEnum.UpdateProduct:
                    ProductController.UpdateProduct();
                    break;
                case MenuOptionsEnum.ShowProduct:
                    ProductController.ShowProduct();
                    break;
                case MenuOptionsEnum.ShowAllProducts:
                    ProductController.ShowAllProducts();
                    break;
                case MenuOptionsEnum.Exit:
                    Console.WriteLine("Exiting the app...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice !");
                    break;
            }
        }
    }
}