using Microsoft.AspNetCore.Mvc;

using Mfa.Models;
using Mfa.Dtos;
using Mfa.Interfaces;

namespace Mfa.Controllers;

[ApiController]
[Route("api/users")]

public class UsersController: ControllerBase {
    private readonly IUserServices _userServices;

    public UsersController(IUserServices userServices) {
        _userServices = userServices;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetUsersAsync([FromQuery] string? query) {
        try {
            IEnumerable<User> users = await _userServices.GetUsersAsync(query);

            return Ok(users);
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync([FromRoute] int id) {
        try {
            User? user = await _userServices.GetUserByIdAsync(id);

            return user == null ? NotFound() : Ok(user);
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto body) {
        try {
            await _userServices.CreateUserAsync(body);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateUserAsync([FromRoute] int id, [FromBody] UpdateUserDto body) {
        try {
            await _userServices.UpdateUserAsync(id, body);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteUserAsync([FromRoute] int id) {
        try {
            await _userServices.DeleteUserAsync(id);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }
}