﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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

            /*test_clip.Text = task.Result;*/
            /*clip_recup obj = JsonConvert.DeserializeObject<clip_recup>(task.Result);
            string test = obj.embed_url;*/
            JObject jsonVal = JObject.Parse(task.Result) as JObject;
            string val = (string)jsonVal["data"][0]["embed_url"];
            test_clip.Text = val;
        }
        static async Task<string> DownloadLibraryAsync()
        {
            string page = "https://api.twitch.tv/helix/clips?broadcaster_id=441022939";

            using (HttpClient client = new HttpClient())
            {
                // autre possibilité
                //client.BaseAddress = new Uri(page);

                client.DefaultRequestHeaders.Add("client-id", "v495cr8bd4ij2trdgeidujks3ec420");
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
    }
}