using CashFlow.Domain;

namespace CashFlow.Infrastructure;

internal class ExpensesRepository : IExpensesRepository
{
    public void Add(Expense expense)
    {
       var dbContext = new CashFlowDbContext();
       dbContext.Expenses.Add(expense);
       dbContext.SaveChanges();
    }
}
