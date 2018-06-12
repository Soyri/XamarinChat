using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinChat
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            // await label.RelRotateTo(360, 1000);
            // await entry.RelRotateTo(360, 1000);
            var target_page = new ChatPage(entry.Text);
            
            await Navigation.PushModalAsync(target_page);
        }
    }
}
