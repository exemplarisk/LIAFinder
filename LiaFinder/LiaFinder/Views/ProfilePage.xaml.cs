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
    public partial class ProfilePage : ContentPage
    {
        private ProfilePageViewModel _viewModel;
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ProfilePageViewModel();
        }

        protected override void OnAppearing()
        {
            _viewModel.OnAppearing();
        }

        private async void Edit_Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(EditProfilePage));
        }
    }
}