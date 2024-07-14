namespace EntityFrameworkCoffeeShop.Migrations.DataTransferObjects;

public class MonthlyReportDto
{
    public string Month { get; set; }
    public decimal TotalPrice { get; set; }
    public int TotalQuantity { get; set; }
}

