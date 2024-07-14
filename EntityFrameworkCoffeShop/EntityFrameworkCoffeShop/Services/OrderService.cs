using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCoffeeShop.CoffeeShopUI;
using EntityFrameworkCoffeeShop.Controllers;
using EntityFrameworkCoffeeShop.Migrations.DataTransferObjects;
using EntityFrameworkCoffeeShop.Models;
using Spectre.Console;

namespace EntityFrameworkCoffeeShop.Services;
public class OrderService
{
    public static void AddOrderService() 
        => OrderController.AddOrder(GetProductsFromOrder());

    public static void ShowOrderService()
        => UserInterface.ShowOrderTable(OrderController.GetOrderProducts());

    public static void ShowProductOrderService()
        => ShowOrderDetails(GetOrderOptionInput());

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
            var quantity = AnsiConsole.Ask<int>("How many: ");

            order.TotalPrice += product.Price * quantity;

            products.Add(
                new OrderProduct()
                {
                    Order = order,
                    ProductId = product.ProductId,
                    Quantity = quantity,

                });

            Console.WriteLine($"You`ve picked {product.Name} in the amount of {quantity}. Total price: {order.TotalPrice}");
            isOrderFinished = !AnsiConsole.Confirm("Would you like add one more product?");
        }

        return products;
    }

    private static void ShowOrderDetails(Order order)
    {
        var products = order.OrderProducts!
            .Select(x => new ProductOrderViewDto()
            {
                Id = x.ProductId,
                Name = x.Product?.Name,
                Category = x.Product?.Category?.Name,
                Quantity = x.Quantity,
                Price = x.Product!.Price,
                TotalPrice = x.Quantity * x.Product.Price
            })
            .ToList();

        UserInterface.ShowOrder(order);
        UserInterface.ShowProductOrderDetails(products);
    }

    private static Order GetOrderOptionInput()
    {
        var orders = OrderController.GetOrderProducts();
        var ordersNameArray = orders
            .Select(x => $"{x.OrderId}. {x.CreatedDate} – {x.TotalPrice}");
        
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Order")
            .AddChoices(ordersNameArray));
        
        var idArray = option.Split('.');
        var order = orders.Single(
                x => x.OrderId == int.Parse(idArray[0])
                );

        return order;
    }
}

