using System;
using AutoMapper;
using CashFlow.Communication;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain;
using CashFlow.Domain.Entities;
using FluentValidation;

namespace CashFlow.Application.AutoMapper;

public class AutoMapping : Profile
{

    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();

    }


    private void RequestToEntity()
    {

        CreateMap<RequestExpenseJson, Expense>();
         CreateMap<RequestRegisterUserJson, User>()
            .ForMember(dest => dest.Password, config => config.Ignore());

    }

    private void EntityToResponse()
    {
        CreateMap<Expense, ResponseRegisteredExpenseJson>();
        CreateMap<Expense, ResponseShortExpenseJson>();
        CreateMap<Expense, ResponseExpenseJson>();
    }

}
