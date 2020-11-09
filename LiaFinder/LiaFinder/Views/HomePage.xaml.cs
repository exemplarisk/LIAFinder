using System;
using LiaFinder.Models;
using System.IO;
using Xamarin.Forms;

namespace LiaFinder.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //listView.ItemsSource = await App.Database.GetCompanyAsync();

            //måste fixa /kolla vem som är inloggad
        }

        // fixa så att detta lägga i databas klassen eller??
        public bool CheckRole(User user)
        {
            if(user.isCompany == true)
            {
                return true;
            }
            return false;
        }

        public bool CheckIfAdmin(User user)
        {
            if (user.isAdmin == false)
            {
                return false;
            }
            return true;
        }
    }
}
