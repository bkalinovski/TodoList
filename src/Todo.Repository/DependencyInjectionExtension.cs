using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Todo.Contract.Repository;

namespace Todo.Repository
{
    public static class DependencyInjectionExtension
    {
        private const string DatabaseName = "db1";
        
        public static IServiceCollection AddInMemoryDatabase(this IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase(DatabaseName));
            services.AddScoped(typeof(IRepository<>), typeof(Todo.Repository.Infrastructure.Repository<>));
            
            return services;
        }
    }
}
