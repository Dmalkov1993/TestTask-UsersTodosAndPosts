using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersTodosAndPosts.HttpClients;

namespace UsersTodosAndPosts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        // private readonly ILogger<ReportController> logger;

        // Эти поля тут из-за того, что их нужно прокинуть в MakeReportRequestHandler.
        // MediatR бы решил эту проблему.
        private readonly UsersClient usersClient;

        public ReportController(UsersClient usersClient)
        {
            this.usersClient = usersClient;
        }

        [HttpGet]
        public async Task<IActionResult> MakeReportByUserId([FromQuery] long userId)
        {
            // Тут можно было задействовать библиотеку MediatR
            return await new MakeReportRequestHandler(usersClient).HandleAsync(userId);
        }
    }
}
