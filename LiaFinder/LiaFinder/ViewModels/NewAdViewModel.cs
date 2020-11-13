using System;
using Xamarin.Forms;
using LiaFinder.Models;
using LiaFinder;
using System.IO;
using SQLite;
using LiaFinder.Views;

namespace LiaFinder.ViewModels
{
    public class NewAdViewModel : BaseViewModel
    {
        private string text;
        private string adtitle;
        private string adskills;
        private string companylocation;
        private string companyinternspots;
        private Guid userid;
        private User _company;

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public NewAdViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        public Guid UserId
        {
            get
            {
                if(userid != null)
                {
                    userid = LoginPage.CurrentUserId;
                }
                return userid;
            }
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string AdTitle
        {
            get => adtitle;
            set => SetProperty(ref adtitle, value);
        }

        public string AdSkills
        {
            get => adskills;
            set => SetProperty(ref adskills, value);
        }

        public string CompanyLocation
        {
            get => companylocation;
            set => SetProperty(ref companylocation, value);
        }

        public string CompanyInternSpots
        {
            get => companyinternspots;
            set => SetProperty(ref companyinternspots, value);

        }

        public User Company
        { 
            get
            {
                if(_company == null)
                {
                    _company = Database.GetCurrentUser(UserId);
                }

                return _company;
            }
        }


        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }


        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(adtitle)
                && !String.IsNullOrWhiteSpace(adskills)
                && !String.IsNullOrWhiteSpace(companylocation)
                && !String.IsNullOrWhiteSpace(companyinternspots);
        }       
        private async void OnSave()
        {
            Ad newAd = new Ad()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                CompanyName = Company.UserName,
                AdTitle = AdTitle,
                AdSkills = AdSkills,
                CompanyLocation = CompanyLocation,
                CompanyInternSpots = CompanyInternSpots
            };

            Database.InsertAd(newAd);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
