using CashFlow.Communication;

namespace CashFlow.Application;

public interface IRegisterExpenseUseCase
{
    ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request);
}
