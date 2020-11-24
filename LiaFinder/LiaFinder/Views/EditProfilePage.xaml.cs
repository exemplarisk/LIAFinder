using LiaFinder.Models;
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
    public partial class EditProfilePage : ContentPage
    {
        private ProfilePageViewModel _viewModel;
        public EditProfilePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ProfilePageViewModel();
        }

        protected override void OnAppearing()
        {
            _viewModel.OnAppearing();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var currentUser = LoginPage.CurrentUserId;

            if (Update_Email.Text == null &&
                Update_PhoneNumber.Text == null &&
                Update_LinkedIn.Text == null &&
                Update_GitHub.Text == null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Sorry, Can't do that", "You need to atleast update something", "Ok");
                });
            }

            else if (Update_Email.Text == null ||
                Update_PhoneNumber.Text == null ||
                Update_LinkedIn.Text == null ||
                Update_GitHub.Text == null ||
                Update_Email.Text == "" ||
                Update_PhoneNumber.Text == "" ||
                Update_LinkedIn.Text == "" ||
                Update_GitHub.Text == "")
            {

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Error!", "Can't update information with empty fields, try again", "Ok");
                    await Shell.Current.GoToAsync("..");
                });
            }

            else if (Update_Email.Text != null ||
                Update_PhoneNumber.Text != null ||
                Update_LinkedIn.Text != null ||
                Update_GitHub.Text != null)
            {
                var userToUpdate = Database.GetCurrentUser(currentUser);


                userToUpdate.Email = Update_Email.Text;
                userToUpdate.PhoneNumber = Update_PhoneNumber.Text;
                userToUpdate.LinkedInLink = Update_LinkedIn.Text;
                userToUpdate.GitHubLink = Update_GitHub.Text;
                Database.UpdateUser(userToUpdate);

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Success!", "Updated your user credentials", "Ok");
                    await Shell.Current.GoToAsync("..");
                });
            }
        }
    }
}