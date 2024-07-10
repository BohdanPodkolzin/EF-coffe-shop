using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
