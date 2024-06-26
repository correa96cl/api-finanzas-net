﻿namespace CashFlow.Communication;

public class ResponseRegisteredExpenseJson
{
    public string Title { get; set; }  = string.Empty;
    public string Description { get; set; }  = string.Empty;
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public PaymentType PaymemntType { get; set; }
}
