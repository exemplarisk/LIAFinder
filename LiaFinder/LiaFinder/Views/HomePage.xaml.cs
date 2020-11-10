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
            ApplicationsList.ItemsSource = await App.Database.GetApplicationAsync();
        }

        // fixa så att detta lägga i databas klassen eller??
        public bool CheckRole(User user)
        {
            if(user.isCompany == true)
            {
                return true;
            }
            return false;
        }

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
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "student.db3");
            var db = new SQLiteConnection(dbpath);

            var userToLogout = db.Table<User>().Where(u => u.isLoggedIn.Equals(true)).FirstOrDefault();

            if (userToLogout != null)
            {
                userToLogout.isLoggedIn = false;
            }

            var updatedRows = db.Update(userToLogout, typeof(User));

            Device.BeginInvokeOnMainThread(async () =>
            {
                await Shell.Current.GoToAsync("..");
            });
        }
    }
}
