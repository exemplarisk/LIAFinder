using System;
using System.Collections.Generic;
using SQLite;
using LiaFinder.Tables;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


// Do we need to get functions from here?
// Is MainPage even used in our scenario?
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
            listView.ItemsSource = await App.Database.GetCompanyAsync();

          
            // kolla user med id 
            // kollar igenom allt i RegUSerTable om någon användare med IsCompany är trur så kommer man på else
            //måste fixa /kolla vem som är inloggad

            
        }

        public bool CheckRole(User regusertable)
        {
            if(regusertable.isCompany == true )
            {
                return true;
            }
            return false;
        }
            

            

   
        
        async void Handle_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new LoginPage());
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }

        async void GetCompany( object sender , EventArgs e)
        {
            App.Current.MainPage = new LiaAdsPage();
        }

        async void Handle_Clickedd(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "student.db3");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<Company>();

            try
            {
                var item = new Company()
                {
               
                    UserId = Id,
                    CompanyName = Company_Name.Text,
                    CompanySubject = Company_Subject.Text,
                    CompanyinternSpots = int.Parse(Company_InternSpots.Text),
                    CompanyLocation = Company_Location.Text,
                
                };
            
                db.Insert(item);
                listView.ItemsSource = await App.Database.GetCompanyAsync();
            }
            catch(Exception x)
            {
                Console.WriteLine(x);
            }

        }
    }
}
