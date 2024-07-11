using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCoffeeShop.CoffeeShopMenu;
using EntityFrameworkCoffeeShop.Controllers;
using EntityFrameworkCoffeeShop.Models;
using Microsoft.EntityFrameworkCore;
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

        public static void UpdateCategoryService()
        {
            var category = GetCategoriesOptionInput();
            category.Name = AnsiConsole.Ask<string>("Enter the new category name: ");

            CategoryController.UpdateCategory(category);
        }

        public static void RemoveCategoryService()
            => CategoryController.RemoveCategory(GetCategoriesOptionInput());
        

        public static List<Category> GetAllCategories()
            => new ProductsContext().Categories.Include(x => x.Products).ToList();
        
        public static void ShowAllCategories()
            => UserInterface.ShowCategoriesTable(GetAllCategories());

        public static void ShowCategoryProductsService() 
            => UserInterface.ShowCategoryProducts(GetCategoriesOptionInput());

        public static Category GetCategoriesOptionInput()
        {
            var categories = GetAllCategories();
            var categoriesNameArray = categories.Select(x => x.Name).ToArray();

            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose category")!
                .AddChoices(categoriesNameArray));


            var category = categories.Single(x => x.Name == option);
            return category;
        }
    }
}
