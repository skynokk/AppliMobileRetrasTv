using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace RetrasTv
{
    [DesignTimeVisible(false)]
    public partial class StreamPage : ContentPage
    {
        public StreamPage()
        {
            InitializeComponent();

            /* Button retour = new Button();
             retour.Text = "Retour";
             retour.Clicked += new EventHandler(this.Button_Clicked_Retour);

             Label lbl_header = new Label
             {
                 Text = "WebView",
                 HorizontalOptions = LayoutOptions.Center
             };
             WebView webviewStream = new WebView
             {
                 Source = "https://player.twitch.tv/?channel=retrastv",
                 VerticalOptions = LayoutOptions.FillAndExpand
             };
             WebView webviewChat = new WebView
             {
                 Source = "https://www.twitch.tv/embed/retrastv/chat",
                 VerticalOptions = LayoutOptions.FillAndExpand
             };
             this.Content = new StackLayout
             {
                 Children = {
                      webviewStream,
                      webviewChat
                 }
             };
             */
        }

        private void Button_Clicked_Retour(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();        
        }
    }
}
