namespace CashFlow.Exception;

public abstract class CashFlowException : SystemException
{


    public CashFlowException(string message) : base(message)
    {
    }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
