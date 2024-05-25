using Models.VnPay;

namespace Services.VnpayService;

public interface IVnPayService
{
    string CreatePaymentUrl( VnPaymentRequest model);

    VnPaymentResponseModel PaymentExecute(IQueryCollection collections);

    string CreatePaymentUrlForOrder( VnPaymentOrderRequestModel model);

    string CreatePaymentUrlForSubscription( VnPaymentSubscriptionRequestModel model);
}