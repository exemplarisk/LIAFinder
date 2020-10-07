using Xamarin.Forms;
using LiaFinder.ViewModels;


namespace LiaFinder.Views
{
    public partial class LiaAdsDetailPage : ContentPage
    {
        public LiaAdsDetailPage()
        {
            InitializeComponent();
            BindingContext = new LiaAdsDetailViewModel();
        }
    }
}