using System;
using LiaFinder.Models;
using System.IO;
using Xamarin.Forms;
using LiaFinder.ViewModels;
using SQLite;

namespace LiaFinder.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
            

            BindingContext = new HomePageViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ApplicationsList.ItemsSource = await Database.GetApplicationAsync();
        }

        // fixa så att detta lägga i databas klassen eller??
        

        public bool CheckIfAdmin(User user)
        {
            if (user.isAdmin == false)
            {
                return false;
            }
            return true;
        }


        private void Logout_Clicked(object sender, System.EventArgs e)
        {
            //TODO: This should check the GetCurrentUser() in database.cs
            var id = LoginPage.CurrentUserId;

            var userToLogout = Database.LogoutUser(id);

            if (userToLogout)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Shell.Current.GoToAsync("..");
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Something went wrong", "Could not perform the requested action", "Ok");
                });
            }
        }
    }
}
