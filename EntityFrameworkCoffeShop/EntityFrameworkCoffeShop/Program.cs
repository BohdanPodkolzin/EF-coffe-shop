using EntityFrameworkCoffeeShop.CoffeeShopUI;
using EntityFrameworkCoffeeShop.Contexts;

namespace EntityFrameworkCoffeeShop;

public class Program
{
    public static void Main()
    {
        var context = new ProductsContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();


        UserInterface.MainMenu();
    }
}