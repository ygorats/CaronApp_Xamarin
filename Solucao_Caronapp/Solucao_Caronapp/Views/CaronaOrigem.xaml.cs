using Solucao_Caronapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Solucao_Caronapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CaronaOrigem : ContentPage
    {
        public CaronaOrigem()
        {
            InitializeComponent();

            var ponto = new Pin { Position = new Position(-16.680849, -49.256236), Label = "ponto" };
            myMap.Pins.Add(ponto);
            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(-16.680849, -49.256236), Distance.FromKilometers(0.5)));
            //var stack = GetStackLayout();
            //Content = stack;
        }

        public virtual StackLayout GetStackLayout()
        {
            var map = new ExtendedMap(MapSpan.FromCenterAndRadius(new Position(-16.680849, -49.256236), Distance.FromKilometers(0.5)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand,
                MapType = MapType.Street
            };
            var gesture = new TapGestureRecognizer();
            gesture.Tapped += Gesture_Tapped;
            map.GestureRecognizers.Add(gesture);
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);

            return stack;

        }

        private void Gesture_Tapped(object sender, EventArgs e)
        {
            var ponto = e;
            DisplayAlert("mensagem", e.ToString(), "cancelar");
        }
    }
}