using Xamarin.Forms;
using LiaFinder.ViewModels;
using System;
using System.Runtime.InteropServices.ComTypes;
using System.IO;
using SQLite;
using LiaFinder.Models;

namespace LiaFinder.Views
{
    public partial class LiaAdsDetailPage : ContentPage
    {
        public LiaAdsDetailPage()
        {
            InitializeComponent();
            BindingContext = new LiaAdsDetailViewModel();
        }
        private void Apply_To_Ad(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                 await DisplayAlert("Congratulations", "Your application has been sent to the company", "Ok", "Cancel");
            });
        }
    }
}