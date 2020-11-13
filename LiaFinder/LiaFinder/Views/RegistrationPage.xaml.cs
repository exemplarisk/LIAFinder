using System;
using System.IO;
using Xamarin.Forms;
using SQLite;
using LiaFinder.Models;

namespace LiaFinder.Views
{
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        void Onclicked_RegisterUser(object sender, EventArgs e)
        {
            var user = new User()
            {
                UserId = Id,
                UserName = EntryUserName.Text,
                Password = EntryUserPassword.Text,
                Email = EntryUserEmail.Text,
                isCompany = CompanyCheckBox.IsChecked,
                isAdmin = false,
            };

            var userName = user.UserName;
            var isUserNameTaken = Database.IsUserAlreadyRegistered(userName);

            if (user.Email == null || 
                user.Password == null || 
                user.UserName == null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Sorry, Can't do that", "You need to enter valid credentials", "Ok");
                });
            }
            else if (isUserNameTaken)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Sorry, Can't do that", "This username is already in use, " +
                        "please try another username", "Ok");
                });
            }

            else
            {
                Database.InsertNewUser(user);

                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Congratulations", "User Registration Successful", "Ok", "Cancel");

                    if (result)
                    {
                        await Shell.Current.GoToAsync("loginpage");
                    }
                });
            }
        }

        // Used in RegistrationPage.xaml
        private void CompanyCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CompanyCheckBox.IsChecked = true;
        }
    }
}
