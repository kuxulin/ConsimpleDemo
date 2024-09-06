namespace ConsimpleDemo.Models;

public class OrderProduct
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public Guid Productid { get; set; }
    public Product Product { get; set; }
    public int ProductAmount { get; set; }
}
