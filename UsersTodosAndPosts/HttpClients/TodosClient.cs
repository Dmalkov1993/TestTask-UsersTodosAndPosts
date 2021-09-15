using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UsersTodosAndPosts.Models;

namespace UsersTodosAndPosts.HttpClients
{
    public class TodosClient : BaseClient
    {
        public TodosClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<List<Todo>> GetAllUsersTodosByUserIdAsync(long userId)
        {
            return await GetAllEntitiesByUserId<Todo>("todos", userId);
        }
    }
}
