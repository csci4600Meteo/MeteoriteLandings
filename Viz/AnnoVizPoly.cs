using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AnnotationLibrary;

namespace Viz
{
    internal class AnnoVizPoly : MapPolygon, IMapViz
    {
        public Guid Id { get; set; }
        public Annotation Annotation { get; private set; }
        internal AnnoVizPoly()
        {
            this.Id = Guid.NewGuid();
        }

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

        private void OnMapVizSelected(MapVizSelectedEventArgs e)
        {
            if (MapVizSelected != null)
            {
                MapVizSelected(this, e);
            }
        }



        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            OnMapVizSelected(new MapVizSelectedEventArgs(this.Annotation));


        }


        protected override void OnMouseEnter(MouseEventArgs e)
        {
            ToolTip = "Hello";
        }

        //public bool isVisible { get; set; }


        // public Location Location { get; set; }


        //public LocationCollection LocationsCollection { get; set; }


    }
}
