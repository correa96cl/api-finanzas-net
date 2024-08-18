using CashFlow.Communication;
using CashFlow.Domain;
using CashFlow.Exception;
using CashFlow.Infrastructure;

namespace CashFlow.Application;

public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{

private readonly IExpensesRepository _repository;
private readonly IUnitOfWork _unitOfWork;


    public RegisterExpenseUseCase(IExpensesRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseRegisteredExpenseJson> Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);
        var entity = new Expense{
            Title = request.Title,
            Description = request.Description,
            Date = request.Date,
            Amount = request.Amount,
            PaymentType = (PaymentType)request.PaymentType
        };

        await _repository.Add(entity);

        await _unitOfWork.Commit();

 

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
