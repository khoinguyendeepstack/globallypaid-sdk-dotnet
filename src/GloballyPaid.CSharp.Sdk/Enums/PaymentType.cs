using System.Runtime.Serialization;

namespace GloballyPaid
{
    public enum PaymentType
    {
        [EnumMember(Value = "credit_card")]
        CreditCard = 1,
        [EnumMember(Value = "bank_account")]
        BankAccount = 2
    }
}