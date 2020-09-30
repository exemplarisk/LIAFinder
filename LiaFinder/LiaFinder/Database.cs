using System.Collections.Generic;
using System.Threading.Tasks;
using LiaFinder.Shared.Models;
using SQLite;

namespace LiaFinder
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Student>().Wait();
        }
        public Task<List<Student>> GetStudentAsync()
        {
            return _database.Table<Student>().ToListAsync();
        }
        public Task<int> SaveStudentAsync(Student student)
        {
            return _database.InsertAsync(student);
        }
        public Task<List<User>> GetUserAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

    }
}
