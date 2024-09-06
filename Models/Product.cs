namespace ConsimpleDemo.Models;

public class Product :BaseEntity
{
    public string Name { get; set; }
    public string Category { get; set; }
    public string Article { get; set; }
    public decimal Price {  get; set; } 
    public ICollection<Order> Orders { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; }
}
