namespace CashFlow.Domain;

public interface IExpensesRepository
{

    public Task Add(Expense expense);
    Task<List<Expense>> GetAll();
    Task<Expense?> GetById(long id);



}
