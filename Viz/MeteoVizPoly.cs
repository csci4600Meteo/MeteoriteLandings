using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Viz
{
    public class MeteoVizPoly : MapPolygon, IMapViz
    {
        public Guid Id { get; set; }
        //private Meteorites meteo;

        public MeteoVizPoly()
        {
            this.Id = Guid.NewGuid();
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            ToolTip = string.Format("{0} --> Some sort or descriptive text", this.Id);
        }

   // public bool isVisible { get; set; }
    }
}
