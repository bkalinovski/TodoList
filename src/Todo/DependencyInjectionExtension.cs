using Microsoft.Extensions.DependencyInjection;
using Todo.Contract;
using Todo.Services;

namespace Todo
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddTodoServices(this IServiceCollection services)
        {
            services.AddSingleton<ITodo, TodoService>();
            
            return services;
        }
    }
}
