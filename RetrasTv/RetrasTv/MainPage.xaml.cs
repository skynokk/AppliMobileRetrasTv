
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace RetrasTv
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked_Stream(object sender, EventArgs e)
        {
            ((Button)sender).Text = $"Ouverture du stream";
            ((Button)sender).IsEnabled = false;
            App.Current.MainPage = new StreamPage();
        }

        private void Button_Clicked_Planning(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_Info(object sender, EventArgs e)
        {
            ((Button)sender).Text = $"Description";
            ((Button)sender).IsEnabled = false;
            App.Current.MainPage = new Description();
        }

        private void Button_Clicked_Event(object sender, EventArgs e)
        {

        }
    }
}
