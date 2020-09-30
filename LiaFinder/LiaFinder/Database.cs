using System.Collections.Generic;
using System.Threading.Tasks;
using LiaFinder.Shared.Models;
using SQLite;
using LiaFinder.Tables;

namespace LiaFinder
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<RegUserTable>().Wait();
        }
        public Task<List<Student>> GetStudentAsync()
        {
            return _database.Table<Student>().ToListAsync();
        }
        public Task<int> SaveStudentAsync(Student student)
        {
            return _database.InsertAsync(student);
        }
        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<List<RegUserTable>> GetRegUserTableAsync()
        {
            return _database.Table<RegUserTable>().ToListAsync();
        }
        public Task<List<User>> GetUserAsync()
        {
            return _database.Table<User>().ToListAsync();
        }
        public bool LoginValidate(string userName, string password)
        {
            var data = _database.Table<RegUserTable>();
            var queryData = data.Where(x => x.UserName == userName && x.Password == password).FirstOrDefaultAsync();
            
            if(queryData != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
