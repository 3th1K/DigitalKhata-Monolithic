using Common.DTOs.ExpenseDTOs;
using Common.Models;
using DigitalKhata_Monolithic.Queries;
using Ethik.Utility.Api;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DigitalKhata_Monolithic.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ExpenseController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ExpenseController> _logger;
    public ExpenseController(IMediator mediator, ILogger<ExpenseController> logger)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> AddExpense(ExpenseAddRequest expenseAddRequest)
    {
        var expense = await _mediator.Send(expenseAddRequest);
        return expense.Result;
    }

    [HttpGet]
    [Route("{userId}/transaction-history/{otherUserId}")]
    public async Task<IActionResult> GetUserTransactionHistory(int userId, int otherUserId)
    {
        var transactionHistory = await _mediator.Send(new UserTransactionHistoryQuery(userId, otherUserId));
        return transactionHistory.Result;
    }

    [HttpGet]
    [Route("expense-users/{id}")]
    public async Task<IActionResult> GetUserExpenses(int id)
    {
        var userExpenses = await _mediator.Send(new UserExpensesQuery(id));
        return userExpenses.Result;
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await _mediator.Send(new DeleteExpenseByIdQuery(id));
        return data.Result;
    }
}
