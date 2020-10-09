using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace LiaFinder.ViewModels
{
    [QueryProperty(nameof(AdId), nameof(AdId))]
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

        // TODO

        // Implement logic to get values for newly implemented attributes
        // In Ad class.

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

        public async void LoadAdId(string id)
        {
            try
            {
                var ad = await App.Database.GetAdsAsync();
                foreach(var item in ad)
                {
                    Id = item.Id;
                    // Implement this
                    //CompanyName = item.CompanyName;
                    Text = item.Text;
                    Description = item.Description;

                }
                 
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }


}
