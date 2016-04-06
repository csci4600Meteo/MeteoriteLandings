using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xaml;
using MeteoriteLib;

namespace Viz
{
    internal class MeteoVizPushpin : Pushpin , IMapViz
    {

        internal Meteorite Meteorite { get; }
        public Guid Id { get; set; }
        //public delegate void MapVizSelectedhandler(IMapViz imv, MapVizSelectedEventArgs e);
        public event EventHandler<MapVizSelectedEventArgs> MapVizSelected;


        internal MeteoVizPushpin(Meteorite meteo)
        {
            this.Meteorite = meteo;
            this.Id = Guid.NewGuid();
            
        }

        event EventHandler<MapVizSelectedEventArgs> IMapViz.MapVizSelected
        {
            add
            {
                MapVizSelected += value;
            }

            remove
            {
                MapVizSelected -= value;
            }
        }

        private void OnMapVizSelected(MapVizSelectedEventArgs e)
        {
            if(MapVizSelected != null)
            {
                MapVizSelected(this, e);
            }
        }



        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            OnMapVizSelected(new MapVizSelectedEventArgs(this.Meteorite));
            
               
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            //MessageBox.Show("Hello");
            ToolTip = string.Format("{0} --> {1} : {2}", this.Id, this.Location.Latitude, this.Location.Longitude);
        }
        // public bool isVisible { get; set; }
    }
}
