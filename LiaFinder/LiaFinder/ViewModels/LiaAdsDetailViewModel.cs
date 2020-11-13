using System;
using System.Diagnostics;
using Xamarin.Forms;
using System.IO;
using SQLite;
using LiaFinder.Models;
using LiaFinder.Views;

namespace LiaFinder.ViewModels
{
    [QueryProperty(nameof(AdId), nameof(AdId))]
    public class LiaAdsDetailViewModel : BaseViewModel
    {
        #region Private Attributes
        private Guid _userid;
        private string _adId;
        private string _text;
        private string _companyname;
        private string _adtitle;
        private string _companylocation;
        private string _adskills;
        private string _companyinternspots;

        private User _user;
        #endregion

        public Command ApplyCommand { get; }

        public LiaAdsDetailViewModel()
        {
            ApplyCommand = new Command(SaveApplication);
        }

        public string Id { get; set; }

        public Guid UserId
        {
            get
            {
                if(_userid != null)
                {
                    _userid = LoginPage.CurrentUserId;
                }
                return _userid;
            }
        }

        public User User
        {
            get
            {
                if(_user == null)
                {
                    _user = Database.GetCurrentUser(UserId);
                }
                return _user;
            }
        }

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public string CompanyName
        {
            get => _companyname;
            set => SetProperty(ref _companyname, value);
        }
        public string AdTitle
        {
            get => _adtitle;
            set => SetProperty(ref _adtitle, value);
        }

        public string CompanyLocation
        {
            get => _companylocation;
            set => SetProperty(ref _companylocation, value);
        }

        public string AdSkills
        {
            get => _adskills;
            set => SetProperty(ref _adskills, value);
        }

        public string CompanyInternSpots
        {
            get => _companyinternspots;
            set => SetProperty(ref _companyinternspots, value);
        }


        public string AdId
        {
            get
            {
                return _adId;
            }
            set
            {
                _adId = value;
                LoadAdId(value);
            }
        }
       
        public void SaveApplication()
        {   
            if(User != null)
            {
                Models.Application application = new Models.Application()
                {
                    UserName = User.UserName,
                    Email = User.Email,
                    Company = CompanyName
                };

                Database.InsertApplication(application);
            }
        }

        public void LoadAdId(string id)
        {
            try
            {
                // TODO: Should change this aswell
                var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "student.db3");
                var db = new SQLiteConnection(dbpath);

                var ad = db.Table<Ad>().Where(u => u.Id.Equals(id)).FirstOrDefault();

                if (ad != null)
                {
                    Id = ad.Id;
                    Text = ad.Text;
                    CompanyName = ad.CompanyName;
                    AdSkills = ad.AdSkills;
                    CompanyLocation = ad.CompanyLocation;
                    CompanyInternSpots = ad.CompanyInternSpots;
                    AdTitle = ad.AdTitle;
                } 
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
