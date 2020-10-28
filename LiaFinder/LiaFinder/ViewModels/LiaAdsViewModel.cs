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
        

        public ObservableCollection<Ad> Ads { get; }
        public Command LoadAdsCommand { get; }
        public Command AddAdCommand { get; }
        public Command<Ad> AdTapped { get; }

        public LiaAdsViewModel()
        {
            Title = "Lia Finder";
            Ads = new ObservableCollection<Ad>();
            LoadAdsCommand = new Command(async () => await ExecuteLoadAdsCommand());

            AdTapped = new Command<Ad>(OnAdSelected);

            AddAdCommand = new Command<Ad>(NewAdd);

        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedAd = null;
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
                var ads = await App.Database.GetAdsAsync();
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

        private async void NewAdd(object obj)
        {
            await Shell.Current.GoToAsync("newadpage");
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
