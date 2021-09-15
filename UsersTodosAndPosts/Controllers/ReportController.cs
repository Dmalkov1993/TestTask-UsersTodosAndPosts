using Microsoft.AspNetCore.Mvc;
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
        private readonly TodosClient todosClient;

        public ReportController(UsersClient usersClient, TodosClient todosClient)
        {
            this.usersClient = usersClient;
            this.todosClient = todosClient;
        }

        [HttpGet]
        public async Task<IActionResult> MakeReportByUserId([FromQuery] long userId)
        {
            // Тут можно было задействовать библиотеку MediatR
            return await new MakeReportRequestHandler(usersClient, todosClient)
                .HandleAsync(userId);
        }
    }
}
