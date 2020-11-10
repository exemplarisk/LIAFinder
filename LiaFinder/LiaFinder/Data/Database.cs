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
            _database.CreateTableAsync<Application>().Wait();
        }

        //TODO: Add function to insert Application to DB

        public async Task<bool> InsertApplicationAsync(Application application)
        {
            await _database.InsertAsync(application);
            return await Task.FromResult(true);
        }

        public async Task<List<Application>> GetApplicationAsync()
        {
            return await _database.Table<Application>().ToListAsync();
        }

        public async Task<List<Ad>> GetAdsAsync()
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
    }
}
