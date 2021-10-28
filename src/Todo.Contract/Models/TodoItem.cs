namespace Todo.Contract.Models
{
    public class TodoItem
    {
        public TodoItem(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public TodoItem()
        {
        }

        public int Id { get; set; }

        public string Description { get; set; }
    }
}