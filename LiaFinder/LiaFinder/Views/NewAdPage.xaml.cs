using Xamarin.Forms;
using LiaFinder.Models;
using LiaFinder.ViewModels;


namespace LiaFinder.Views
{
    public partial class NewAdPage : ContentPage
    {
        public Ad Ad { get; set; }
        public NewAdPage()
        {
            InitializeComponent();
            BindingContext = new NewAdViewModel();
        }
    }
}