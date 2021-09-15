using System.Collections.Generic;
using System.Threading.Tasks;
using UsersTodosAndPosts.Models;

namespace UsersTodosAndPosts.Services
{
    public interface IExportReportToFileService
    {
        Task<bool> ExportReportToFile(string fileName, UserInfo userInfo, List<Todo> todos, List<Post> posts);
    }
}