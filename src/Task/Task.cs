namespace TaskManagerApp
{
    class Task
    {
        private Guid id;
        private string title;
        private string description;
        private bool isCompleted;
        private DateTime dueDate;

        public Task(
              string title, string description, bool isCompleted, DateTime dueDate
        )
        {
            id = Guid.NewGuid();
            this.title = title;
            this.description = description;
            this.isCompleted = isCompleted;
            this.dueDate = dueDate;
        }
        public string Name
        {
            get { return title; }
            set { title = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public bool IsCompleted
        {
            get { return isCompleted; }
            set { isCompleted = value; }
        }
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}