using System.Globalization;
using EntityFrameworkCoffeeShop.CoffeeShopUI;
using EntityFrameworkCoffeeShop.Controllers;
using EntityFrameworkCoffeeShop.Migrations.DataTransferObjects;

namespace EntityFrameworkCoffeeShop.Services;

public class ReportService
{
    public static void ShowReportService() 
        => UserInterface.ShowReport(CreateMonthlyReportService());

    private static List<MonthlyReportDto> CreateMonthlyReportService()
    {
        var orders = OrderController.GetOrderProducts();
        var report = orders.GroupBy(x => new
        {
            x.CreatedDate.Month
        })
        .Select(group => new MonthlyReportDto
        {
            Month = 
                CultureInfo.CurrentCulture
                    .DateTimeFormat.GetMonthName(group.Key.Month),
            TotalPrice = group.Sum(x => x.TotalPrice),
            TotalQuantity = group.Sum(x => x.OrderProducts!.Sum(x => x.Quantity))
        })
        .ToList();

        return report;
    }
}

