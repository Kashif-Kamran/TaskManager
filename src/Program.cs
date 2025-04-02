
namespace TaskManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskService = new TaskService();

            taskService.AddNewTask("Buy groceries", "Milk, eggs, bread");
            taskService.AddNewTask("Finish report", "Complete the quarterly report");
            taskService.AddNewTask("Call client", "Discuss project requirements");

            var taskView = new TaskView(taskService);

            Console.WriteLine("Task Manager Application");
            Console.WriteLine("Press Enter to start navigating tasks");
            Console.WriteLine("Use ↑/↓ arrows to navigate, Enter to select, ESC to exit selection mode\n");

            taskView.DisplayTasks();
        }
    }


}