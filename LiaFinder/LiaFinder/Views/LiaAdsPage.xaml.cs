using LiaFinder.ViewModels;
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
            
        }
    }
}