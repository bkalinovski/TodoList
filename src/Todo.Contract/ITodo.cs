using System.Collections.Generic;
using Todo.Contract.Models;

namespace Todo.Contract
{
    public interface ITodo
    {
        public void Add(TodoItem item);

        public void Remove(int id);

        public void Remove(TodoItem item);

        public List<TodoItem> GetList();

        public TodoItem GetItemById(int id);
    }
}