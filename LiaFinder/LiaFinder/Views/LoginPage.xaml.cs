using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using SQLite;
using LiaFinder.Models;

namespace LiaFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        public static Guid CurrentUserId;

        public LoginPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        async void Register(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync("registrationpage");

        }

        async void Login(object sender, EventArgs e)
        {

            var user = Database.ValidateUserLogin(Entry_Username.Text, Entry_Password.Text);

                if (user != null)    
                {
                    CurrentUserId = user.UserId;

                    user.isLoggedIn = true;
                    
                    Database.UpdateUser(user);

                    if(user.isCompany)
                    {
                           await Shell.Current.GoToAsync("homepage");
                    }

                    else if(user.isAdmin)
                    {
                        await Shell.Current.GoToAsync("adminpage");
                    }

                    else
                    {
                        await Shell.Current.GoToAsync("liapage");
                    } 
                }

                else
                {
                    Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await DisplayAlert("Error", "Invalid Login or password", "Ok", "Cancel");

                    if(result)
                    {
                        await Shell.Current.GoToAsync("loginpage");
                    }
                });
            }
        }
    }
}