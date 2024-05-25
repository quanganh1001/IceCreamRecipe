namespace Models.VnPay;

public class VnPaymentResponseModel
{
    public bool CheckValid { get; set; }
    public string Respronse { get; set; }
    public string VnPayResponseCode { get; set; }
    
    public long TotalAmount { get; set; }
    
}


