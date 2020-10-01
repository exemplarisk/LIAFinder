using System;
using System.Collections.Generic;
using SQLite;
using LiaFinder.Tables;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


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
            listView.ItemsSource = await App.Database.GetCompanyTableAsync();
        }
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            //await Navigation.PushAsync(new LoginPage());
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }

        async void Handle_Clickedd(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "student.db3");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<CompanyTable>();

            try
            { 

            var item = new CompanyTable()
            {
                CompanyName = Company_Name.Text,
                CompanySubject = Company_Subject.Text,
                CompanyinternSpots = int.Parse(Company_InternSpots.Text),
                CompanyLocation = Company_Location.Text

            };
            
            db.Insert(item);
            listView.ItemsSource = await App.Database.GetCompanyTableAsync();
            }
            catch(Exception exception)
            {
               
            }


        }
    }
}
