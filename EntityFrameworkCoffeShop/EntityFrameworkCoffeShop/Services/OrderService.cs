using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCoffeeShop.Models;
using Spectre.Console;

namespace EntityFrameworkCoffeeShop.Services;
public class OrderService
{
    public static void AddOrder()
    {
        var products = GetProductsFromOrder();
    }

    private static List<OrderProduct> GetProductsFromOrder()
    {
        var products = new List<OrderProduct>();
        var order = new Order()
        {
            CreatedDate = DateTime.Now
        };
        
        var isOrderFinished = false;
        while (!isOrderFinished)
        {
            var product = ProductService.GetProductOptionInput();
            var quantity = AnsiConsole.Ask<int>("How many?");

            order.TotalPrice += product.Price * quantity;

            products.Add(
                new OrderProduct()
                {
                    Order = order,
                    ProductId = product.ProductId,
                    Quantity = quantity,

                });

            isOrderFinished = !AnsiConsole.Confirm("Would you like add one more product?");
        }

        return products;
    }
}

