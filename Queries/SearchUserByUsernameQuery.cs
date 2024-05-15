﻿using Common.DTOs.UserDTOs;
using Ethik.Utility.Api;
using MediatR;

namespace DigitalKhata_Monolithic.Queries;

public class SearchUserByUsernameQuery : IRequest<ApiResult<List<UserResponse>>>
{
    public readonly string SearchString;

    public SearchUserByUsernameQuery(string searchString)
    {
        SearchString = searchString;
    }
}
