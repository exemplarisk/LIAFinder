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
        void Onclicked_RegisterStudent(object sender, System.EventArgs e)
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
                isAdmin = false,
            };


            // TODO: Make sure you can't register with empty credentials
            var entry = item.ToString();

            if (entry == null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Whoops", "Something Went Wrong", "Ok");
                });
            }

            else
            {
                db.Insert(item);
            }

            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Congratulations", "User Registration Successful", "Yes", "Cancel");

                if(result)
                {
                    await Shell.Current.GoToAsync("loginpage"); 
                }
            });
                
        }
    }
}
