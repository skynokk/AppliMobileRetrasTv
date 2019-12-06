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
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            if (desc3.IsVisible == true || desc2.IsVisible == true || desc4.IsVisible == true)
            {
                
                desc4.IsVisible = false;
                desc2.IsVisible = false;
                desc3.IsVisible = false;
            }
            desc1.IsVisible = desc1.IsVisible == false;
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            if (desc3.IsVisible == true || desc4.IsVisible == true || desc1.IsVisible == true)
            {
                
                desc1.IsVisible = false;
                desc4.IsVisible = false;
                desc3.IsVisible = false;
            }
            desc2.IsVisible = desc2.IsVisible == false;
        }

        private void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            if (desc4.IsVisible == true || desc2.IsVisible == true || desc1.IsVisible == true)
            {
                
                desc1.IsVisible = false;
                desc2.IsVisible = false;
                desc4.IsVisible = false;
            }
            desc3.IsVisible = desc3.IsVisible == false;

        }

        private void ImageButton_Clicked_3(object sender, EventArgs e)
        {
            if (desc3.IsVisible == true || desc2.IsVisible == true || desc1.IsVisible == true)
            {
                
                desc1.IsVisible = false;
                desc2.IsVisible = false;
                desc3.IsVisible = false;
            }
            desc4.IsVisible = desc4.IsVisible == false;
        }
    }
}