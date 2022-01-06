using Microsoft.AspNetCore.Mvc;

namespace WebApiGetStarted.Controllers;

[ApiController]
[Route("[controller]")]
public class GetDateTimeController : ControllerBase
{

    private readonly ILogger<GetDateTimeController> _logger;

    public GetDateTimeController(ILogger<GetDateTimeController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetDateTime")]
    public String Get()
    {
        return DateTime.Now.ToString();
    }

}
