using System;
using System.IO;
using System.Collections.Generic;
using Xamarin.Forms;
using SQLite;
using LiaFinder.Tables;

namespace LiaFinder.Views
{
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "student.db3");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<User>();

            var item = new User()
            {
                UserId = Id,
                UserName = EntryUserName.Text,
                Password = EntryUserPassword.Text,
                Email = EntryUserEmail.Text,
                isCompany = false,
            };

            db.Insert(item);

            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Congratulations", "User Registration Successful", "Yes", "Cancel");

                if(result)
                {
                    App.Current.MainPage = new NavigationPage(new LoginPage());
                }
            });
                
        }
    }
}
