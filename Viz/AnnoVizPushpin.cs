using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Viz
{
    public class AnnoVizPushpin : Pushpin, IMapViz
    {
        public Guid Id { get; set; }
        //public Annotation anno {get; set;}
        
        
        public AnnoVizPushpin()//Annotation anno)
        {
            this.Id = Guid.NewGuid();
            
        }

        public event EventHandler MapVizSelected;

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            ToolTip = "Todo";
        }
        //annotation

        //public bool isVisible { get; set; }


    }
}
