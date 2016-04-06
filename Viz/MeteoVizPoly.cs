using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MeteoriteLib;

namespace Viz
{
    internal class MeteoVizPoly : MapPolygon, IMapViz
    {

        internal Meteorite Meteorite { get; }
        public Guid Id { get; set; }
        public event EventHandler<MapVizSelectedEventArgs> MapVizSelected;
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

        internal MeteoVizPoly(Meteorite meteo)
        {
            this.Meteorite = meteo;
            this.Id = Guid.NewGuid();
        }


        internal void OnMapVizSelected(MapVizSelectedEventArgs e)
        {
            if (MapVizSelected != null)
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
            ToolTip = string.Format("{0} --> Some sort or descriptive text", this.Id);
        }

   // public bool isVisible { get; set; }
    }
}
