using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using SQLite;
using LiaFinder.Models;

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

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        async void Register(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync("registrationpage");

         }

        async void Login(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "student.db3");
            var db = new SQLiteConnection(dbpath);
            var user = db.Table<User>().Where(u => u.UserName.Equals(Entry_Username.Text) && u.Password.Equals(Entry_Password.Text)).FirstOrDefault();

                if (user != null)    
                {
                    CurrentUserId = user.UserId;

                    user.isLoggedIn = true;
                    
                    
                    var updatedRows = db.Update(user, typeof(User));


                    var isCompany = MyHomePage.CheckRole(user);

                    var isSchool = MyHomePage.CheckIfAdmin(user);

                    if(isCompany)
                    {
                           await Shell.Current.GoToAsync("homepage");
                    }

                    else if(isSchool)
                    {
                        await Shell.Current.GoToAsync("adminpage");
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
                    var result = await DisplayAlert("Error", "Invalid Login or password", "Ok", "Cancel");

                    if(result)
                    {
                        await Shell.Current.GoToAsync("loginpage");
                    }
                });
            }
        }
    }
}