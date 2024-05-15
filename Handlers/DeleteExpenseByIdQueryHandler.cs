using Common;
using Common.DTOs.ExpenseDTOs;
using Common.Interfaces;
using DigitalKhata_Monolithic.Queries;
using Ethik.Utility.Api;
using MediatR;

namespace DigitalKhata_Monolithic.Handlers;

public class DeleteExpenseByIdQueryHandler : IRequestHandler<DeleteExpenseByIdQuery, ApiResult<ExpenseResponse>>
{
    private readonly IExpenseRepository _expenseRepository;
    public DeleteExpenseByIdQueryHandler(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }

    public async Task<ApiResult<ExpenseResponse>> Handle(DeleteExpenseByIdQuery request,
        CancellationToken cancellationToken)
    {
        var expense = await _expenseRepository.DeleteExpense(request.Id);
        if (expense == null)
        {
            return ApiResultFactory.Failure<ExpenseResponse>(ErrorConstants.NoExpenseFound, "Expense with this Id does not exists", 404);
        }

        return ApiResultFactory.Success(expense, "Successfully deleted expense");
    }
}
