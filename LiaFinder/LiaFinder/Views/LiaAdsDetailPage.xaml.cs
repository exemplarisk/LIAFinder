using Xamarin.Forms;
using LiaFinder.ViewModels;

namespace LiaFinder.Views
{
    public partial class LiaAdsDetailPage : ContentPage
    {
        public LiaAdsDetailPage()
        {
            //https://stackoverflow.com/questions/17853898/the-name-initializecomponent-does-not-exist-in-the-current-context-cannot-get
            InitializeComponent();
            BindingContext = new LiaAdsDetailPage();
        }
    }
}