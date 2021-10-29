namespace Todo.Contract.Models
{
    public class TodoItem
    {
        public TodoItem(int id, string description)
        {
            Id = id;
            Description = description;
            IsCompleted = false;
        }

        public TodoItem()
        {
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}