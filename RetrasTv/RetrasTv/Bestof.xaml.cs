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
        public class video_recup
        {
            [JsonProperty(PropertyName = "id")]
            public string id { get; set; }

            [JsonProperty(PropertyName = "url")]
            public string url { get; set; }

            [JsonProperty(PropertyName = "embed_url")]
            public string embed_url { get; set; }

            [JsonProperty(PropertyName = "broadcaster_id")]
            public string broadcaster_id { get; set; }

            [JsonProperty(PropertyName = "broadcaster_name")]
            public string broadcaster_name { get; set; }

            [JsonProperty(PropertyName = "creator_id")]
            public string creator_id { get; set; }

            [JsonProperty(PropertyName = "creator_name")]
            public string creator_name { get; set; }

            [JsonProperty(PropertyName = "video_id")]
            public string video_id { get; set; }

            [JsonProperty(PropertyName = "game_id")]
            public string game_id { get; set; }

            [JsonProperty(PropertyName = "language")]
            public string language { get; set; }

            [JsonProperty(PropertyName = "title")]
            public string title { get; set; }

            [JsonProperty(PropertyName = "view_count")]
            public string view_count { get; set; }

            [JsonProperty(PropertyName = "created_at")]
            public string created_at { get; set; }

            [JsonProperty(PropertyName = "thumbnail_url")]
            public string thumbnail_url { get; set; }
        }

        public Bestof()
        {
            InitializeComponent(); var task = Task.Run<string>(() =>
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