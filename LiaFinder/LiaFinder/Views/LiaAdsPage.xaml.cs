using LiaFinder.Models;
using LiaFinder.ViewModels;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

namespace LiaFinder.Views
{
    public partial class LiaAdsPage : ContentPage
    {
       readonly LiaAdsViewModel _viewModel;

        public LiaAdsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new LiaAdsViewModel();
        }

        protected override void OnAppearing()
        {
            _viewModel.OnAppearing();
        }

        private void Logout_Clicked(object sender, System.EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "student.db3");
            var db = new SQLiteConnection(dbpath);

            var userToLogout = db.Table<User>().Where(u => u.isLoggedIn.Equals(true)).FirstOrDefault();

           if(userToLogout != null)
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