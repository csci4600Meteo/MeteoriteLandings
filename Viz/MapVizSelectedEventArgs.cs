using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viz
{
    public class MapVizSelectedEventArgs : EventArgs
    {
        public object MapVizEntity { get; private set; }
        public MapVizSelectedEventArgs(object mapVizEntity)
        {
            this.MapVizEntity = mapVizEntity;
        }
    }
}
