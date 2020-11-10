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
        public ObservableCollection<Application> Applications { get; }
        public Command LoadApplicationsCommand { get; }

        public HomePageViewModel()
        {
            Applications = new ObservableCollection<Application>();

            LoadApplicationsCommand = new Command(async () => await ExecuteLoadApplicationsCommand());
        }

        public async void OnAppearing()
        {
            await ExecuteLoadApplicationsCommand();
            IsBusy = true;
        }

        async Task ExecuteLoadApplicationsCommand()
        {
            IsBusy = true;

            try
            {
                Applications.Clear();

                var applicatoins = await App.Database.GetApplicationAsync();
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
