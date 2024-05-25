using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Books;


namespace Models.OrderDetails;

public class OrderDetailRes
{
    public required int Id { get; set; }
    
    public required decimal PurchasePrice { get; set; }
    
    public required int Quantity { get; set; }

    public required BookRes Book { get; set; }
}