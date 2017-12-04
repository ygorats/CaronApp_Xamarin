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
    public partial class CaronaIntermediarios : ContentPage
    {
        public CaronaIntermediarios()
        {
            var map = new Map(MapSpan.FromCenterAndRadius(new Position(-16.680849, -49.256236), Distance.FromKilometers(0.5)))
            {
                IsShowingUser = false,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand,
                MapType = MapType.Street,
            };
            
            
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);

            Content = stack;
        }
    }
}