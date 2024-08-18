﻿using AutoMapper;
using CashFlow.Communication;
using CashFlow.Domain;
using CashFlow.Exception;
using CashFlow.Infrastructure;

namespace CashFlow.Application;

public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{

private readonly IExpensesRepository _repository;
private readonly IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;


    public RegisterExpenseUseCase(IExpensesRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseRegisteredExpenseJson> Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);
        var entity = _mapper.Map<Expense>(request);

        await _repository.Add(entity);

        await _unitOfWork.Commit();

 

        return _mapper.Map<ResponseRegisteredExpenseJson>(entity);
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();

        var result = validator.Validate(request);


        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }

    }
}
