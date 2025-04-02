namespace TaskManagerApp
{
    class TaskView
    {
        private TaskService taskService;
        private int selectedIndex = -1;
        private bool isSelectionMode = false;

        public TaskView(TaskService taskService)
        {
            this.taskService = taskService;
        }

        private string TruncateString(string input, int maxLength)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty.PadRight(maxLength);
            return input.Length > maxLength ? input.Substring(0, maxLength - 3) + "..." : input.PadRight(maxLength);
        }

        public void DisplayTasks()
        {
            var tasks = taskService.GetTasksList();
            RenderTaskList(tasks);

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Enter && !isSelectionMode)
                {
                    if (tasks == null || tasks.Count == 0)
                    {
                        Console.WriteLine("\nNo tasks to select!");
                        continue;
                    }

                    if (!isSelectionMode)
                    {
                        isSelectionMode = true;
                        selectedIndex = 0;
                        RenderTaskList(tasks);
                    }
                }
                else if (isSelectionMode)
                {
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            selectedIndex = Math.Max(0, selectedIndex - 1);
                            RenderTaskList(tasks!);
                            break;

                        case ConsoleKey.DownArrow:
                            selectedIndex = Math.Min(tasks!.Count - 1, selectedIndex + 1);
                            RenderTaskList(tasks!);
                            break;

                        case ConsoleKey.Escape:
                            SetNormalMode();
                            RenderTaskList(tasks!);
                            break;

                        case ConsoleKey.Delete:
                            SetNormalMode();
                            DeleteTaskAtIndex(selectedIndex);
                            RenderTaskList(tasks!);
                            break;
                    }
                }
            }
        }

        public void SetNormalMode()
        {
            isSelectionMode = false;
            selectedIndex = -1;
        }

        public void SetSelectedMode()
        {
            isSelectionMode = true;
            selectedIndex = 0;
        }

        public Task? DeleteTaskAtIndex(int index)
        {

            List<Task> tasks = taskService.GetTasksList();
            if (index < 0 || index > tasks.Count) return null;
            var task = tasks[index];
            taskService.Remove(task.Id);
            return task;
        }
        private void RenderTaskList(List<Task> tasks)
        {
            Console.Clear();
            Console.WriteLine("\nTask List (Press ESC to exit selection mode)");
            Console.WriteLine($"{"",-3} {"TITLE",-20} {"DESCRIPTION",-30} {"COMPLETED",-10} {"DUE DATE",-15}");
            Console.WriteLine(new string('-', 115));

            if (tasks == null || tasks.Count == 0)
            {
                Console.WriteLine("No tasks to display.");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                var task = tasks[i];
                string selectionIndicator = (i == selectedIndex && isSelectionMode) ? "→ " : "  ";
                string formattedTitle = TruncateString(task.Name, 20);
                string formattedDescription = TruncateString(task.Description, 30);
                string formattedCompleted = task.IsCompleted ? "✅" : "❌";
                string formattedDueDate = task.DueDate.ToString("yyyy-MM-dd");

                Console.WriteLine(
                    $"{selectionIndicator,-3}" +
                    $"{formattedTitle,-20} " +
                    $"{formattedDescription,-30} " +
                    $"{formattedCompleted,-10} " +
                    $"{formattedDueDate,-15}");
            }
        }
    }
}