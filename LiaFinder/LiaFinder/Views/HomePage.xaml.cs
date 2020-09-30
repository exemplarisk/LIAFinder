using System;
using System.Collections.Generic;

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
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            //await Navigation.PushAsync(new LoginPage());
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
