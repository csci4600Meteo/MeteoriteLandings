using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viz
{
    public  class MapVizContainer :  Dictionary<Guid,IMapViz>
    {
        public bool showAnnotations { get; set; }
        public bool showMeteors { get; set; }
        public bool showPolys { get; set; }
        public bool showPushpins { get; set; }

        public MapVizContainer()
        {
            showAnnotations = true;
            showMeteors = true;
            showPolys = true;
            showPushpins = true;
        }
        public void updateMap(Map map)
        {
            map.Children.Clear();

            foreach(KeyValuePair<Guid,IMapViz> child in this)
            {
                if (child.Value is AnnoVizPoly && showAnnotations && showPolys)
                    map.Children.Add((AnnoVizPoly)child.Value);

                else if (child.Value is AnnoVizPushpin && showAnnotations && showPushpins)
                    map.Children.Add((AnnoVizPushpin)child.Value);

                else if (child.Value is MeteoVizPoly && showMeteors && showPolys)
                    map.Children.Add((MeteoVizPoly)child.Value);

                else if (child.Value is MeteoVizPushpin && showMeteors && showPushpins)
                    map.Children.Add((MeteoVizPushpin)child.Value);
            }
            
        }
    }
}
