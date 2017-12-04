using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static Android.Gms.Maps.GoogleMap;
using Android.Gms.Maps;

namespace Solucao_Caronapp.Droid.Models
{
    class MapClickListener : IOnMapClickListener
    {
        public IntPtr Handle => throw new NotImplementedException();

        public GoogleMap _map;

        public MapClickListener(GoogleMap map)
        {
            _map = map;
        }

        public void OnMapClick(LatLng point)
        {
            Toast.MakeText(null, point.ToString(), ToastLength.Long);
            var marcador = new MarkerOptions().SetPosition(point).SetTitle("ponto");

            _map.AddMarker(marcador);
            marcador.Visible(true);
        }

        #region IDisposable Support
        private bool disposedValue = false; // Para detectar chamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: descartar estado gerenciado (objetos gerenciados).
                }

                // TODO: liberar recursos não gerenciados (objetos não gerenciados) e substituir um finalizador abaixo.
                // TODO: definir campos grandes como nulos.

                disposedValue = true;
            }
        }

        // TODO: substituir um finalizador somente se Dispose(bool disposing) acima tiver o código para liberar recursos não gerenciados.
        // ~MapClickListener() {
        //   // Não altere este código. Coloque o código de limpeza em Dispose(bool disposing) acima.
        //   Dispose(false);
        // }

        // Código adicionado para implementar corretamente o padrão descartável.
        public void Dispose()
        {
            // Não altere este código. Coloque o código de limpeza em Dispose(bool disposing) acima.
            Dispose(true);
            // TODO: remover marca de comentário da linha a seguir se o finalizador for substituído acima.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}