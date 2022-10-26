using Microsoft.EntityFrameworkCore;
using Teste2022_1;

namespace TesteWaProject.Repository.Context
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public string DbPath { get; }
        public TodoContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "todo.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
    }
}
