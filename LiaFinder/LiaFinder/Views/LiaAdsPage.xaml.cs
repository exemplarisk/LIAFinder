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
            AdSearcher.IsVisible = false;
            
        }

        private void Logout_Clicked(object sender, System.EventArgs e)
        {
            var id = LoginPage.CurrentUserId;
            var userToLogout = Database.LogoutUser(id);

           if(userToLogout)
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
                    await DisplayAlert("Something went wrong", "Couldn't perform the requested action", "Ok");
                });
            }
        }

        // Used in LiaAdsPage To search ads
        private void OnTextChanged(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            AdsListView.ItemsSource = Database.SearchAd(searchBar.Text);
<<<<<<< HEAD
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (AdSearcher.IsVisible)
            {
                AdSearcher.IsVisible = false;
            }
            else
                AdSearcher.IsVisible = true;
=======
>>>>>>> deb5a2cabd320ea8f8816931d20ea74b96379197
        }
    }
}