using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UsersTodosAndPosts.Models;

namespace UsersTodosAndPosts.HttpClients
{
    public class UsersClient
    {
        private readonly HttpClient httpClient;

        public UsersClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<UserInfo> GetUserInfoByIdAsync(long userId)
        {
            UserInfo userInfo = default;
            var response = await httpClient.GetAsync($"users/{userId}");

            if (response.IsSuccessStatusCode)
            {
                userInfo = await response.Content.ReadFromJsonAsync<UserInfo>();
            }

            return userInfo;
        }
    }
}
