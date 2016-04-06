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
    public class MeteoVizPushpin : Pushpin , IMapViz
    {
        
        public Meteorite Meteorite { get; }
        public Guid Id { get; set; }
        //public delegate void MapVizSelectedhandler(IMapViz imv, MapVizSelectedEventArgs e);
        public event EventHandler MapVizSelected;


        public MeteoVizPushpin(Meteorite meteo)
        {
            this.Meteorite = meteo;
            this.Id = Guid.NewGuid();
            
        }


        public void OnMapVizSelected(MapVizSelectedEventArgs e)
        {
            if(MapVizSelected != null)
            {
                MapVizSelected(this, e);
            }
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            //MessageBox.Show("Hello");
            ToolTip = string.Format("{0} --> {1} : {2}", this.Id,this.Location.Latitude,this.Location.Longitude);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            OnMapVizSelected(new MapVizSelectedEventArgs(this.Meteorite));
            
            //todo: select the meteorite associated with this pushpin in datagrid if datagrid is visible
            //probably need to do this via an event that the meteorite datagrid can listen.

  
            
        }

        // public bool isVisible { get; set; }
    }
}
