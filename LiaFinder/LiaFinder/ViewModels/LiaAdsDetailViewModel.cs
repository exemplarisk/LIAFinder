using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using LiaFinder.ViewModels;
using Xamarin.Forms;

namespace LiaFinder.ViewModels
{
    [QueryProperty(nameof(adId), nameof(adId))]
    public class LiaAdsDetailViewModel : BaseViewModel
    {
        private string adId;
        private string text;
        private string description;

        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string AdId
        {
            get
            {
                return adId;
            }
            set
            {
                adId = value;
                LoadAdId(value);
            }
        }

        public async void LoadAdId(string adid)
        {
            try
            {
                var ad = await DataStore.GetItemAsync(adid);
                Id = ad.Id;
                Text = ad.Text;
                Description = ad.Description; 
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }


}
