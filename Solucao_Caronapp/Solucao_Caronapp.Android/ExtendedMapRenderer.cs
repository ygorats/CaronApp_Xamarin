using Android.Content;
using Android.Gms.Maps;
using Xamarin.Forms.Maps.Android;
using static Android.Gms.Maps.GoogleMap;
using Android.Gms.Maps.Model;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Platform.Android;
using Android.Views;
using System.Collections.Generic;
using Solucao_Caronapp.Models;
using Android.Widget;
using System;
using Solucao_Caronapp.Droid.Models;

namespace Solucao_Caronapp.Droid
{
    public class ExtendedMapRenderer : MapRenderer, IInfoWindowAdapter
    {
        public GoogleMap _map;
        List<Pin> customPins;

        public ExtendedMapRenderer(Context contexto) : base(contexto)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                NativeMap.InfoWindowClick -= OnInfoWindowClick;
            }

            if (e.NewElement != null)
            {
                var formsMap = (ExtendedMap)e.NewElement;
                customPins = formsMap.CustomPins;
                Control.GetMapAsync(this);
            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            var clickListener = new MapClickListener(map);
            map.SetOnMapClickListener(clickListener);
            _map = map;
            base.OnMapReady(_map);

            NativeMap.InfoWindowClick += OnInfoWindowClick;
            NativeMap.SetInfoWindowAdapter(this);
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            //marker.SetSnippet(pin.Address);
            //marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pin));
            return marker;
        }

        void OnInfoWindowClick(object sender, InfoWindowClickEventArgs e)
        {
            var customPin = GetCustomPin(e.Marker);
            var marcador = new MarkerOptions().SetPosition(e.Marker.Position).SetTitle("ponto");

            _map.AddMarker(marcador);
            //if (customPin == null)
            //{
            //    throw new Exception("Custom pin not found");
            //}

            //if (!string.IsNullOrWhiteSpace(customPin.Url))
            //{
            //    var url = Android.Net.Uri.Parse(customPin.Url);
            //    var intent = new Intent(Intent.ActionView, url);
            //    intent.AddFlags(ActivityFlags.NewTask);
            //    Android.App.Application.Context.StartActivity(intent);
            //}
        }

        public View GetInfoContents(Marker marker)
        {
            var inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
            //if (inflater != null)
            //{
            //    View view;

            //    var customPin = GetCustomPin(marker);
            //    if (customPin == null)
            //    {
            //        throw new Exception("Custom pin not found");
            //    }

            //    if (customPin.Id == "Xamarin")
            //    {
            //        view = inflater.Inflate(Resource.Layout.XamarinMapInfoWindow, null);
            //    }
            //    else
            //    {
            //        view = inflater.Inflate(Resource.Layout.MapInfoWindow, null);
            //    }

            //    var infoTitle = view.FindViewById<TextView>(Resource.Id.InfoWindowTitle);
            //    var infoSubtitle = view.FindViewById<TextView>(Resource.Id.InfoWindowSubtitle);

            //    if (infoTitle != null)
            //    {
            //        infoTitle.Text = marker.Title;
            //    }
            //    if (infoSubtitle != null)
            //    {
            //        infoSubtitle.Text = marker.Snippet;
            //    }

            //    return view;
            //}
            return null;
        }

        public View GetInfoWindow(Marker marker)
        {
            return null;
        }

        Pin GetCustomPin(Marker annotation)
        {
            var position = new Position(annotation.Position.Latitude, annotation.Position.Longitude);
            foreach (var pin in customPins)
            {
                if (pin.Position == position)
                {
                    return pin;
                }
            }
            return null;
        }



        ///////////////////////////////////////////////////////////////////////////////////

        /*
                public ExtendedMapRenderer(Context context) : base(context)
                {
                }

                protected override void OnMapReady(GoogleMap googleMap)
                {
                    _map = googleMap;
                    //_map.MapClick += OnMapClick;

                    NativeMap.InfoWindowClick += OnInfoWindowClick;
                    NativeMap.SetInfoWindowAdapter(this);


                    //if (_map != null)
                    //{
                    //    _map.MapClick += ;
                    //}            
                }

                void OnMapClick(LatLng point)
                {
                    var posicao = new Position(point.Latitude, point.Longitude);
                    var localPin = new Pin() { Label = "Teste", Position = posicao, Type = PinType.Generic };
                    customPins = new List<Pin> { localPin };
                    var marcador = new MarkerOptions().SetPosition(point).SetTitle("ponto");

                    _map.AddMarker(marcador);
                    marcador.Visible(true);
                }

                protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
                {
                    base.OnElementChanged(e);

                    if (e.OldElement != null)
                    {
                        NativeMap.InfoWindowClick -= OnInfoWindowClick;
                    }

                    if (e.NewElement != null)
                    {
                        var formsMap = (ExtendedMap)e.NewElement;
                        customPins = formsMap.CustomPins;
                        Control.GetMapAsync(this);
                    }
                }

                void OnInfoWindowClick(object sender, InfoWindowClickEventArgs e)
                {
                    var posicao = new Position(e.Marker.Position.Latitude, e.Marker.Position.Longitude);
                    var localPin = new Pin() { Label = "Teste", Position = posicao, Type = PinType.Generic };
                    customPins = new List<Pin> { localPin };
                    //var customPin = GetCustomPin(e.Marker);
                    //if (customPin == null)
                    //{
                    //    throw new Exception("Custom pin not found");
                    //}

                    //if (!string.IsNullOrWhiteSpace(customPin.Url))
                    //{
                    //    var url = Android.Net.Uri.Parse(customPin.Url);
                    //    var intent = new Intent(Intent.ActionView, url);
                    //    intent.AddFlags(ActivityFlags.NewTask);
                    //    Android.App.Application.Context.StartActivity(intent);
                    //}
                }

                //protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
                //{
                //    if (_map != null)
                //    {
                //        _map.MapClick -= googleMap_MapClick;
                //    }

                //    base.OnElementChanged(e);
                //    if (Control != null)
                //    {
                //        Control.GetMapAsync(this);
                //    }
                //}

                //private void googleMap_MapClick(object sender, GoogleMap.MapClickEventArgs e)
                //{
                //    ((ExtendedMap)Element).OnTap(new Position(e.Point.Latitude, e.Point.Longitude));
                //}

                void IOnMapClickListener.OnMapClick(LatLng point)
                {
                    //posicoes.add((point.Latitude+ ", " + point.Longitude).toString());
                    var marcador = new MarkerOptions().SetPosition(point).SetTitle("ponto");

                    _map.AddMarker(marcador);
                    marcador.Visible(true);
                }

                View IInfoWindowAdapter.GetInfoContents(Marker marker)
                {
                    return null;
                }

                View IInfoWindowAdapter.GetInfoWindow(Marker marker)
                {
                    return null;
                }
                */
    }
}