using Microsoft.AspNetCore.Mvc;

namespace Mfa.Features.Users;
[ApiController]
[Route("")]

public class UserController: ControllerBase {
    public ICollection<User> GetUsers() {

    }
}