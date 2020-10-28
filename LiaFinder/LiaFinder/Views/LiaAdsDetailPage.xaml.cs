using Xamarin.Forms;
using LiaFinder.ViewModels;
using System;

namespace LiaFinder.Views
{
    public partial class LiaAdsDetailPage : ContentPage
    {
        public LiaAdsDetailPage()
        {
            InitializeComponent();
            BindingContext = new LiaAdsDetailViewModel();
        }
        private async void OnApplyButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {

                           Text = "Thank you for Applying to x! Press button below to keep looking for lia."
                        },
                        new Button {

                            Text = "RETURN"
                            
                        }
                        
                    }
                }
            });
        }
    }
}