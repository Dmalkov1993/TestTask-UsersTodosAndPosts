using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;
using System.Net.Mime;
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

        public static IServiceCollection AddTodosClient(this IServiceCollection services, string url)
        {
            services.AddHttpClient<TodosClient>(client =>
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
            });
            return services;
        }

        public static IServiceCollection AddPostsClient(this IServiceCollection services, string url)
        {
            services.AddHttpClient<PostsClient>(client =>
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
            });
            return services;
        }
    }
}
