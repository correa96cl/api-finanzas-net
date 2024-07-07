﻿using CashFlow.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfraestructure(this IServiceCollection services)
    {
       services.AddScoped<IExpensesRepository, ExpensesRepository>();

    }
}
