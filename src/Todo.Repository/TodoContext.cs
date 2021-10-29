using Microsoft.EntityFrameworkCore;
using Todo.Contract.Repository.Entities;

namespace Todo.Repository
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            
        }

        public DbSet<TodoEntity> TodoList { get; set; }
    }
}