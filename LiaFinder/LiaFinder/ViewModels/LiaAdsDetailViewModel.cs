using System;
using System.Diagnostics;
using Xamarin.Forms;
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
        private string companyname;
        private string adtitle;
        private string companylocation;
        private string adskills;
        private string companyinternspots;


        public Command ApplyCommand { get; }

        public LiaAdsDetailViewModel()
        {
            ApplyCommand = new Command(SaveApplication);
        }

        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string CompanyName
        {
            get => companyname;
            set => SetProperty(ref companyname, value);
        }
        public string AdTitle
        {
            get => adtitle;
            set => SetProperty(ref adtitle, value);
        }

        public string CompanyLocation
        {
            get => companylocation;
            set => SetProperty(ref companylocation, value);
        }

        public string AdSkills
        {
            get => adskills;
            set => SetProperty(ref adskills, value);
        }

        public string CompanyInternSpots
        {
            get => companyinternspots;
            set => SetProperty(ref companyinternspots, value);
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
       
        public static void SaveApplication()
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "student.db3");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<Models.Application>();

            
            var query = db.Table<User>().Where(u => u != null && u.isLoggedIn.Equals(true)).FirstOrDefault();

            if(query != null)
            {
                Models.Application application = new Models.Application()
                {
                    //TODO: Wire things up here.
                    UserName = query.UserName,
                    Email = query.Email

                };

                db.Insert(application);
            }
        }

        public void LoadAdId(string id)
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
                    CompanyName = myQuery.CompanyName;
                    AdSkills = myQuery.AdSkills;
                    CompanyLocation = myQuery.CompanyLocation;
                    CompanyInternSpots = myQuery.CompanyInternSpots;
                    AdTitle = myQuery.AdTitle;
                } 
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
