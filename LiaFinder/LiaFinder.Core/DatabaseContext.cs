using Microsoft.EntityFrameworkCore;
using LiaFinder.Shared;


namespace LiaFinder.Core
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        private readonly string _dbPath;

        public DatabaseContext(string dbPath)
        {
            dbPath = _dbPath;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }
    }
}
