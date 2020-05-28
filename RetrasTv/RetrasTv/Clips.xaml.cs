using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RetrasTv
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Clips : ContentPage
    {
        public class clip_recup
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

        public Clips()
        {
            InitializeComponent();

            var task = Task.Run<string>(() =>
            {
                return DownloadLibraryAsync();
            });

            JObject jsonVal = JObject.Parse(task.Result) as JObject;

            /* string val = (string)jsonVal["data"][0]["embed_url"];
             webViewStream.Source = val;
             val = (string)jsonVal["data"][1]["embed_url"];
             webViewStream2.Source = val;
             val = (string)jsonVal["data"][2]["embed_url"];
             webViewStream3.Source = val;
             val = (string)jsonVal["data"][3]["embed_url"];
             webViewStream4.Source = val;*/

            int i = -1;
            //foreach (var valeur in jsonVal["data"])
            //{
                //i++;
                //WebView webView = new WebView
                //{
                //    Source = new UrlWebViewSource
                //    {
                //        Url = (string)jsonVal["data"][i]["embed_url"] + "&autoplay=false",
                //    },
                //    VerticalOptions = LayoutOptions.FillAndExpand,
                //    HorizontalOptions = LayoutOptions.Center
                //};
                //clipStackLayout.Children.Add(webView);
                //clipScrollView.Content = webView;
            //}

            int test = jsonVal["data"].Count();
            int u = --test;
            webViewStream.Source = new UrlWebViewSource { Url = (string)jsonVal["data"][u]["embed_url"] + "&autoplay=false" };
            u = --u;
            webViewStream2.Source = new UrlWebViewSource { Url = (string)jsonVal["data"][u]["embed_url"] + "&autoplay=false" };
            u = --u;
            webViewStream3.Source = new UrlWebViewSource { Url = (string)jsonVal["data"][u]["embed_url"] + "&autoplay=false" };
            u = --u;
            webViewStream4.Source = new UrlWebViewSource { Url = (string)jsonVal["data"][u]["embed_url"] + "&autoplay=false" };

            /*
            foreach (var data in jsonVa)
            {
                Console.WriteLine("{0} {1}", package.First.type, package.First.quantity);
            }

            for (int i = 0; i <= jsonVal["Data"].Count; i++)
            {
                WebView webView = new WebView
                {
                    Source = new UrlWebViewSource
                    {
                        Url = (string)jsonVal["data"][i]["embed_url"] + "&autoplay=false",
                    },
                    ClassId = "Webview" + 1,
                    VerticalOptions = LayoutOptions.Fill,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                clipStackLayout.Children.Add(webView);

                /*this.Content = new StackLayout
                {
                    Children = {webView}
                };
            }*/

        }

        static async Task<string> DownloadLibraryAsync()
        {
            string page = "https://api.twitch.tv/helix/clips?broadcaster_id=441022939";

            using (HttpClient client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add("client-id", "tvzmv9pqdb75jezxq3epy0plkkgd19");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer 8681g28ri9salj6zf5k4qk9zorliyz");
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

        private void buttonPlus_Clicked(object sender, EventArgs e)
        {
            string lien = "https://www.twitch.tv/retrastv/clips?filter=clips&range=all";
            Browser.OpenAsync(lien, BrowserLaunchMode.SystemPreferred);
        }
    }
}