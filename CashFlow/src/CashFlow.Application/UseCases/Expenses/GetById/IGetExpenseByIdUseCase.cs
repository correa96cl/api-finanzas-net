using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.GetById;
public interface IGetExpenseByIdUseCase
{
    Task<ResponseExpensesJson> Execute(long id);
}