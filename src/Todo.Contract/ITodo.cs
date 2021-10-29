using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Contract.Models;

namespace Todo.Contract
{
    public interface ITodo
    {
        public Task AddAsync(TodoItem item);

        public Task RemoveAsync(int id);

        public Task RemoveAsync(TodoItem item);

        public Task<List<TodoItem>> GetListAsync();

        public Task<TodoItem> GetItemByIdAsync(int id);
    }
}