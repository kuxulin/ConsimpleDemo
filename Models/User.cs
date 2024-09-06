namespace ConsimpleDemo.Models;

public class User : BaseEntity
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime RegistrationDate { get; set; }
    public ICollection<Order> Orders { get; set; }

}
