using Microsoft.AspNetCore.Mvc;

using Mfa.Dtos;
using Mfa.Interfaces;

namespace Mfa.Controllers;

[ApiController]
[Route("api/users")]

public class UserController: ControllerBase {
    private readonly IUserServices _userServices;

    public UserController(IUserServices userServices) {
        _userServices = userServices;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetUsersAsync([FromQuery] string? query) {
        try {
            IEnumerable<GetUsersResponseDto> users = await _userServices.GetUsers(new GetUsersRequestDto {
                Query = query,
            });

            return Ok(new ResponseDto<IEnumerable<GetUsersResponseDto>> {
                Data = users,
            });
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync([FromRoute] int id) {
        try {
            GetUserResponseDto user = await _userServices.GetUserById(id);

            return Ok(new ResponseDto<GetUserResponseDto> {
                Data = user,
            });
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequestDto body) {
        try {
            await _userServices.CreateUser(body);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateUserAsync([FromRoute] int id, [FromBody] UpdateUserRequestDto body) {
        try {
            await _userServices.UpdateUser(id, body);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteUserAsync([FromRoute] int id) {
        try {
            await _userServices.DeleteUser(id);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }
}