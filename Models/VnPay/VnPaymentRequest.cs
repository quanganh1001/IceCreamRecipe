namespace Models.VnPay;

public class VnPaymentRequest
{
    public string ReturnUrl { get; set; }
    
    public string Amount { get; set; }
    
    public string OrderInfo { get; set; }
    
    public string TxnRef { get; set; }
    
}