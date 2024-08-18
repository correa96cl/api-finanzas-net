﻿using CashFlow.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Metadata.Conventions;

namespace CashFlow.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services){
        AddAutoMapper(services);
        AddUseCase(services);
    }

    private static void AddAutoMapper(this IServiceCollection services){
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCase(this IServiceCollection services){
        services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();

    }
}
