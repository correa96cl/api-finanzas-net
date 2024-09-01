using System;

namespace CashFlow.Domain.Repositories.Expenses;

public interface IExpensesReadOnlyRepository
{
    Task<List<Expense>> GetAll();
    Task<Expense?> GetById(long id);

}
