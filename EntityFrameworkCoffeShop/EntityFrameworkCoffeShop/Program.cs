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
                    ProductService.AddProductService();
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
}