using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslatorClient.Service;
using Xamarin.Forms;

namespace TranslatorClient
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Authenticate_Clicked(object sender, EventArgs e)
        {
            TranslatedText.Text = await TranslateService.TranslateText(TextToTranslate.Text, "hi");
        }
    }
}
