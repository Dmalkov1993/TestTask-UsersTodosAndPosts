using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using UsersTodosAndPosts.HttpClients;

namespace UsersTodosAndPosts.Controllers
{
    public class MakeReportRequestHandler : BaseRequestHandler
    {
        private readonly UsersClient usersClient;
        private readonly TodosClient todosClient;

        public MakeReportRequestHandler(UsersClient usersClient, TodosClient todosClient)
        {
            this.usersClient = usersClient;
            this.todosClient = todosClient;
        }

        public override async Task<IActionResult> HandleAsync(long userId)
        {
            // Сначала по ИД-у получим юзера. Если юзера нет - возвращаем BadRequest.
            var user = await usersClient.GetUserInfoByIdAsync(userId);

            if (user == default)
                return BadRequest($"Пользователь с id={userId} не найден.");

            // Получаем список дел, находим 5 последних завершенных
            var usersTodos = (await todosClient
                .GetAllUsersTodosByUserId(userId))
                .Where(t => t.Completed) // дело завершено
                .OrderByDescending(t => t.Id) // сортируем по убыванию Id
                .Take(5) // берем 5 первых (самые большие Id в начале коллекции)
                .ToList();


            return Ok("Запрос успешно выполнен.");
        }
    }
}