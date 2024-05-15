using Common.DTOs.UserDTOs;
using Ethik.Utility.Api;
using MediatR;

namespace DigitalKhata_Monolithic.Queries;

public class GetUserByIdQuery : IRequest<ApiResult<UserResponse>>
{
    public readonly int Id;
    public GetUserByIdQuery(int id)
    {
        Id = id;
    }
}
