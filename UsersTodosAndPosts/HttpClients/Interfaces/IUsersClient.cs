using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersTodosAndPosts.Models;

namespace UsersTodosAndPosts.HttpClients.Interfaces
{
    public interface IUsersClient
    {
        UserInfo GetUserInfoById();
    }
}
