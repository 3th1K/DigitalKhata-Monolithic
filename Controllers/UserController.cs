﻿using Common.Models;
using DigitalKhata_Monolithic.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalKhata_Monolithic.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<UserController> _logger;
    public UserController(
        IMediator mediator,
        ILogger<UserController> logger
        )
    {
        _mediator = mediator;
        _logger = logger;
    }


    [HttpGet]
    [Route("search/{searchQuery}")]
    public async Task<ActionResult> SearchByUsername(string searchQuery)
    {
        var users = await _mediator.Send(new SearchUserByUsernameQuery(searchQuery));
        return users.Result;
    }

    [HttpGet]
    [Route("profile/{id}")]
    public async Task<ActionResult> GetUserProfile(int id)
    {
        var users = await _mediator.Send(new GetUserByIdQuery(id));
        return users.Result;
    }

    [HttpGet]
    [Route("all")]
    [AllowAnonymous]
    public async Task<ActionResult> GetAllUsers()
    {
        var users = await _mediator.Send(new GetAllUsersQuery());
        return users.Result;
    }

    [HttpGet]
    [Route("/health-check")]
    public IActionResult Healthcheck()
    {
        return Ok("Server Running");
    }
}
