using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UsersTodosAndPosts.Models;

namespace UsersTodosAndPosts.Services
{
    public class ExportReportToFileService : IExportReportToFileService
    {
        private readonly string urlToFile;

        public ExportReportToFileService(IConfiguration configuration)
        {
            urlToFile = configuration.GetValue<string>("PathForReportResults");
        }

        public async Task<bool> ExportReportToFile(string fileName, UserInfo userInfo, List<Todo> todos, List<Post> posts)
        {
            var paths = GetAbsoluteFilePath(fileName);

            CheckIsOutputDirectoryExist(paths.absolutePath);

            using (StreamWriter sw = File.CreateText(paths.absolutePathWithFileName))
            {
                await sw.WriteLineAsync($"Уважаемый {userInfo.Name},");
                await sw.WriteLineAsync("ниже представлен список ваших  действий за последнее время.");
                await sw.WriteLineAsync();
                await sw.WriteLineAsync("Выполнено задач:");

                foreach (var todo in todos)
                {
                    await sw.WriteLineAsync(todo.Title);
                }

                await sw.WriteLineAsync();
                await sw.WriteLineAsync("Написано постов:");

                foreach (var post in posts)
                {
                    await sw.WriteLineAsync(post.Title);
                }
            }

            // Если true - значит всё успешно.
            return true;
        }

        private static void CheckIsOutputDirectoryExist(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                Directory.CreateDirectory(absolutePath);
            }
        }

        private (string absolutePath, string absolutePathWithFileName) GetAbsoluteFilePath(string fileName)
        {
            if (Path.IsPathRooted(urlToFile))
            {
                return (urlToFile, Path.Combine(urlToFile, fileName));
            }

            return (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, urlToFile),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, urlToFile, fileName));
        }
    }
}
