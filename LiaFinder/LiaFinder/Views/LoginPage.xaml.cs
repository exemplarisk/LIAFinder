using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiaFinder.Shared.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LiaFinder.Tables;
using LiaFinder.Views;
using System.IO;

namespace LiaFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        Database _database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "student.db3"));
        public LoginPage()
        {
            InitializeComponent();
        }

        void SignInProcedure(object sender, EventArgs e)
        {
           
            if(Entry_Username.Text != null && Entry_Password.Text != null)
            {
                bool validData = _database.LoginValidate(Entry_Username.Text, Entry_Password.Text);
                if(validData)
                {
                    DisplayAlert("Success", "Logged in as user: " + Entry_Username.Text, "HOME");
                    Application.Current.MainPage = new MainPage();
                    
                }
                
            }
            else
            {
                
                DisplayAlert("Error", "Login not correct, Wrong username or password", "Return");
            }
        }
        void RegisterProcedure(object sender, EventArgs e)
        {
            Application.Current.MainPage = new RegistrationPage();
        }
    }
}