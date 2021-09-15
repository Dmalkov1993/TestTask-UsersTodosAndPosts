using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UsersTodosAndPosts.Models;

namespace UsersTodosAndPosts.HttpClients
{
    public abstract class BaseClient
    {
        protected readonly HttpClient httpClient;

        public BaseClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        protected virtual async Task<List<TEntity>> GetAllEntitiesByUserId<TEntity>(string relativeUrl, long userId)
            where TEntity : UserIdEntity
        {
            var usersEntities = new List<TEntity>();
            var continueRequestEntities = true;
            var entityId = 1;

            // Представим, что сервис, к которому мы обращаемся "идеален" и всегда доступен.
            while (continueRequestEntities)
            {
                var response = await httpClient.GetAsync($"{relativeUrl}/{entityId}");
                var postStream = await response.Content.ReadAsStreamAsync();

                if (response.IsSuccessStatusCode)
                {
                    var currentPost = await JsonSerializer.DeserializeAsync<TEntity>(postStream);

                    // Если этот пост для нашего юзера - аттачим в массив.
                    if (currentPost.UserId == userId)
                    {
                        usersEntities.Add(currentPost);
                    }
                }
                else
                {
                    continueRequestEntities = false;
                }

                entityId++;
            }

            return usersEntities;
        }
    }
}
