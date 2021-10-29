using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Contract;
using Todo.Contract.Models;

namespace Todo.Services
{
    public class TodoService : ITodo
    {
        private readonly List<TodoItem> _list;
        
        public TodoService()
        {
            _list = new List<TodoItem>();
        }

        public async Task AddAsync(TodoItem item)
        {
            if (item.Id == 0 && _list.Count > 0)
            {
                item.Id = _list.Max(t => t.Id) + 1;
            }
            
            var searchedItem = await GetItemByIdAsync(item.Id);

            if (searchedItem != null)
            {
                return;
            }
            
            _list.Add(item);
        }

        public async Task RemoveAsync(int id)
        {
            var item = await GetItemByIdAsync(id);

            if (item == null)
            {
                return;
            }
            
            await RemoveAsync(item);
        }

        public async Task RemoveAsync(TodoItem item)
        {
            await Task.CompletedTask;
            _list.Remove(item);
        }

        public async Task<List<TodoItem>> GetListAsync()
        {
            await Task.CompletedTask;
            return _list;
        }

        public async Task<TodoItem> GetItemByIdAsync(int id)
        {
            await Task.CompletedTask;
            return _list.FirstOrDefault(item => item.Id == id);
        }
    }
}