using System.Collections.Generic;
using System.Threading.Tasks;
using LiaFinder.Shared.Models;
using SQLite;
using LiaFinder.Tables;
using LiaFinder.Interfaces;

namespace LiaFinder
{
    public class Database 
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Company>().Wait();
        }

        public async Task<List<Student>> GetAdsAsync()
        {
            return await _database.Table<Student>().ToListAsync();
        }

        public Task<int> SaveItemAsync(Student student)
        {
            return _database.InsertAsync(student);
        }

        // Save this in the meantime, this works, needs to be generic though
        public Task<List<Company>> GetCompanyAsync()
        {
            return _database.Table<Company>().ToListAsync();
        }

        public Task<List<User>> GetUserAsync()
        {
            return _database.Table<User>().ToListAsync();
        }
   
        public bool CheckRole (User user)
        {
            if (user.isCompany == false)
            {
                return false;
            }
            return true;
        }
        public bool LoginValidate(string userName, string password)
        {
            var data = _database.Table<User>();
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
