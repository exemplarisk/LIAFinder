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

        async void OnClicked_Logout(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new LoginPage());
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }

        async void GetCompany( object sender , EventArgs e)
        {
            App.Current.MainPage = new LiaAdsPage();
        }

        //async void OnClicked_AddCompany(object sender, EventArgs e)
        //{
        //    var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "student.db3");
        //    var db = new SQLiteConnection(dbpath);
        //    db.CreateTable<Ad>();

        //    try
        //    {
        //        var companyAd = new Ad()
        //        {
        //            UserId = Id,
        //            CompanyName = Company_Name.Text,
        //            CompanySubject = Company_Subject.Text,
        //            CompanyinternSpots = int.Parse(Company_InternSpots.Text),
        //            CompanyLocation = Company_Location.Text,
        //        };
            
        //        db.Insert(companyAd);
        //        listView.ItemsSource = await App.Database.GetCompanyAsync();
        //    }
        //    catch(Exception x)
        //    {
        //        Console.WriteLine(x);
        //    }
        //}
    }
}
