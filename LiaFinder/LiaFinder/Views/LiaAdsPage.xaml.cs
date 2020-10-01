using LiaFinder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LiaFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LiaAdsPage : ContentPage
    {
        public LiaAdsPage()
        {
            base.OnAppearing();
            _adsViewModel.OnAppearing();
        }

        LiaAdsViewModel _adsViewModel;
        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = _adsViewModel = new LiaAdsViewModel();
        }

        
    }
}