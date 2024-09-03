﻿using System.ComponentModel.DataAnnotations;
using Bogus;
using CashFlow.Communication;

namespace CommonTestUtilities;

public  class RequestRegisterExpenseJsonBuilder
{


public static RequestExpenseJson Build(){


    return new Faker<RequestExpenseJson>()
    .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
    .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
    .RuleFor(r => r.Date, faker => faker.Date.Past())
    .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>())
    .RuleFor(r => r.Amount, faker => faker.Random.Decimal(min: 1, max: 10000));

}
}
