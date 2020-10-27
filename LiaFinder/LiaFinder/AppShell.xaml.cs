using Xamarin.Forms;
using LiaFinder.Views;
namespace LiaFinder
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LiaAdsDetailPage), typeof(LiaAdsDetailPage));
            Routing.RegisterRoute("liadetails", typeof(LiaAdsDetailPage));
            Routing.RegisterRoute("liapage", typeof(LiaAdsPage));
            Routing.RegisterRoute("loginpage", typeof(LoginPage));
            Routing.RegisterRoute("registrationpage", typeof(RegistrationPage));
            Routing.RegisterRoute("newadpage", typeof(NewAdPage));
            Routing.RegisterRoute("adminpage", typeof(AdminPage));

        }
    }
}