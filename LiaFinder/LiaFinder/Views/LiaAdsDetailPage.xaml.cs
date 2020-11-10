using Xamarin.Forms;
using LiaFinder.ViewModels;
using System;
using System.Runtime.InteropServices.ComTypes;
using System.IO;
using SQLite;
using LiaFinder.Models;

namespace LiaFinder.Views
{
    public partial class LiaAdsDetailPage : ContentPage
    {
        public LiaAdsDetailPage()
        {
            InitializeComponent();
            BindingContext = new LiaAdsDetailViewModel();
        }
        private void Apply_To_Ad(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "student.db3");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<Models.Application>();

            var user = db.Table<User>().Where(u => u.isLoggedIn.Equals(true)).FirstOrDefault();

            var company = CompanyName;
             var companyString = company.ToString();

            var application = new Models.Application()
            {

                UserName = user.UserName,
                Email = user.Email,
                Company = companyString
            };


            if(application == null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Error", "Can't do that", "Ok");
                });
            }
            else
            {
                db.Insert(application);
            }
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Congratulations", "Your application has been sent to the company", "Ok", "Cancel");
            });
        }
    }
}