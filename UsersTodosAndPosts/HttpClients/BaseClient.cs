using System;
using System.Collections.Generic;
using System.Linq;
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

            var response = await httpClient.GetAsync(relativeUrl);
            if (response.IsSuccessStatusCode)
            {
                var entityStream = await response.Content.ReadAsStreamAsync();
                var entities = await JsonSerializer.DeserializeAsync<List<TEntity>>(entityStream);

                // Если этот пост для нашего юзера - аттачим в массив.
                var entitiesOfThisUser = entities
                    .Where(ent => ent.UserId == userId);

                usersEntities.AddRange(entitiesOfThisUser);
            }
            else
            {
                throw new Exception($"Не смог получить данные типа {typeof(TEntity)}, сервис вернул ошибку: {response.StatusCode}");
            }

            return usersEntities;
        }
    }
}
