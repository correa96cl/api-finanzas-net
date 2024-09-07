using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Expenses.Reports.Excel;
public class GenerateExpensesReportExcelUseCase : IGenerateExpensesReportExcelUseCase


{

    private readonly IExpensesReadOnlyRepository _repository;

    public GenerateExpensesReportExcelUseCase(IExpensesReadOnlyRepository repository)
    {
        _repository = repository;
    }
    public async Task<byte[]> Execute(DateOnly month)
    {

        var expenses = await _repository.FilterByMonth(month);
        if (expenses.Count == 0)
        {
            return [];
        }
        var workbook = new XLWorkbook();

        workbook.Author = "Welisson Arley";
        workbook.Style.Font.FontSize = 12;
        workbook.Style.Font.FontName = "Times New Roman";

        var worksheet = workbook.Worksheets.Add(month.ToString("Y"));
        InsertHeader(worksheet);

          var raw = 2;
        foreach(var expense in expenses)
        {
            worksheet.Cell($"A{raw}").Value = expense.Title;
            worksheet.Cell($"B{raw}").Value = expense.Date;
            worksheet.Cell($"C{raw}").Value = ConvertPaymentType(expense.PaymentType);
            worksheet.Cell($"D{raw}").Value = expense.Amount;
            worksheet.Cell($"E{raw}").Value = expense.Description;

            raw++;
        }
        var file = new MemoryStream();
        workbook.SaveAs(file);

        return file.ToArray();

    }

        private string ConvertPaymentType(PaymentType payment)
    {
        return payment switch
        {
            PaymentType.CASH => "Dinheiro",
            PaymentType.CREDIT => "Cartão de Crédio",
            PaymentType.DEBIT => "Cartão de Débito",
            PaymentType.ELECTRONIC_TRANSFER => "Transferencia Bancaria",
            _ => string.Empty
        };
    }

    private void InsertHeader(IXLWorksheet worksheet)
    {
        worksheet.Cell("A1").Value = ResourceErrorMessages.TITLE;
        worksheet.Cell("B1").Value = ResourceErrorMessages.DATE;
        worksheet.Cell("C1").Value = ResourceErrorMessages.PAYMENT_TYPE;
        worksheet.Cell("D1").Value = ResourceErrorMessages.AMOUNT;
        worksheet.Cell("E1").Value = ResourceErrorMessages.DESCRIPTION;

        worksheet.Cells("A1:E1").Style.Font.Bold = true;

        worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#F5C2B6");

        worksheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
    }
}