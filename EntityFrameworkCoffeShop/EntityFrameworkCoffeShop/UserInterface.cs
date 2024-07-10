using EntityFrameworkCoffeeShop.EntityFrameworkProductsAbstraction;
using Spectre.Console;

namespace EntityFrameworkCoffeeShop
{
    public static class UserInterface
    {
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
                    product.Id.ToString(),
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
                                   Id: {product.Id} 
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
}
