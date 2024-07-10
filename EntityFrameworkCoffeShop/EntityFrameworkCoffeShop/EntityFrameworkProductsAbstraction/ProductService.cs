using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace EntityFrameworkCoffeeShop.EntityFrameworkProductsAbstraction
{
    public class ProductService
    {
        public static void AddProductService()
        {
            var product = new Product()
            {
                Name = AnsiConsole.Ask<string>("Specify the product`s name: "),
                Price = AnsiConsole.Ask<decimal>("Specify the product`s price: ")
            };
            ProductController.AddProduct(product);
            Console.Clear();
        }

        public static void RemoveProductService()
            => ProductController.RemoveProduct(GetProductOptionInput());

        public static void UpdateProductService()
        {
            var product = GetProductOptionInput();

            product.Name = AnsiConsole.Confirm("Update name?") 
                ? AnsiConsole.Ask<string>("Specify the new product`s name: ") 
                : product.Name;

            product.Price = AnsiConsole.Confirm("Update price:")
                ? AnsiConsole.Ask<decimal>("Specify the new product`s price: ")
                : product.Price;

            ProductController.UpdateProduct(product);
            Console.Clear();
        }

        public static void ShowProduct()
            => UserInterface.ShowProductDetails(GetProductOptionInput());

        public static void ShowAllProducts()
            => UserInterface.ShowProductsTable(GetAllProducts());

        public static Product GetProductById(int id)
            => new ProductsContext().Products.SingleOrDefault(x => x.Id == id)!;

        private static List<Product> GetAllProducts()
            => new ProductsContext().Products.ToList();

        private static Product GetProductOptionInput()
        {
            var products = GetAllProducts();
            var productsNameArray = products.Select(x => x.Name).ToArray();

            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose product")!
                .AddChoices(productsNameArray));


            var id = products.Single(x => x.Name == option).Id;
            var product = GetProductById(id);

            return product;
        }
    }
}
