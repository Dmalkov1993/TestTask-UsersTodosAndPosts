using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UsersTodosAndPosts.HttpClients;

namespace UsersTodosAndPosts.Controllers
{
    public class MakeReportRequestHandler : BaseRequestHandler
    {
        private readonly UsersClient usersClient;

        public MakeReportRequestHandler(UsersClient usersClient)
        {
            this.usersClient = usersClient;
        }

        public override async Task<IActionResult> HandleAsync(long userId)
        {
            // Сначала по ИД-у получим юзера. Если юзера нет - возвращаем BadRequest.
            var user = await usersClient.GetUserInfoByIdAsync(userId);

            if (user == default)
                return BadRequest($"Пользователь с id={userId} не найден.");

            // Получаем список дел.


            return Ok("Запрос успешно выполнен.");
        }
    }
}