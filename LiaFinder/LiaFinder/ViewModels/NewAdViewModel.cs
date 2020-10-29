using System;
using Xamarin.Forms;
using LiaFinder.Models;
using LiaFinder;
using System.IO;
using SQLite;

namespace LiaFinder.ViewModels
{
    public class NewAdViewModel : BaseViewModel
    {
        private string text;
        private string description;
        private string companyname;
        private string adtitle;
        private string adskills;
        private string companylocation;
        private string companyinternspots;

        public NewAdViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(companyname)
                && !String.IsNullOrWhiteSpace(adtitle)
                && !String.IsNullOrWhiteSpace(adskills)
                && !String.IsNullOrWhiteSpace(companylocation)
                && !String.IsNullOrWhiteSpace(companyinternspots);
        }


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


        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "student.db3");
            var db = new SQLiteConnection(dbpath);  
            db.CreateTable<Ad>();

            Ad newAd = new Ad()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                CompanyName = CompanyName,
                AdTitle = AdTitle,
                AdSkills = AdSkills,
                CompanyLocation = CompanyLocation,
                CompanyInternSpots = CompanyInternSpots
            };

            db.Insert(newAd);
            //listView.ItemsSource = await App.Database.GetCompanyAsync();

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
