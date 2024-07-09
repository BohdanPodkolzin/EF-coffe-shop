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
            var name = AnsiConsole.Ask<string>("Specify the product`s name to add it: ");
            ProductController.AddProduct(name);
            Console.Clear();
        }

        public static void RemoveProductService()
            => ProductController.RemoveProduct(GetProductOptionInput());

        public static void UpdateProductService()
        {
            var product = GetProductOptionInput();
            var name = AnsiConsole.Ask<string>("Specify the new product`s name: ");
            ProductController.UpdateProduct(product, name);
            Console.Clear();
        }

        public static void ShowProduct()
            => UserInterface.ShowProductDetails(ProductService.GetProductOptionInput());

        public static void ShowAllProducts()
            => UserInterface.ShowProductsTable(GetAllProducts());

        public static Product GetProductById(int id)
            => new ProductsContext().Products.SingleOrDefault(x => x.Id == id)
               ?? new Product();

        private static List<Product> GetAllProducts()
            => new ProductsContext().Products.ToList();

        private static Product GetProductOptionInput()
        {
            var products = GetAllProducts();
            var productsArray = products.Select(x => x.Name).ToArray();

            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose product")!
                .AddChoices(productsArray));


            var id = products.Single(x => x.Name == option).Id;
            var product = GetProductById(id);

            return product;
        }
    }
}
