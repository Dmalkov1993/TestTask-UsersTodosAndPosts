using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;
using UsersTodosAndPosts.HttpClients;

namespace UsersTodosAndPosts.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUsersClient(this IServiceCollection services, string url)
        {
            services.AddHttpClient<UsersClient>(client =>
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
            });
            return services;
        }
    }
}
