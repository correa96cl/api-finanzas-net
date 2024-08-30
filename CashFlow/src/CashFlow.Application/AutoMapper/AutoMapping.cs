using System;
using AutoMapper;
using CashFlow.Communication;
using CashFlow.Communication.Responses;
using CashFlow.Domain;
using FluentValidation;

namespace CashFlow.Application.AutoMapper;

public class AutoMapping : Profile
{

    public AutoMapping(){
        RequestToEntity();
        EntityToResponse();

    }


    private void RequestToEntity(){

        CreateMap<RequestRegisterExpenseJson, Expense>();
    }

    private void EntityToResponse(){
        CreateMap<Expense, ResponseRegisteredExpenseJson>();
        CreateMap<Expense, ResponseShortExpenseJson>();
        CreateMap<Expense, ResponseExpensesJson>();
    }

}
