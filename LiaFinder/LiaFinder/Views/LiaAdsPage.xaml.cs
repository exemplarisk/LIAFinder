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
        private void AdSearcher_SearchButtonPressed(object sender, EventArgs e)
        {
            var query = AdSearcher.Text;
            var adResults = Database.SearchAd(query);

            AdsListView.ItemsSource = adResults;
        }
    }
}