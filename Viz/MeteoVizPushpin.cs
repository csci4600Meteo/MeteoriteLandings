using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Viz
{
    public class MeteoVizPushpin : Pushpin , IMapViz
    {
        
        public Guid Id { get; set; }
       


        public MeteoVizPushpin()
        {
            this.Id = Guid.NewGuid();
        }
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            //MessageBox.Show("Hello");
            ToolTip = string.Format("{0} --> {1} : {2}", this.Id,this.Location.Latitude,this.Location.Longitude);
        }
        
       // public bool isVisible { get; set; }
    }
}
