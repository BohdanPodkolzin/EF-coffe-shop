namespace EntityFrameworkCoffeeShop.CoffeeShopUI; 

public enum MainMenuOptionsEnum
{
    ManageCategories = 500,
    ManageProducts,
    Quit
}

public enum ProductOptionsEnum
{
    AddProduct = 600,
    RemoveProduct,
    UpdateProduct,
    ShowProduct,
    ShowAllProducts,
    GoBack
}

public enum CategoryOptionsEnum
{
    AddCategory = 700,
    RemoveCategory,
    UpdateCategory,
    ShowAllCategories,
    ShowCategoryProducts,
    GoBack
}
