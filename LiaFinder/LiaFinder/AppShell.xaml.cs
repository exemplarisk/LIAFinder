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
            Routing.RegisterRoute(nameof(LiaAdsDetailPage), typeof(LiaAdsDetailPage));
            Routing.RegisterRoute(nameof(LiaAdsPage), typeof(LiaAdsPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(EditProfilePage), typeof(EditProfilePage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute("registrationpage", typeof(RegistrationPage));
            Routing.RegisterRoute("newadpage", typeof(NewAdPage));
            Routing.RegisterRoute("adminpage", typeof(AdminPage));
            Routing.RegisterRoute("homepage", typeof(HomePage));
        }
    }
}