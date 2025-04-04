namespace TaskManagerApp
{
    public class TodoItem
    {
        public Guid id { set; get; }
        public string title { set; get; } = string.Empty;
        public string description { set; get; } = string.Empty;
        public bool isCompleted { set; get; }
        public DateTime dueDate { set; get; }

    }
}