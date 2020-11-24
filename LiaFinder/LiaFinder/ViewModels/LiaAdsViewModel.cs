using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using LiaFinder.Models;
using LiaFinder.Views;
using Xamarin.Forms;

namespace LiaFinder.ViewModels
{
    class LiaAdsViewModel : BaseViewModel
    {
        private Ad _selectedAd;
        private User _user;


        public ObservableCollection<Ad> Ads { get; }
        public Command LoadAdsCommand { get; }
        public Command<Ad> AdTapped { get; }
        public Command<User> LoadUserProfile { get; }

        public LiaAdsViewModel()
        {
            Title = "Lia Finder";
            Ads = new ObservableCollection<Ad>();
            LoadAdsCommand = new Command(async () => await ExecuteLoadAdsCommand());

            AdTapped = new Command<Ad>(OnAdSelected);
            LoadUserProfile = new Command<User>(LoadProfile);

        }

        public async void OnAppearing()
        {
            await ExecuteLoadAdsCommand();
            IsBusy = true;
            SelectedAd = null;
            User = null;
        }

        public User User
        {
            get => _user;
            set
            {
                SetProperty(ref _user, value);
                LoadProfile(value);
            }
        }

        public Ad SelectedAd
        {
            get => _selectedAd;
            set
            {
                SetProperty(ref _selectedAd, value);
                OnAdSelected(value);
            }
        }


        async Task ExecuteLoadAdsCommand()
        {
            IsBusy = true;

            try
            {
                Ads.Clear();
                var ads = await Database.GetAds();
                foreach (var ad in ads)
                {
                    Ads.Add(ad);
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }


        async void LoadProfile(User user)
        {
            if (user == null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(ProfilePage)}?{nameof(ProfilePageViewModel.Id)}={user.UserId}");
        }

        async void OnAdSelected(Ad ad)
        {
            if(ad == null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(LiaAdsDetailPage)}?{nameof(LiaAdsDetailViewModel.AdId)}={ad.Id}");
        }
    }
}
