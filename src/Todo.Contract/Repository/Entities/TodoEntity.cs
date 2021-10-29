namespace Todo.Contract.Repository.Entities
{
    public class TodoEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsCompleted { get; set; }
    }
}