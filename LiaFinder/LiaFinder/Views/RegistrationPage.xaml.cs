using System;
using System.IO;
using Xamarin.Forms;
using SQLite;
using LiaFinder.Models;
using System.Text.RegularExpressions;

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
                PhoneNumber = EntryUserPhone.Text,
                isCompany = CompanyCheckBox.IsChecked,
                isAdmin = false,
            };

            var isPhoneNumberValid = Regex.IsMatch(EntryUserPhone.Text, @"[a-zA-Z]");
            var userName = user.UserName;
            var isUserNameTaken = Database.IsUserAlreadyRegistered(userName);

            if (user.Email == null || 
                user.Password == null || 
                user.UserName == null || 
                user.PhoneNumber == null)
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
            else if(isPhoneNumberValid)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Sorry, Can't do that", "Phone number can't contain letters..., " +
                        "please try again", "Ok");
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
                        await Shell.Current.GoToAsync(nameof(LoginPage));
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
