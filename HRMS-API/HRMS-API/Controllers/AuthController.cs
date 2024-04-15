﻿using Microsoft.AspNetCore.Mvc;

namespace HRMS_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost]
    public IActionResult Login()
    {
        return Ok();
    }
}
