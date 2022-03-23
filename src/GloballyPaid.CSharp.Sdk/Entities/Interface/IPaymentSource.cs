namespace GloballyPaid.Interface
{
    public interface IPaymentSource
    {
        PaymentSourceType Type { get; set; }
    }
}