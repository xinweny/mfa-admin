using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Mfa.Dtos;
using Mfa.Interfaces;

namespace Mfa.Controllers;

[ApiController]
[Route("api/dues")]
[Authorize]

public class DueController: ControllerBase {
    private readonly IDueService _dueService;

    public DueController(IDueService dueService) {
        _dueService = dueService;
    }
}