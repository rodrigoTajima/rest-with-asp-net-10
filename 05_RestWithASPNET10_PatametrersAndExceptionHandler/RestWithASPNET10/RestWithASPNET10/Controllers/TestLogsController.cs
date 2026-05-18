using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestLogsController : ControllerBase
    {
        private readonly ILogger<TestLogsController> _logger;

        public TestLogsController(ILogger<TestLogsController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult LogTest()
        {
            _logger.LogTrace("This is a Trace log");
            _logger.LogDebug("This is a Debug log");
            _logger.LogInformation("This is an Information log");
            _logger.LogWarning("This is a Warning log");
            _logger.LogError("This is an Error log");
            _logger.LogCritical("This is a Critical log");
            return Ok("Logs have been generated. Check your logging output.");
        }
    }
}
