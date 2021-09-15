using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UsersTodosAndPosts.Models;

namespace UsersTodosAndPosts.HttpClients
{
    public class PostsClient : BaseClient
    {
        public PostsClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<List<Post>> GetAllUsersPostsByUserIdAsync(long userId)
        {
            return await GetAllEntitiesByUserId<Post>("posts", userId);
        }
    }
}
