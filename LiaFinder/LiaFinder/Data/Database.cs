using System.Collections.Generic;
using System.Threading.Tasks;
using LiaFinder.Models;
using SQLite;

namespace LiaFinder
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);

            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Ad>().Wait();
        }

        // Changed this from Student to Ad, not used anywhere
        public async Task<List<Ad>> GetAdsAsync()
        {
            return await _database.Table<Ad>().ToListAsync();
        }
        public async Task<List<Ad>> GetAdInformationAsync(Ad myQuery)
        {
          
            
            return await _database.Table<Ad>().ToListAsync();
        }

        public async Task<bool> AddItemAsync(Ad ad)
        {
            await _database.InsertAsync(ad);

            return await Task.FromResult(true);
        }

        public Task<int> SaveItemAsync(User user)
        {
            return _database.InsertAsync(user);
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
