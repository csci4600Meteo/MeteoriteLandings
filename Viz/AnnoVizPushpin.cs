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
    internal class AnnoVizPushpin : Pushpin, IMapViz
    {
        public Guid Id { get; set; }
        internal Annotation Annotation {get; private set;}

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

        internal AnnoVizPushpin(Annotation anno)
        {
            this.Annotation = anno;
            this.Id = Guid.NewGuid();
            
        }


        protected override void OnMouseEnter(MouseEventArgs e)
        {
            ToolTip = "Todo";
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


    }
}
