using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PlayNextServer.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
	[Authorize]
	[HttpGet("hello")]
	public string Hello() => "Hello world!";
}
