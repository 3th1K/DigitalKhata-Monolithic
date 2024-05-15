using Common.DTOs.ExpenseDTOs;
using Common.DTOs.UserDTOs;
using Ethik.Utility.Api;
using MediatR;

namespace DigitalKhata_Monolithic.Queries;

public record GetAllUsersQuery : IRequest<ApiResult<List<UserResponse>>>;
