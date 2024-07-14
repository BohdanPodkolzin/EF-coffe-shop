using System.Runtime.InteropServices.Marshalling;
using EntityFrameworkCoffeeShop.Contexts;
using EntityFrameworkCoffeeShop.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoffeeShop.Controllers;

public class OrderController
{
    public static void AddOrder(List<OrderProduct> orders)
    {
        using var dataBase = new ProductsContext();
        dataBase.OrderProducts.AddRange(orders);
        dataBase.SaveChanges();
    }

    public static List<Order> GetOrderProducts()
    { 
        using var dataBase = new ProductsContext();
        var ordersList = dataBase.Orders
            .Include(o => o.OrderProducts)!
            .ThenInclude(op => op.Product)
            .ThenInclude(p => p!.Category)
            .ToList();

        return ordersList;
    }
}
