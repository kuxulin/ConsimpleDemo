namespace ConsimpleDemo.Models;

public class Order : BaseEntity
{
    public int Number { get; set; }
    public DateTime CreationDate { get; set; }
    public decimal TotalValue { get; set; }
    public ICollection<Product> Products { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}
