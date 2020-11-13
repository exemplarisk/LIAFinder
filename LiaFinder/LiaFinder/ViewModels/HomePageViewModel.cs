using LiaFinder.Models;
using LiaFinder.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LiaFinder.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<Models.Application> Applications { get; }
        public Command LoadApplicationsCommand { get; }
        public Command AddAdCommand { get; }

        public HomePageViewModel()
        {
            Applications = new ObservableCollection<Models.Application>();

            LoadApplicationsCommand = new Command(async () => await ExecuteLoadApplicationsCommand());
            AddAdCommand = new Command<Ad>(NavigateToNewAdPage);
        }

        public async void OnAppearing()
        {
            await ExecuteLoadApplicationsCommand();
            IsBusy = true;
        }

        private async void NavigateToNewAdPage(object obj)
        {
            await Shell.Current.GoToAsync("newadpage");
        }

        async Task ExecuteLoadApplicationsCommand()
        {
            IsBusy = true;

            try
            {
                Applications.Clear();

                var applicatoins = await Database.GetApplicationAsync(LoginPage.CurrentUserId);
                foreach(var application in Applications)
                {
                    Applications.Add(application);
                }
                IsBusy = false;
            }
            catch(Exception e) 
            {
                Debug.WriteLine(e);
            }
        }
    }
}
