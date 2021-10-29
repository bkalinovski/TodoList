using Microsoft.Extensions.DependencyInjection;
using Todo.Contract;
using Todo.Services;
using Todo.Repository;

namespace Todo
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddTodoServices(this IServiceCollection services)
        {
            services.AddSingleton<ITodo, TodoService>();
            
            return services;
        }
        
        public static IServiceCollection AddTodoInMemoryDbServices(this IServiceCollection services)
        {
            services.AddInMemoryDatabase();
            
            services.AddAutoMapper((provider, config) =>
            {
                config.AddMaps(typeof(DependencyInjectionExtension));
            }, typeof(DependencyInjectionExtension).Assembly);

            services.AddScoped<ITodo, TodoDbService>();
            
            return services;
        }
    }
}
