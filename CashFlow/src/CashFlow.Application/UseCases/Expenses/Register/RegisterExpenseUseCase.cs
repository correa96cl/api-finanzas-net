using CashFlow.Communication;
using CashFlow.Domain;
using CashFlow.Exception;
using CashFlow.Infrastructure;

namespace CashFlow.Application;

public class RegisterExpenseUseCase
{

    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);
        var dbContext = new CashFlowDbContext();
        var entity = new Expense{
            Title = request.Title,
            Description = request.Description,
            Date = request.Date,
            Amount = request.Amount,
            PaymentType = (PaymentType)request.PaymentType
        };

        dbContext.Expenses.Add(entity);

        dbContext.SaveChanges();

        return new ResponseRegisteredExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();

        var result = validator.Validate(request);


        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }

    }
}
