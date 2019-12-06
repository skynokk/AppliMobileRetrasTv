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
    public partial class Description : ContentPage
    {
        public Description()
        {
            InitializeComponent();
            var image = new Image { Source = "waterfront.jpg" };

            image.Source = Device.RuntimePlatform == Device.Android ? ImageSource.FromFile("Test.jpg") : ImageSource.FromFile("Images/Test.jpg");
        }
    }
}