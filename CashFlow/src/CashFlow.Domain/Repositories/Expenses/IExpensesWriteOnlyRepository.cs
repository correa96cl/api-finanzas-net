using System;

namespace CashFlow.Domain.Repositories.Expenses;

public interface IExpensesWriteOnlyRepository
{
    public Task Add(Expense expense);
    Task<bool> Delete(long id);


}
