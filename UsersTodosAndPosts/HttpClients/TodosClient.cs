using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using UsersTodosAndPosts.Models;

namespace UsersTodosAndPosts.HttpClients
{
    public class TodosClient
    {
        private readonly HttpClient httpClient;

        public TodosClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Todo>> GetAllUsersTodosByUserId(long userId)
        {
            var todos = new List<Todo>();
            var continueRequestTodos = true;
            var todoId = 1;

            // Представим, что сервис, к которому мы обращаемся "идеален" и всегда доступен.
            while (continueRequestTodos)
            {
                var response = await httpClient.GetAsync($"todos/{todoId}");
                var todoStream = await response.Content.ReadAsStreamAsync();

                if (response.IsSuccessStatusCode && todoStream.Length > 0)
                {
                    var todo = await JsonSerializer.DeserializeAsync<Todo>(todoStream); // response.Content.ReadFromJsonAsync<Todo>();

                    // Если эта туду-шка для нашего юзера - аттачим в массив.
                    if (todo.UserId == userId)
                    {
                        todos.Add(todo);
                    }
                }
                else
                {
                    continueRequestTodos = false;
                }

                todoId++;
            }

            return todos;
        }
    }
}
