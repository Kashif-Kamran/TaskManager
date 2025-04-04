
namespace TaskManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {

            // Ensuring Database 
            var db = new AppDbContext();

            var taskService = new TaskService();
            var taskView = new TaskView(taskService);

            Console.WriteLine("Task Manager Application");
            Console.WriteLine("Press Enter to start navigating tasks");
            Console.WriteLine("Use ↑/↓ arrows to navigate, Enter to select, ESC to exit selection mode\n");

            taskView.DisplayTasks();
        }
    }


}