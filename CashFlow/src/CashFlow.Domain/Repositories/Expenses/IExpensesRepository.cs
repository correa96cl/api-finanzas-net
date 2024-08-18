namespace CashFlow.Domain;

public interface IExpensesRepository
{

    public Task Add(Expense expense);

}
