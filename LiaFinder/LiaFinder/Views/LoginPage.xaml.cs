using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiaFinder.Shared.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LiaFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            
            if(user.CheckInformation())
            {
                DisplayAlert("Login", "Login Successful", "Okay");
            }
            else
            DisplayAlert("Error", "Login not correct, empty username or password","Return");
        }
        void RegisterProcedure(object sender, EventArgs e)
        {
            Application.Current.MainPage = new RegistrationPage();
        }
    }
}