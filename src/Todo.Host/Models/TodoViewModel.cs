using System.Collections.Generic;

namespace Todo.Host.Models
{
    public class TodoViewModel
    {
        public List<TodoItemModel> List { get; set; }

        public TodoItemModel TodoItem { get; set; }
    }
}