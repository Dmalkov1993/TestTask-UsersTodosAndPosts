using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersTodosAndPosts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> logger;

        public ReportController(ILogger<ReportController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public /*async Task<*/IActionResult/*>*/ MakeReportByUser([FromQuery]long userId)
        {
            throw new Exception("eeddd");

            return Ok();
        }
    }
}
