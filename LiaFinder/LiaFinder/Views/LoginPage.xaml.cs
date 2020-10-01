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
        Database _database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "student.db3"));

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
            listView.ItemsSource = await App.Database.GetRegUserTableAsync();




        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new RegistrationPage());
            //await Navigation.PushAsync(new RegistrationPage());
        }

        async void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "student.db3");
            var db = new SQLiteConnection(dbpath);
            var myQuery = db.Table<RegUserTable>().Where(u => u.UserName.Equals(Entry_Username.Text) && u.Password.Equals(Entry_Password.Text)).FirstOrDefault();

       

                if (myQuery != null)    
                {

                CurrentUserId = myQuery.UserId;

                var checkRole = MyHomePage.CheckRole(myQuery);

                if(checkRole == true)
                {
                    App.Current.MainPage = new HomePage();
                }
                else
                {
                    App.Current.MainPage = new HomePage();
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
                        //await Navigation.PushAsync(new LoginPage());
                    }
                    else
                    {
                  
                        App.Current.MainPage = new NavigationPage(new LoginPage());
                        //await Navigation.PushAsync(new LoginPage());
                    }
                });
            }
        }
    }
}