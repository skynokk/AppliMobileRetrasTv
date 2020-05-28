using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RetrasTv
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bestof : ContentPage
    {
        public Bestof()
        {
            InitializeComponent(); 
            var task = Task.Run<string>(() =>
            {
                return DownloadLibraryAsync();
            });

            JObject jsonVal = JObject.Parse(task.Result) as JObject;

            int i = -1;
            foreach (var valeur in jsonVal["items"])
            {
                //i++;
                //string urlId = (string)jsonVal["items"][i]["id"]["videoId"];

                //WebView webView = new WebView
                //{
                //    Source = new UrlWebViewSource
                //    {
                //        Url = "https://www.youtube.com/watch?v=" + urlId,
                //    },
                //    VerticalOptions = LayoutOptions.FillAndExpand,
                //    HorizontalOptions = LayoutOptions.Center
                //};

                //vidStackLayout.Children.Add(webView);

                i++;
                string urlId = (string)jsonVal["items"][i]["snippet"]["thumbnails"]["medium"]["url"];

                WebView webView = new WebView
                {
                    Source = new UrlWebViewSource
                    {
                        Url = urlId,
                    },
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.Center
                };
                vidStackLayout.Children.Add(webView);

            }
        }

        static async Task<string> DownloadLibraryAsync()
        {
            string page = "https://www.googleapis.com/youtube/v3/search?key=AIzaSyDUvJu0o6d3uBs2btHd0VWNH0qfM-I6YQY&channelId=UCdsZA5bCTR6lDU4pce-ohxw&order=date&part=snippet&type=video,id&maxResults=50";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(page))
                {
                    using (HttpContent content = response.Content)
                    {
                        string result = await content.ReadAsStringAsync();
                        return result;
                    }
                }
            }
        }

        private void Button_Clicked_Retour(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }
    }
}