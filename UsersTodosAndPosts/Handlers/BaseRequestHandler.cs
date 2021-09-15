using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace UsersTodosAndPosts.Controllers
{
    public abstract class BaseRequestHandler
    {
        public abstract Task<IActionResult> HandleAsync(long userId);

        protected BadRequestObjectResult BadRequest(string badRequestMessage)
        {
            return new BadRequestObjectResult(badRequestMessage);
        }

        protected OkObjectResult Ok(string okMessage)
        {
            return new OkObjectResult(okMessage);
        }
    }
}