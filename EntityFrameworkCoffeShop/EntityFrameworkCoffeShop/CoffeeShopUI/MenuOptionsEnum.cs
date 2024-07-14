namespace EntityFrameworkCoffeeShop.CoffeeShopUI; 

public enum MainMenuOptionsEnum
{
    ManageCategories = 500,
    ManageProducts,
    ManageOrders,
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

public enum OrderOptionsEnum
{
    AddOrder,
    ShowOrders,
    ShowOrder,
    GoBack
}
