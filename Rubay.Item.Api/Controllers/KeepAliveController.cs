using Microsoft.AspNetCore.Mvc;

namespace Rubay.Item.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class KeepAliveController : ControllerBase
{
    [HttpGet]
    public bool Get() => true;
}