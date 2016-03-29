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

        public void hideMapAnnotations(Map map)
        {
            foreach(KeyValuePair<Guid,IMapViz> kvp in this)
            {
                if(kvp.Value is AnnoVizPoly && !showAnnotations)
                {
                    map.Children.Remove((AnnoVizPoly)kvp.Value);
                }
                else if (kvp.Value is AnnoVizPushpin && !showAnnotations)
                {
                    map.Children.Remove((AnnoVizPushpin)kvp.Value);
                }
            }
        }

        public void showMapAnnotations(Map map)
        {
            foreach (KeyValuePair<Guid, IMapViz> kvp in this)
            {
                if (kvp.Value is AnnoVizPoly && showAnnotations)
                {
                    map.Children.Add((AnnoVizPoly)kvp.Value);
                }
                else if (kvp.Value is AnnoVizPushpin && showAnnotations)
                {
                    map.Children.Add((AnnoVizPushpin)kvp.Value);
                }
            }
        }


        public void showMapMeteorites(Map map)
        {
            foreach (KeyValuePair<Guid, IMapViz> kvp in this)
            {
                if (kvp.Value is MeteoVizPoly && showMeteors)
                {
                    map.Children.Add((MeteoVizPoly)kvp.Value);
                }
                else if (kvp.Value is MeteoVizPushpin && showMeteors)
                {
                    map.Children.Add((MeteoVizPushpin)kvp.Value);
                }
            }
        }

        public void hideMapMeteorites(Map map)
        {
            foreach (KeyValuePair<Guid, IMapViz> kvp in this)
            {
                if (kvp.Value is MeteoVizPoly && !showMeteors)
                {
                    map.Children.Remove((MeteoVizPoly)kvp.Value);
                }
                else if (kvp.Value is MeteoVizPushpin && !showMeteors)
                {
                    map.Children.Remove((MeteoVizPushpin)kvp.Value);
                }
            }
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
