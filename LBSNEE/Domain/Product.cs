using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace LBSNEE.Domain;

public class Product
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime ModifiedDateTime { get; set; }

    internal static Product Create(
        string name,
        string description,
        decimal price,
        int quantity,
        DateTime createdDateTime)
    {
        return new Product
        {
            Name = name,
            Description = description,
            Price = price,
            Quantity = quantity,
            CreatedDateTime = createdDateTime,
            ModifiedDateTime = createdDateTime
        };
    }

    internal void Update(string name, string description, decimal price, int quantity, DateTime dateTime)
    {
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        ModifiedDateTime = dateTime;
    }
}
