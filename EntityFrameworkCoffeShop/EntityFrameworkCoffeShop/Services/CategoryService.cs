using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCoffeeShop.CoffeeShopMenu;
using EntityFrameworkCoffeeShop.Controllers;
using EntityFrameworkCoffeeShop.Models;
using Spectre.Console;

namespace EntityFrameworkCoffeeShop.Services
{
    public class CategoryService
    {
        public static void AddCategoryService()
        {
            var category = new Category
            {
                Name = AnsiConsole.Ask<string>("Enter the category name: ")
            };

            CategoryController.AddCategory(category);
        }

        public static List<Category> GetAllCategories()
            => new ProductsContext().Categories.ToList();
        
        public static void ShowAllCategories()
            => UserInterface.ShowCategoriesTable(GetAllCategories());



        public static int GetCategoriesOptionInput()
        {
            var categories = GetAllCategories();
            var categoriesNameArray = categories.Select(x => x.Name).ToArray();

            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose category")!
                .AddChoices(categoriesNameArray));


            var id = categories.Single(x => x.Name == option).CategoryId;

            return id;
        }
    }
}
