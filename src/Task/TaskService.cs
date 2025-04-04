using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManagerApp
{
    public class TaskService : IAsyncDisposable
    {
        private readonly AppDbContext _dbContext;

        public TaskService()
        {
            _dbContext = new AppDbContext();
            _dbContext.Database.EnsureCreated();
        }

        public async Task AddNewTaskAsync(string title, string description)
        {
            var newTask = new TodoItem
            {
                id = Guid.NewGuid(),
                title = title,
                description = description,
                dueDate = DateTime.UtcNow,  // Using UtcNow instead of new DateTime()
                isCompleted = false,
            };

            await _dbContext.tasks.AddAsync(newTask);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TodoItem>> GetTasksListAsync()
        {
            return await _dbContext.tasks.ToListAsync();
        }

        public async Task<TodoItem?> RemoveAsync(Guid guid)
        {
            var task = await _dbContext.tasks
                .FirstOrDefaultAsync(t => t.id == guid);

            if (task != null)
            {
                _dbContext.tasks.Remove(task);
                await _dbContext.SaveChangesAsync();
            }

            return task;
        }

        public async Task<TodoItem?> MarkTaskCompletedAsync(Guid guid)
        {
            var task = await _dbContext.tasks
                .FirstOrDefaultAsync(t => t.id == guid);

            if (task != null)
            {
                task.isCompleted = true;
                await _dbContext.SaveChangesAsync();
            }

            return task;
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }



    }
}