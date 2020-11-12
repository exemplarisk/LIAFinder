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
            //TODO: Remove this and write function to insert new user in database in database.cs
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "student.db3");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<User>();

            var user = new User()
            {
                UserId = Id,
                UserName = EntryUserName.Text,
                Password = EntryUserPassword.Text,
                Email = EntryUserEmail.Text,
                isCompany = CompanyCheckBox.IsChecked,
                isAdmin = false,
            };


            // TODO: Make sure you can't register with empty credentials
            var entry = user.ToString();

            if (entry == null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Whoops", "Something Went Wrong", "Ok");
                });
            }

            else
            {
                db.Insert(user);
            }

            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Congratulations", "User Registration Successful", "Ok", "Cancel");

                if(result)
                {
                    await Shell.Current.GoToAsync("loginpage"); 
                }
            });
                
        }

        private void CompanyCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CompanyCheckBox.IsChecked = true;
        }
    }
}
