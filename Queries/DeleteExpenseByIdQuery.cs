using Common.DTOs.ExpenseDTOs;
using Common.DTOs.UserDTOs;
using Ethik.Utility.Api;
using MediatR;

namespace DigitalKhata_Monolithic.Queries;

public class DeleteExpenseByIdQuery : IRequest<ApiResult<ExpenseResponse>>
{
    public readonly int Id;
    public DeleteExpenseByIdQuery(int id)
    {
        Id = id;
    }
}
