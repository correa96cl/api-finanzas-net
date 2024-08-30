namespace CashFlow.Exception;

public abstract class CashFlowException : SystemException
{


    public CashFlowException(string message) : base(message)
    {
    }
}
