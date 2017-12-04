using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace Solucao_Caronapp.Models
{
    public class ExtendedMap : Map
    {
        public List<Pin> CustomPins;

        public ExtendedMap()
        {

        }

        public ExtendedMap(MapSpan region) : base(region)
        {

        }


    }

}
