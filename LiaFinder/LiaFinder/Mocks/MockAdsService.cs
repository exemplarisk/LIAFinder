using LiaFinder.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using LiaFinder.Models;
using System.Threading.Tasks;
using System.Linq;

namespace LiaFinder.Mocks
{
    public class MockAdsService : IDataStore<Ad>
    {
        private readonly List<Ad> ads;

        public MockAdsService()
        {
            ads = new List<Ad>()
            {
                new Ad { Id = Guid.NewGuid().ToString(), Text = "Front-End Sökes", Description="This is a really dummy dummy text that illustrates how text could be displayed in this Ad." },
                new Ad { Id = Guid.NewGuid().ToString(), Text = "Back-End Sökes", Description="This is a really dummy dummy text that illustrates how text could be displayed in this Ad" },
                new Ad { Id = Guid.NewGuid().ToString(), Text = "Driven Utvecklare", Description="This is a really dummy dummy text that illustrates how text could be displayed in this Ad" },
                new Ad { Id = Guid.NewGuid().ToString(), Text = "Burger Flipper", Description="This is a really dummy dummy text that illustrates how text could be displayed in this Ad" },
                new Ad { Id = Guid.NewGuid().ToString(), Text = "Engagerad Student", Description="This is a really dummy dummy text that illustrates how text could be displayed in this Ad "},
                new Ad { Id = Guid.NewGuid().ToString(), Text = "Kodare sökes", Description="This is a really dummy dummy text that illustrates how text could be displayed in this Ad" }
            };
        }
        public async Task<bool> AddItemAsync(Ad item)
        {
            ads.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Ad item)
        {
            var oldItem = ads.Where((Ad arg) => arg.Id == item.Id).FirstOrDefault();
            ads.Remove(oldItem);
            ads.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = ads.Where((Ad arg) => arg.Id == id).FirstOrDefault();
            ads.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Ad> GetItemAsync(string id)
        {
            return await Task.FromResult(ads.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Ad>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(ads);
        }
    }
}
