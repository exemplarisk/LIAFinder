using LiaFinder.Models;
using LiaFinder.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LiaFinder.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    class ProfilePageViewModel : BaseViewModel
    {
        private Guid _id;
        private string _email;
        private string _username;
        private string _phonenumber;

        public ObservableCollection<User> UserInformation { get; }

        public ProfilePageViewModel()
        {
            UserInformation = new ObservableCollection<User>();
        }
        public Guid Id
        {
            get
            {
                if(_id != null)
                {
                    _id = LoginPage.CurrentUserId;
                }
                return _id;
            }
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string UserName
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string PhoneNumber
        {
            get => _phonenumber;
            set => SetProperty(ref _phonenumber, value);
        }

        public void OnAppearing()
        {
            try
            {
                UserInformation.Clear();
                var currentUser = Database.GetCurrentUserInformation(Id);
                foreach (var user in currentUser)
                {
                    Email = user.Email;
                    UserName = user.UserName;
                    PhoneNumber = user.PhoneNumber;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
