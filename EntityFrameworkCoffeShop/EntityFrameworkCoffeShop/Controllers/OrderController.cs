using System.Runtime.InteropServices.Marshalling;
using EntityFrameworkCoffeeShop.Models;

namespace EntityFrameworkCoffeeShop.Controllers;

public class OrderController
{
    public static void AddOrder(List<OrderProduct> orders)
    {
        using var dataBase = new ProductsContext();
        dataBase.OrderProducts.AddRange(orders);
        dataBase.SaveChanges();
    }
}
