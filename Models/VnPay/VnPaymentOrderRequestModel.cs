namespace Models.VnPay;

public class VnPaymentOrderRequestModel 
{
    public int OrderId { get; set; }
    
    public decimal TotalAmount { get; set; }
    
    public string? Phone { get; set; }
}