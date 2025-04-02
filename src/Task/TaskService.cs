namespace TaskManagerApp
{
    class TaskService
    {
        private readonly List<Task> tasks;

        public TaskService()
        {
            tasks = [];
        }
        public void AddNewTask(string title, string description)
        {
            Task newTask = new Task(title, description, false, DateTime.Now);
            tasks.Add(newTask);
        }
        public List<Task> GetTasksList()
        {
            return tasks;
        }
        public Task? Remove(Guid guid)
        {
            var foundTask = tasks.Find((item) => item.Id.Equals(guid));
            if (foundTask == null) return null;
            tasks.Remove(foundTask);
            return foundTask;
        }
        public Task? MarkTaskCompleted(Guid guid)
        {
            var foundTask = tasks.Find((item) => item.Id.Equals(guid));
            if (foundTask == null) return null;
            foundTask.IsCompleted = true;
            return foundTask;
        }

    }
}