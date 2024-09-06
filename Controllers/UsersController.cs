using ConsimpleDemo.Services;
using ConsimpleDemo.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsimpleDemo.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("birthday/{date}")]
    public async Task<IActionResult> GetBirthdayUsersAsync(string date)
    {
        var parsedDate = DateTime.Parse(date).ToUniversalTime();
        var res = await _userService.GetBirthdayUsersAsync(parsedDate);
        return Ok(res);
    }

    [HttpGet("made-orders-in/{days}")]
    public async Task<IActionResult> GetLastCustomersAsync(int days)
    {
        var res = await _userService.GetLastCustomersAsync(days);
        return Ok(res);
    }

    [HttpGet("{id}/bought-categories")]
    public async Task<IActionResult> GetUserCategoriesAsync(Guid id)
    {
        var res = await _userService.GetUserCategoriesAsync(id);
        return Ok(res);
    }
}
