using Xamarin.Forms;
using LiaFinder.ViewModels;
using System;
using System.Runtime.InteropServices.ComTypes;

namespace LiaFinder.Views
{
    public partial class LiaAdsDetailPage : ContentPage
    {
        public LiaAdsDetailPage()
        {
            InitializeComponent();
            BindingContext = new LiaAdsDetailViewModel();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await DisplayAlert("Congratulations!", "Your request has been sent", "Ok", "Cancel");

                if (result)
                {
                    await Shell.Current.GoToAsync("liapage");
                }
            });
        }
    }
}