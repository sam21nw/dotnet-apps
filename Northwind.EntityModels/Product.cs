using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.EntityModels;

public class Product
{
    public int ProductId { get; set; }
    [Required]
    [StringLength(40)]
    public required string ProductName { get; set; }
    [Column("UnitPrice", TypeName = "money")]
    public decimal? Cost { get; set; }
    [Column("UnitsInStock")]
    public short? Stock { get; set; }
    public bool Discontinued { get; set; }
    public int CategoryId { get; set; }
    public virtual required Category Category { get; set; }
}
