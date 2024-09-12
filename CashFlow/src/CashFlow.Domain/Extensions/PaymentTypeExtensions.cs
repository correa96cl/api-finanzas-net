using CashFlow.Exception;

namespace CashFlow.Domain.Extensions;
public static class PaymentTypeExtensions
{
    public static string PaymentTypeToString(this PaymentType paymentType)
    {
        return paymentType switch
        {
            PaymentType.CASH => ResourceErrorMessages.CASH,
            PaymentType.CREDIT => ResourceErrorMessages.CREDIT_CARD,
            PaymentType.DEBIT => ResourceErrorMessages.DEBIT_CARD,
            PaymentType.ELECTRONIC_TRANSFER => ResourceErrorMessages.ELETRONIC_TRANSFER,
            _ => string.Empty
        };
    }
}