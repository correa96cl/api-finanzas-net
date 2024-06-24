using System.ComponentModel.DataAnnotations;
using Bogus;
using CashFlow.Communication;

namespace CommonTestUtilities;

public  class RequestRegisterExpenseJsonBuilder
{


public static RequestRegisterExpenseJson Build(){


    return new Faker<RequestRegisterExpenseJson>()
    .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
    .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
    .RuleFor(r => r.Date, faker => faker.Date.Past())
    .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>())
    .RuleFor(r => r.Amount, faker => faker.Random.Decimal(min: 1, max: 10000));

    /*return new RequestRegisterExpenseJson(){
        Amount = 10,
        Description = "test",
        Title = "test",
        Date = DateTime.Now.AddDays(-1),
        PaymentType = PaymentType.CASH
    };*/

}
}
