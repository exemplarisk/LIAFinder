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
    public partial class LiaAdsPage : ContentPage
    {
        LiaAdsViewModel _viewModel;

        public LiaAdsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new LiaAdsViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        
    }
}