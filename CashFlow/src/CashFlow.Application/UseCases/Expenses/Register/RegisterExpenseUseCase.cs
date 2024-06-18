using CashFlow.Communication;

namespace CashFlow.Application;

public class RegisterExpenseUseCase
{

    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);
        return new ResponseRegisteredExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var titleIsEmpty = string.IsNullOrEmpty(request.Title);
        if (titleIsEmpty){
            throw new ArgumentException("Title is required");
        }

        if (request.Amount <= 0){
            throw new ArgumentException("Amount must be greater than zero");
        }

        var result = DateTime.Compare(request.Date, DateTime.UtcNow);

        if (result > 0){
            throw new ArgumentException("Date cannot be in the future");
        }

        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);

        if (paymentTypeIsValid){
            throw new ArgumentException("Payment type is invalid");
        }


    }
}
