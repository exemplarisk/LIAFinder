using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using SQLite;
using LiaFinder.Models;

namespace LiaFinder.ViewModels
{
    [QueryProperty(nameof(AdId), nameof(AdId))]
    public class LiaAdsDetailViewModel : BaseViewModel
    {
        private string adId;
        private string text;
        private string description;

        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        // TODO

        // Implement logic to get values for newly implemented attributes
        // In Ad class.

        public string AdId
        {
            get
            {
                return adId;
            }
            set
            {
                adId = value;
                LoadAdId(value);
            }
        }

        public async void LoadAdId(string id)
        {
            try
            {

                var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "student.db3");
                var db = new SQLiteConnection(dbpath);

                var myQuery = db.Table<Ad>().Where(u => u.Id.Equals(id)).FirstOrDefault();

                if (myQuery != null)
                {

                        Id = myQuery.Id;
                        Text = myQuery.Text;
                        Description = myQuery.Description;
 

                } 
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
