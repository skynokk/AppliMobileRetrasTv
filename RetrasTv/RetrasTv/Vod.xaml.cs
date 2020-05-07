using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace RetrasTv
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vod : ContentPage
    {
        [assembly: ExportFont("BebasNeue-Regular.ttf", Alias = "BebasNeue")]


        public Vod()
        {
        
        InitializeComponent();
        }

       

        private void Button_Clicked_Retour(object sender, EventArgs e)
        {

            App.Current.MainPage = new MainPage();
        }
    }
}