using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Viz
{
    public class AnnoVizPoly : MapPolygon, IMapViz
    {
        public Guid Id { get; set; }

        public AnnoVizPoly()
        {
            this.Id = Guid.NewGuid();
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
