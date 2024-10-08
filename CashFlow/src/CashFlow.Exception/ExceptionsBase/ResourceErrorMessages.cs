﻿
namespace CashFlow.Exception;

public class ResourceErrorMessages
{

    public const string UNKNOWN_ERROR = "Unknown error";
    public const string TITLE_REQUIRED = "Title is required";

    public const string AMOUNT_MUST_BE_GREATER_THAN_ZERO = "Mount must be greater than zero";

    public const string EXPENSES_CANNOT_FOR_THE_FUTURE = "Expenses cannot for the future";

    public const string PAYMENT_TYPE_INVALID = "Payment type invalid";

    public const string EXPENSE_NOT_FOUND = "Expense not found";

    public const string TITLE = "Titulo";
    public const string DATE = "Data";
    public const string PAYMENT_TYPE = "Tipo de Pagamento";
    public const string AMOUNT = "Valor";
    public const string DESCRIPTION = "Descrição";

    public const string EXPENSES_FOR = "Despesas para";

    public const string TOTAL_SPENT_IN = "Total gasto em {0}";


    public const string CASH = "Dinheiro";

    public const string CREDIT_CARD = "Cartão de Credito";

    public const string DEBIT_CARD = "Cartão de Debito";

    public const String ELETRONIC_TRANSFER = "Transferencia Eletronica";

    public static string EMAIL_EMPTY = "Email is required";

    public static string EMAIL_INVALID = "Email invalid";

    public static string NAME_EMPTY = "Name is required";

    public static string INVALID_PASSWORD = "Password invalid";

    public static string EMAIL_ALREADY_REGISTERED = "Email already registered";

    public static string EMAIL_OR_PASSWORD_INVALID = "Email or password invalid";
}
