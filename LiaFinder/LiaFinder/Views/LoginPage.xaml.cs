using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LiaFinder.Tables;
using System.IO;
using SQLite;
using LiaFinder.Views;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LiaFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        
        HomePage MyHomePage = new HomePage();

        public Guid CurrentUserId;

        public LoginPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetUserAsync();
        }

        async void Register(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync("registrationpage");

         }

        async void Login(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "student.db3");
            var db = new SQLiteConnection(dbpath);
            var myQuery = db.Table<User>().Where(u => u.UserName.Equals(Entry_Username.Text) && u.Password.Equals(Entry_Password.Text)).FirstOrDefault();

                if (myQuery != null)    
                {
                    CurrentUserId = myQuery.UserId;

                    var checkRole = MyHomePage.CheckRole(myQuery);

                    if(checkRole == true)
                    {
                    await Shell.Current.GoToAsync("homepage");
                    }
                    else
                    {
                        await Shell.Current.GoToAsync("liapage");
                    }
                }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Error", "Invalid Login or password..", "Yes", "Back");

                    if(result)
                    {
                        App.Current.MainPage = new NavigationPage(new LoginPage());
                    }
                    else
                    {
                        App.Current.MainPage = new NavigationPage(new LoginPage());
                    }
                });
            }
        }
    }
}