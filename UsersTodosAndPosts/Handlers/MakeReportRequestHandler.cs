using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using UsersTodosAndPosts.HttpClients;
using UsersTodosAndPosts.Services;

namespace UsersTodosAndPosts.Controllers
{
    public class MakeReportRequestHandler : BaseRequestHandler
    {
        private readonly UsersClient usersClient;
        private readonly TodosClient todosClient;
        private readonly PostsClient postsClient;
        private readonly IExportReportToFileService exportReportToFileService;

        public MakeReportRequestHandler(
            UsersClient usersClient,
            TodosClient todosClient,
            PostsClient postsClient,
            IExportReportToFileService exportReportToFileService)
        {
            this.usersClient = usersClient;
            this.todosClient = todosClient;
            this.postsClient = postsClient;
            this.exportReportToFileService = exportReportToFileService;
        }

        public override async Task<IActionResult> HandleAsync(long userId)
        {
            // Сначала по ИД-у получим юзера. Если юзера нет - возвращаем BadRequest.
            var user = await usersClient.GetUserInfoByIdAsync(userId);

            if (user == default)
                return BadRequest($"Пользователь с id={userId} не найден.");

            // Получаем список дел, находим 5 последних завершенных
            var usersTodos = (await todosClient.GetAllUsersTodosByUserIdAsync(userId))
                .Where(t => t.Completed) // дело завершено
                .ToList();

            // Получаем список постов.
            // У постов нет признака что пост написан, поэтому, считаем что все посты уже написаны.
            var usersPosts = (await postsClient.GetAllUsersPostsByUserIdAsync(userId))
                .OrderByDescending(t => t.Id) // сортируем по убыванию Id
                .Take(5) // берем 5 первых (самые большие Id в начале коллекции)
                .ToList();

            // Пишем в файл.
            var fileName = $"Report from {DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.txt";
            var isExportSuccessful = await exportReportToFileService.ExportReportToFile(fileName, user, usersTodos, usersPosts);

            if (!isExportSuccessful)
                return BadRequest("Произошла ошибка при выгрузке отчета в файл.");

            return Ok($"Запрос успешно выполнен, результаты сложены в файл \"{fileName}\".");
        }
    }
}