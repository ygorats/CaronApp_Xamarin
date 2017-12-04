using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Solucao_Caronapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CaronaWizard : TabbedPage
    {
        private List<string> posicoes = new List<string>();

        public CaronaWizard()
        {
            InitializeComponent();
        }
    }
}