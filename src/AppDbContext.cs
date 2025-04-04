using Microsoft.EntityFrameworkCore;

namespace TaskManagerApp
{

    class AppDbContext : DbContext
    {
        public DbSet<TodoItem> tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Database/tasks.db");
        }
    }
}