
using Solucao_Caronapp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Solucao_Caronapp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
                        
        }

        private void btnMapa_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new CaronaOrigem()));
        }
    }
}
