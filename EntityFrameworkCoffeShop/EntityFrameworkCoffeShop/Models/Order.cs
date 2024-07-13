using System.ComponentModel.DataAnnotations;


namespace EntityFrameworkCoffeeShop.Models;

public class Order
{

    [Key]
    public int OrderId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public ICollection<OrderProduct>? OrderProducts { get; set; }
}

