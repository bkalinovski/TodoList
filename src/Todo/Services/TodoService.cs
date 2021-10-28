using System.Collections.Generic;
using System.Linq;
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

        public void Add(TodoItem item)
        {
            if (item.Id == 0 && _list.Count > 0)
            {
                item.Id = _list.Max(t => t.Id) + 1;
            }
            
            var searchedItem = GetItemById(item.Id);

            if (searchedItem != null)
            {
                return;
            }
            
            _list.Add(item);
        }

        public void Remove(int id)
        {
            var item = GetItemById(id);

            if (item == null)
            {
                return;
            }
            
            Remove(item);
        }

        public void Remove(TodoItem item)
        {
            _list.Remove(item);
        }

        public List<TodoItem> GetList()
        {
            return _list;
        }

        public TodoItem GetItemById(int id)
        {
            return _list.FirstOrDefault(item => item.Id == id);
        }
    }
}